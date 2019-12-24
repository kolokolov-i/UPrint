using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPrint.database
{
    public class UPrintTransaction : AbstractTransaction
    {
        NpgsqlTransaction pgTransaction;

        public UPrintTransaction(NpgsqlTransaction transaction)
        {
            pgTransaction = transaction;
        }

        public override void Commit()
        {
            pgTransaction.Commit();
        }

        public override void Rollback()
        {
            pgTransaction.Rollback();
        }
        public override NpgsqlTransaction GetTransaction()
        {
            return pgTransaction;
        }
    }
}
