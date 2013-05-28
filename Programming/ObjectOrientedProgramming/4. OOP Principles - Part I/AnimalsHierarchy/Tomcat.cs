using System;

namespace AnimalsHierarchy
{
    public class Tomcat : Cat
    {
        public Tomcat(int age, string name) : base(age, name)  
        {
            base.Sex = Sex.Male;
        }
    }
}
