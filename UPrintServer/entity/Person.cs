using System;

namespace UPrint.entity
{
    public class Person
    {
        public short Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public bool Active { get; set; }
        public Person(short pId, String pLogin, String pPassword, String pName, String pType, bool pActive)
        {
            Id = pId;
            Login = pLogin;
            Password = pPassword;
            Name = pName;
            Type = pType;
            Active = pActive;
        }
        public Person(String login, String password, String type) : this(0, login, password, login, PersonType.REGULAR, true) { }

        public class PersonType
        {
            public const String ADMIN = "A";
            public const String REGULAR = "R";
        }
    }
}
