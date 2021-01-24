using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class MinStepsToMakeAnagram
    {
        static void Main(string[] args)
        {
            string s = "leetcode";
            string t = "practice";


            var dds = s.GroupBy(x => x, (key, val) => new { key, val = val.Count() }).ToDictionary(x => x.key, x => x.val);
            var ddt = t.GroupBy(x => x, (key, val) => new { key, val = val.Count() }).ToDictionary(x => x.key, x => x.val);

            int count = 0;

            for (int i = 0; i < dds.Count; i++)
            {

                if (!ddt.ContainsKey(dds.ElementAt(i).Key))
                {
                    Console.WriteLine("--2--");
                    count = count + dds.ElementAt(i).Value;

                    Console.WriteLine(count);
                }
            }

            for (int i = 0; i < ddt.Count; i++)
            {
                if (!dds.ContainsKey(ddt.ElementAt(i).Key))
                {
                    Console.WriteLine("--1--");
                    count = count + ddt.ElementAt(i).Value;

                    Console.WriteLine(count);
                }

                else
                {

                    char tempKey = ddt.ElementAt(i).Key;

                    if (dds[tempKey] > ddt[tempKey])
                    {

                        int diff1 = dds[tempKey] - ddt[tempKey];
                        Console.WriteLine(diff1);
                        count = count + (diff1);
                        Console.WriteLine(count);

                    }
                    else
                    {

                        int diff2 = Math.Abs(ddt[tempKey] - dds[tempKey]);
                        Console.WriteLine(diff2);
                        count = count + (diff2);

                        Console.WriteLine(count);
                    }
                }
            }

            // return count/2;

            // shorter and smarter way 



            int[] Arr_s = new int[26];
            int[] Arr_t = new int[26];


            for (int i = 0; i < s.Length; i++)
            {
                Arr_s[s[i] - 'a']++;
            }


            for (int i = 0; i < t.Length; i++)
            {
                Arr_t[t[i] - 'a']++;
            }

            int count1 = 0;
            for (int i = 0; i < 26; i++)
            {
                count1 += Math.Abs(Arr_s[i] - Arr_t[i]);
            }


       //     return count / 2;    

        }
    }
}
