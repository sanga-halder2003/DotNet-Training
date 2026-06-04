using System;
using System.Collections.Generic;
using System.Text;

namespace TotalMarks
{
    internal class Total_Marks
    {
        static void Main(string[] args)
        {
            int x = Convert.ToInt16(Console.ReadLine());
            int y = Convert.ToInt16(Console.ReadLine());
            int n1 = Convert.ToInt16(Console.ReadLine());
            int n2 = Convert.ToInt16(Console.ReadLine());
            int m = Convert.ToInt16(Console.ReadLine());
            Boolean flag = false;
            for (int i = 1; i <= n1; i++)
            {
                for (int j = 1; j <= n2; j++)
                {
                    if (i * x + j * y == m)
                    {
                        Console.WriteLine("valid");
                        flag = true;
                        Console.WriteLine(i);
                        Console.WriteLine(j);

                    }

                }
                if(flag)
                {
                    break;
                }

            }
            if (!flag)
            {
                Console.WriteLine("Invalid");
            }
        }
        
    }
}
