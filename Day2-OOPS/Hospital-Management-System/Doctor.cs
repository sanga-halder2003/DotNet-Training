using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System
{
     class Doctor:Person
    {
        public Doctor(int id, string name, string dept):base(id, name)
        {
            Department = dept;
        }

        public override void PerformDuty()
        {
            Console.WriteLine($"Doctor {Name} is treating patients.");
        }
    }
}
