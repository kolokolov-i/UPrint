using System.Data;
using UPrint.entity;

namespace UPrint.converter
{
    public class PersonConverter
    {
        public static void toDataRow(DataRow row, Person item)
        {
            row["id"] = item.Id;
            row["login"] = item.Login;
            row["password"] = item.Password;
            row["name"] = item.Name;
            row["type"] = item.Type;
            row["active"] = item.Active;
        }
    }
}
