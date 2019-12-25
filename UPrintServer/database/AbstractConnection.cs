using Npgsql;

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
