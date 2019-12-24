using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPrint.database.entity
{
    public class Printer
    {
        public short Id { get; set; }
        public String Name { get; set; }
        public String Status { get; set; }
        public bool Active { get; set; }

        public Printer(short pId, String pName, String pStatus, bool pA)
        {
            Id = pId;
            Name = pName;
            Status = pStatus;
            Active = pA;
        }

        public Printer(String pName) : this(0, pName, PrinterStatus.EMPTY, true) { }

        public class PrinterStatus
        {
            public const String READY = "Y";
            public const String EMPTY = "M";
            public const String WORK = "W";
            public const String ERROR = "E";
        }
    }
}
