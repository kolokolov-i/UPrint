using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPrint.database.entity
{
    class Job
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime DateAdd { get; set; }
        public String Description { get; set; }
        public Person Person { get; set; }
        public Model Model { get; set; }

        public Job(int pId, String name, DateTime pDateAdd, String pDescription, Person pPerson, Model pModel)
        {
            Id = pId;
            Name = name;
            DateAdd = pDateAdd;
            Description = pDescription;
            Person = pPerson;
            Model = pModel;
        }
    }
}
