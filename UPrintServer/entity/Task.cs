using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPrint.database.entity
{
    public class Task
    {
        private int v1;
        private string v2;
        private int v3;
        private int v4;
        private DateTime now;
        private object p1;
        private object p2;
        private string nEW;
        private int v5;

        public int Id { get; set; }
        public String Name { get; set; }
        public short Person { get; set; }
        public int Job{ get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public String Status { get; set; }
        public short Printer { get; set; }
        public Task(int pId, String name, short pPerson, int pJob, DateTime pDateAdd, DateTime pTimeStart, DateTime pTimeEnd, String pStatus, short pPrinter)
        {
            Id = pId;
            Name = name;
            Person = pPerson;
            Job = pJob;
            DateAdd = pDateAdd;
            TimeStart = pTimeStart;
            TimeEnd = pTimeEnd;
            Status = pStatus;
            Printer = pPrinter;
        }

        public class TaskStatus
        {
            public const String NEW = "N";
            public const String SUCCESS = "R";
            public const String WORK = "W";
            public const String ERROR = "E";
        }
    }
}
