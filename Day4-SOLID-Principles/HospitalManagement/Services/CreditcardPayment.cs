// OCP: Added a new payment method
// without changing existing payment classes.

using HospitalManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services
{
   public class CreditcardPayment:IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Credit Card Payment: {amount}");
        }
    }
}
