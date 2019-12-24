using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPrint.database.entity;

namespace UPrintServer.converter
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
