// OCP: Alert implementations can be extended
// without changing existing code.
using LibraryManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Sevices
{
    internal class EmailAlert:IAlert
    {
        public void SendAlert(string message)
        {
            Console.WriteLine($"Email Alert: {message}");
        }
    }
}
