using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Management_System
{
     class SavingsAccount :Account
    {
        public SavingsAccount(int accNo, string name, double bal): base(accNo, name, bal) 
        {
        }

        public override void CalculateInterest()
        {
            double interest = Balance * 0.05;
            Balance += interest;

            Console.WriteLine($"\nInterest Added: {interest}");
            Console.WriteLine($"Updated Balance: {Balance}");
        }

        // Polymorphism

        public override void Withdraw(double amount)
        {
            if(amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds in Savings Account");
            }
        }


        
    }
}
