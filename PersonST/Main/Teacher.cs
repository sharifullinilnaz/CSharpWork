using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PersonST
{
    [Serializable]
    public class Teacher : Person
    {
        public int WorkExperience{ get; set; }
        
        [XmlIgnore]
        List<Student> _students = new();

        public Teacher()
        {
        }
        
        public Teacher(int age, string firstName, string lastName, int workExperience) : base(age, firstName, lastName)
        {
            WorkExperience = workExperience;
        }
        
        public void AddStudent(Student student)
        {
            _students.Add(student);
            student.Teacher = this;
        }

        public override void Print()
        {
            Console.WriteLine("First name : " + FirstName);
            Console.WriteLine("Last name : " + LastName);
            Console.WriteLine("Age : " + Age);
            Console.WriteLine("Work experience : " + WorkExperience);
            Console.WriteLine("Students : ");
            int number = 1;
            foreach (var student in _students)
            {
                Console.Write(number++ + ": ");
                student.Print();
            }

            Console.WriteLine();
        }
        
        public override string ToString()
        {
            return base.ToString() + " " + WorkExperience;
        }
        
    }
}