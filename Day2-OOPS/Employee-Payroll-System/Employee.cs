using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll_System
{
     abstract class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        private double salary;

        public double Salary 
        { 
            get {return salary;}
            protected set { salary = value;}
        }
        // constructor overloading
        public Employee(){ }
        public Employee(int id, string name)
        {
            EmployeeId = id;
            EmployeeName = name;
        }

        // abstract method

        public abstract void CalculateSalary();

        // method
        public void DisplayInfo()
        {
            Console.WriteLine($"Employee: {EmployeeName}");
            Console.WriteLine($"Salary: {Salary}");

        }



    }
}
