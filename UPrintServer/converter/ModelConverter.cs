using System.Data;
using UPrint.database.entity;

namespace UPrint.converter
{
    public class ModelConverter
    {
        public static void toDataRow(DataRow row, Model item)
        {
            row["id"] = item.Id;
            row["name"] = item.Name;
            row["path"] = item.Path;
        }
    }
}
