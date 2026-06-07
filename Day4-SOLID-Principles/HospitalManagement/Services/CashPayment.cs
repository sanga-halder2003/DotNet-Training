using HospitalManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services
{
    internal class CashPayment:IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"cash Payment: {amount}");
        }
    }
}
