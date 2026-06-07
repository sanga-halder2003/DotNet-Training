using LibraryManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Sevices
{
    public class SMSAlert:IAlert
    {
        public void SendAlert(string message)
        {
            Console.WriteLine($"SMS Alert: {message}");
        }
    }
}
