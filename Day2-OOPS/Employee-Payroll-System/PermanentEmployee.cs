using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll_System
{
    class PermanentEmployee:Employee,IReport
    {
        public double BasicPay {  get; set; }
        public double Bonus {  get; set; }

        public PermanentEmployee(int id, string name, double basic, double bonus):base(id,name) 
        {
            BasicPay = basic;
            Bonus = bonus;
        }

        public override void CalculateSalary()
        {
            Salary = BasicPay + Bonus;
        }

        public  void GenerateReport()
        {
            Console.WriteLine($"Report generated for Permanent Employee: {EmployeeName}");

        }
    }
}
