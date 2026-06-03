using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll_System
{
     class ContractEmployee:Employee
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public ContractEmployee(int id, string name, double rate, int hours):base(id,name)
        {
            HourlyRate = rate;
            HoursWorked = hours;
        }

        public override void CalculateSalary()
        {
            Salary = HoursWorked * HourlyRate;
        }
    }
}
