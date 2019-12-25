using Npgsql;

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
