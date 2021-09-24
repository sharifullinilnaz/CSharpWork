using System;
using System.Xml.Serialization;

namespace PersonST
{
    [Serializable]
    public class Student : Person
    {

        public Teacher Teacher{ get; set; }

        public string Group { get; set; }

        public Student() 
        {
        }
        
        public Student(int age, string firstName, string lastName, string group) : base(age, firstName, lastName)
        {
            Group = group;
        }
        
        public override void Print()
        {
            Console.WriteLine("First name : " + FirstName);
            Console.WriteLine("Last name : " + LastName);
            Console.WriteLine("Age : " + Age);
            Console.WriteLine("Group : " + Group);
            Console.WriteLine("Teacher : " + Teacher?.FirstName);
        } 
        
        public override string ToString()
        {
            return base.ToString() + " " + Group ;
        }
        
    }
}