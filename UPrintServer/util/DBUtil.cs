using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using UPrint.database;
using Npgsql;
using System.Diagnostics;

namespace UPrint.util
{
    public class DBUtil
    {
        private static string pathReset;
        private static string pathClean;

        static DBUtil()
        {
            pathReset = Path.Combine("sql", "reset.sql");
            pathClean = Path.Combine("sql", "clean.sql");
        }

        public static void Reset()
        {
            String script = File.ReadAllText(pathReset);
            RunScript(script);
        }

        public static void Clean()
        {
            String script = File.ReadAllText(pathClean);
            RunScript(script);
        }

        public static void RunScript(string script)
        {
            AbstractConnection aConnection = null;
            AbstractTransaction aTransaction = null;
            try
            {
                aConnection = DBFactory.CreateConnection();
                aConnection.Open();
                aTransaction = aConnection.BeginTransaction();
                NpgsqlCommand command = new NpgsqlCommand(script, aConnection.GetConnection(), aTransaction.GetTransaction());
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                aTransaction.Rollback();
            }
            finally
            {
                aConnection.Close();
            }
        }
    }
}
