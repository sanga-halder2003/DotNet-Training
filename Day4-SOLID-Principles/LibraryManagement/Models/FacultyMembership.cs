// OCP: New membership type added
// without modifying Member class.

using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Models
{
    public class FacultyMembership:Member
    {
        public override void MembershipDetails()
        {
           Console.WriteLine("Faculty Membership - Extending Borrowing period");
        }
    }
}
