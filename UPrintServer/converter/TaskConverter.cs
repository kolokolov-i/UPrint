using System.Data;
using UPrint.entity;

namespace UPrint.converter
{
    public class TaskConverter
    {
        public static void toDataRow(DataRow row, Task item)
        {
            row["id"] = item.Id;
            row["name"] = item.Name;
            row["person"] = item.Person;
            row["job"] = item.Job;
            row["date_add"] = item.DateAdd;
            row["time_start"] = item.TimeStart;
            row["time_end"] = item.TimeEnd;
            row["status"] = item.Status;
            row["printer"] = item.Printer;
        }
    }
}
