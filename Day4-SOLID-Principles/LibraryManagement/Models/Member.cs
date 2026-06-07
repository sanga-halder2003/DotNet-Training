using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Models
{
    public class Member
    {
        public string Name { get; set; }

        public virtual void MembershipDetails()
        {
            Console.WriteLine("General Library MemberShip");
        }
    }
}
