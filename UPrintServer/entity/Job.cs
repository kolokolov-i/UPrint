using System;

namespace UPrint.entity
{
    public class Job
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime DateAdd { get; set; }
        public String Description { get; set; }
        public short Person { get; set; }
        public int Model { get; set; }

        public Job(int pId, String name, DateTime pDateAdd, String pDescription, short pPerson, int pModel)
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
