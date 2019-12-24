using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPrint.database
{
    public abstract class AbstractConnection
    {
        public abstract void Open();

        public abstract void Close();

        public abstract AbstractTransaction BeginTransaction();

        public abstract NpgsqlConnection GetConnection();
    }
}
