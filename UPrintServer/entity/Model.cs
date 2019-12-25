using System;

namespace UPrint.entity
{
    public class Model
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Path { get; set; }
        public Model(int pId, String pName, String pPath)
        {
            Id = pId;
            Name = pName;
            Path = pPath;
        }
        public Model(String name) : this(0, name, name) { }
    }
}
