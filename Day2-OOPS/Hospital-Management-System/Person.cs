using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System
{
    abstract class Person
    {
        public int Id;
        public string Name;
        public string Department {
            get;
            set; 
        }

        // Encapsulation
        private string disease;
        public string Disease
        {
            get { return disease; }
            protected set { disease = value; }

        }

        // abstraction (abstract method)

        public abstract void PerformDuty();

        public Person(int id, string name) 
        {
            Id = id;
            Name = name;
        }

        // method
        public void GetDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}");
        }
            
    }
}
