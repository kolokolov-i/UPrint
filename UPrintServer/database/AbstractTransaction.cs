using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace UPrint.database
{
    public abstract class AbstractTransaction
    {
        public abstract void Commit();

        public abstract void Rollback();

        public abstract NpgsqlTransaction GetTransaction();
    }
}
