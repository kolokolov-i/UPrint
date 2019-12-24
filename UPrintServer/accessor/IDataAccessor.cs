using UPrint.database;

namespace UPrint.accessor
{
    public interface IDataAccessor
    {
        void Read(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet);
        void Update(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet);
    }
}
