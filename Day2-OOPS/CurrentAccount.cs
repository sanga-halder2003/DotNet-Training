using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Management_System
{
     class CurrentAccount: Account
    {
        public CurrentAccount(int accNo, string name, double bal): base(accNo, name, bal) { }

        public override void CalculateInterest()
        {
            Console.WriteLine("\nNo interest for Current Account");
        }
        // method override

        public override void Withdraw(double amount)
        {
           Balance -= amount;
            Console.WriteLine("Withdrawn from current Account");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account account = new SavingsAccount(1001, "Krishna", 50000);
            account.DisplayDetails();
            account.CalculateInterest();

            Account acc = new CurrentAccount(1002,"Sanga",10000);
            acc.Withdraw(500);
            acc.CalculateInterest();
            acc.DisplayDetails();


     }
    }

}
