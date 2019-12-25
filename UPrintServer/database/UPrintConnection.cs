using Npgsql;

namespace UPrint.database
{
    public class UPrintConnection : AbstractConnection
    {
        private NpgsqlConnection pgConnection;

        public UPrintConnection(NpgsqlConnection con)
        {
            pgConnection = con;
        }

        public override AbstractTransaction BeginTransaction()
        {
            NpgsqlTransaction pgTransaction = pgConnection.BeginTransaction();
            return new UPrintTransaction(pgTransaction);
        }

        public override void Close()
        {
            pgConnection.Close();
        }

        public override void Open()
        {
            pgConnection.Open();
        }

        public override NpgsqlConnection GetConnection()
        {
            return pgConnection;
        }
    }
}
