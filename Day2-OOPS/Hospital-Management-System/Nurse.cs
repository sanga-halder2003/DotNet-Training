using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System
{
    class Nurse:Person
    {
        public Nurse(int id, string name, string dept) : base(id, name) 
        {
            Department = dept;
        }

        public override void PerformDuty()
        {
            Console.WriteLine($"Nurse {Name} is assisting doctors");        
        }
    }
}
