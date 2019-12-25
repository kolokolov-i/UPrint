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
