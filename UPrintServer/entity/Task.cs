using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPrint.database.entity
{
    class Task
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Person Person { get; set; }
        public int Job{ get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public String Status { get; set; }
        public short Printer { get; set; }
        public Task(int pId, String name, Person pPerson, int pJob, DateTime pDateAdd, DateTime pTimeStart, DateTime pTimeEnd, String pStatus, short pPrinter)
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
    }
}
