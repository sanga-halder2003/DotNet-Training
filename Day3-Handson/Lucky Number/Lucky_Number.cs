using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyNumber
{
    internal class Lucky_Number
    {
        public static int SumofDigit(int digit)
        {
            int temp = digit;
            int sum = 0;
            while (temp > 0)
            {
                sum += temp % 10;
                temp /= 10;
            }
            return sum;
        }

        public static Boolean IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= n / 2; i++)
            {
                if(n % i == 0) return false;
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int input1 = Convert.ToInt32(Console.ReadLine());
            int input2 = Convert.ToInt32(Console.ReadLine());
            int count = 0;

            for (int i = input1; i <= input2; i++)
            {
                if (!Lucky_Number.IsPrime(i))
                {
                    int s1 = Lucky_Number.SumofDigit(i);
                    int s2 = Lucky_Number.SumofDigit(i * i);

                    if(s2 == s1*s1)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}
