using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PersonST
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new();
            List<Teacher> teachers = new();
            try
            {
                //Creating students and teachers
                students.Add(new Student(21, "Ilnaz","Sharifullin","11-801"));
                students.Add(new Student(22, "Max","Petrov","11-802"));
                students.Add(new Student(18, "Mihail","Abramsky","11-801"));
            
                teachers.Add(new Teacher(35,"Oleg", "Konkov", 5));
                teachers.Add(new Teacher(40,"Aleksander", "Popov", 12));
                
                //Creating Person object
                Person person = new Person(12,"Sasha","Ivanov");
                
                //Adding students to teachers 
                foreach (var s in students)
                {
                    teachers[0].AddStudent(s);
                }
                teachers[1].AddStudent(students[2]);

                //Output of created objects
                foreach (var t in teachers)
                {
                    t.Print();
                }
                person.Print();
                
                //Serializing the list of students
                XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
                
                using (FileStream fs = new FileStream("student.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, students);
                    Console.WriteLine("Students objects serialized");
                }
                
                //Deserializing the list of students
                using (FileStream fs = new FileStream("student.xml", FileMode.OpenOrCreate))
                {
                    List<Student> newStudents = (List<Student>)formatter.Deserialize(fs);
                    Console.WriteLine("Students objects deserialized : ");
                    if (newStudents != null)
                        foreach (var s in newStudents)
                        {
                            s.Print();
                        }
                }
                
                //Attempt to add a student with a negative age. Demonstration of Exception Handling
                students.Add(new Student(-18, "Tom","Sharifullin","11-811"));
                
                Console.Read();
            }
            catch (PersonException ex)
            {
                Console.WriteLine("Exception : " + ex.Message + " ( invalid value: " + ex.ErrorValue + " )");
            }
            
        }
    }
}