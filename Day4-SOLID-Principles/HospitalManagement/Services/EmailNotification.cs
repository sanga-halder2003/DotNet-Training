using HospitalManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services
{
    public class EmailNotification:INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }
}
