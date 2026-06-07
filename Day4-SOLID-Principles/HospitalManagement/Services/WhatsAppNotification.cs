// OCP: Extended functionality by adding a new class
// instead of modifying EmailNotification.

using HospitalManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services
{
    public class WhatsAppNotification:INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"WhatsApp sent : {message}");
        }
    }
}
