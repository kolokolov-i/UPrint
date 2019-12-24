using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPrint.database
{
    public class DBFactory
    {
        private static readonly string connectionString;

        static DBFactory()
        {
            //AppSettingsReader asr = new AppSettingsReader();
            //connectionString = (string) asr.GetValue("conStr", typeof(string));
            connectionString = "Host=127.0.0.1; Port=5432; Database=uprint; Username=uprint; Password=55555;";
        }

        public static AbstractConnection CreateConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            return new UPrintConnection(connection);
        }
    }
}
