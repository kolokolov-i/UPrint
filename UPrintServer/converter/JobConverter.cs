using System.Data;
using UPrint.database.entity;

namespace UPrint.converter
{
    public class JobConverter
    {
        public static void toDataRow(DataRow row, Job item)
        {
            row["id"] = item.Id;
            row["name"] = item.Name;
            row["date_add"] = item.DateAdd;
            row["description"] = item.Description;
            row["person"] = item.Person;
            row["model"] = item.Model;
        }
    }
}
