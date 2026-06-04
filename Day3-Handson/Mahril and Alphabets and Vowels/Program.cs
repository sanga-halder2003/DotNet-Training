using System;
using System.Collections.Generic;
using System.Text;

namespace Mahril_and_Alphabets_and_Vowels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Aaaabcc";
            string s2 = "bcd";
            Console.WriteLine(Ruled_String(s1,s2));
        }
        public static string Ruled_String(string s1, string s2)
        {
            s1 = s1.ToLower();
            s2 = s2.ToLower();
            string temp = "";
            foreach (char ch in s1)
            {
                bool isVowel = "aeiou".Contains(ch);

                if (isVowel || !s2.Contains(ch))
                {
                    temp += ch;
                }
            }
            string res = "";
            for (int i = 0; i < temp.Length; i++)
            {
                if (i == 0 || temp[i] != temp[i - 1])
                {
                    res += temp[i];
                }
            }

            res = char.ToUpper(res[0]) + res.Substring(1);

            return res; 

        }
    }
}
