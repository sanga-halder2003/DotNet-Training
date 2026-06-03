using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System
{
    class Patient : Person
    {
        public Patient(int id, string name, string disease) : base(id, name)
        {
            Disease = disease;
        }

        public override void PerformDuty()
        {
            Console.WriteLine($"Patient {Name} is recieving treatment.");
        }
    }

    

}
