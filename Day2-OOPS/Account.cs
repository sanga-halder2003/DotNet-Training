using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Management_System
{
    abstract class Account
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }

        private double balance; //Encapsulation

        // Abstract Method
        public abstract void CalculateInterest();// abstraction

        public double Balance 
        {
            get { return balance; } 
            protected set { balance = value; } // restrict direct modification

        }

        // constructor
        public Account(int accNo, string name, double balance)
        {
            AccountNumber = accNo;
            CustomerName = name;
            Balance = balance;
        }

        // methods

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if(amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Account:{AccountNumber}");
            Console.WriteLine($"Customer:{CustomerName}");
            Console.WriteLine($"Balance:{Balance}");
        }


    }
}
    