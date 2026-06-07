using RiderSharingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiderSharingApp.Services
{
    public class EmailNotification:INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email Sent: {message}");
        }
        
    }
}
