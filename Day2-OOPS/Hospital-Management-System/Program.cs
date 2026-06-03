using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System
{
    class Program
    {
        static void Main(string[] args) 
            {
            List<Person> people = new List<Person>()
        {
            new Doctor(1,"Krishna","Cardiology"),
            new Nurse(2,"Ravi","General"),
            new Patient(3,"Anu","Fever")
        };

            foreach (var person in people)
            {
                person.PerformDuty(); // runtime polymorphism
            }

        }
    }
}
