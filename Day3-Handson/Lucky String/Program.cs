using System;
using System.Collections.Generic;
using System.Text;

namespace Lucky_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int len = Convert.ToInt16(Console.ReadLine());
            string input = Console.ReadLine();
            Console.WriteLine(IsLucky(input,len));
        }
        public static string IsLucky(string s, int n)
        {
            for (int i = 0; i <= s.Length-n; i++)
            {
                string sub_string = s.Substring(i, n);
                bool flag = true;
                foreach (char ch in sub_string)
                {
                    if (ch != 'P' && ch != 'S' && ch != 'G')
                    {
                        flag = false;
                        break;
                    }
                }

                if (!flag)
                    continue;

                int max = 1;
                int curr = 1;
                for (int j = 1; j < sub_string.Length; j++)
                {
                    if (sub_string[j] == sub_string[j - 1])
                    {
                        curr++;
                        max = Math.Max(max, curr);
                    }
                    else
                    {
                        curr = 1;
                    }
                }
                if (max >= n / 2)
                    return "valid";
            }
            return "Invalid";
        }
    }
}
