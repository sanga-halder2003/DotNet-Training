using RiderSharingApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiderSharingApp.Services
{
    public class WhatsAppNotification:INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"WhatsApp Sent: {message}");
        }

       
    }
}
