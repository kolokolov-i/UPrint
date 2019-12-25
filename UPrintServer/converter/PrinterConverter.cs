using System.Data;
using UPrint.entity;

namespace UPrint.converter
{
    public class PrinterConverter
    {
        public static void toDataRow(DataRow row, Printer item)
        {
            row["id"] = item.Id;
            row["name"] = item.Name;
            row["status"] = item.Status;
            row["active"] = item.Active;
        }
    }
}
