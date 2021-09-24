using System;

namespace PersonST
{
    class PersonException : Exception 
    {
        public PersonException(string eMessage, int value)
            : base(eMessage) 
        {
            ErrorValue = value;
        }
        
        public int ErrorValue { get; }
        
    }
}