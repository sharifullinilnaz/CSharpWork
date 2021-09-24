using System;

namespace PersonST
{
    public class Person
    {
        public int Age { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public Person()
        {
        }
        
        public Person(int age, string firstName, string lastName)
        {
            if (age < 0)
            {
                throw new PersonException("Negative age", age);
            }

            if (age > 125)
            {
                throw new PersonException("Age is too high", age);
            }
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual void Print()
        {
            Console.WriteLine("First name : " + FirstName);
            Console.WriteLine("Last name : " + LastName);
            Console.WriteLine("Age : " + Age);
        }

        public override string ToString()
        {
            return base.ToString() + ": " + FirstName + " " + LastName + " " + Age;
        }

    }
}