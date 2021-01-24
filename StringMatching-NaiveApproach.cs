using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class StringMatching_NaiveApproach
    {

        static void  Main(string[] args)
        {
            string s1 = "abcdabcabcd";
            string s2 = "abcdf";
             s1 = "aaaaaaaaabbbbbacd";
             s2 = "abc";
            int curr = 0;

            int i = 0;
            int j = 0;
            bool match = false;
            while (i < s1.Length)
            {
                while (j < s2.Length && i < s1.Length)
                {
                    if (s1[i].Equals(s2[j]))
                    {

                        i++;
                        j++;
                     
                    }
                    else
                    {
                        match = false;
                        break;
                    }
                  
                }
                if (j==s2.Length)
                {
                    match = true;
                    Console.Write("match");
                    break;
                    
                }
                curr++;
                i = 1 + curr;
                j = 0;
               
            }
            if (!match)
            {
                Console.WriteLine("no match");

            }
        }
    }
}
