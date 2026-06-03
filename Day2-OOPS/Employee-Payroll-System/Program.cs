using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Payroll_System
{
    class program
    {
        static void Main(string[] args)
        {
            //exception handling implementation
            try
            {
                List<Employee> employees = new List<Employee>()
                {
                    new PermanentEmployee(1,"Krishna",70000,5000),
                    new ContractEmployee(2,"Ravi",500,90)
                };
                // calculate salary
                foreach (var employee in employees)
                {
                    employee.CalculateSalary();
                }

                // display payroll

                foreach (var employee in employees)
                {
                    Console.WriteLine($"Employee: {employee.EmployeeName}");

                    if (employee is PermanentEmployee)
                    {
                        Console.WriteLine("Type: Permanent");
                    }
                    else
                    {
                        Console.WriteLine("Type: Contract");
                    }

                    Console.WriteLine($"Salary: {employee.Salary}");
                    Console.WriteLine();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }
        }
    }
}
