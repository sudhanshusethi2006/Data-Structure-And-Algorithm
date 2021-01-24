using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class PatternmatchingKMP
    {

        static int powerCalculator(int basenumber, int power)
        {

            if (power == 0) return 1;

            return basenumber * powerCalculator(basenumber, power - 1);

        }


        static void Main(string[] args)
        {

            int ans = powerCalculator(2, 6);

         //   int[] arr;
         //   Array.Sort(arr);
          //  Array.Reverse(arr);
            string s = "aaaaaaaaabaacdkkkkkkkkkgfhsdfhysfhsdfgrsdefgreradtgrasegtsergtsfgsdrfgeartgswert";
            string pattern = "aaaabaacd";

            //   string pattern = "abcaby";
            int[] TempArray_pattern = new int[pattern.Length];

            int i = 1, j = 0;


            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[j])
                {
                    TempArray_pattern[i] = j + 1;
                    i++;
                    j++;
                }
                else
                {

                    if (j > 0)
                    {
                        j = TempArray_pattern[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            for (int x = 0; x < TempArray_pattern.Length; x++)
            {
                Console.Write(" " + TempArray_pattern[x] + " ");
            }

            i = 0;
            j = 0;

            bool match = false;
            while (i < s.Length && j < pattern.Length)
            {
                if (s[i].Equals(pattern[j]))
                {
                    i++;
                    j++;
                }

                else
                {
                    if (j > 0)
                    {
                        j = TempArray_pattern[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }

                if (j == pattern.Length)
                {
                    match = true;
                }


            }

            if (match)
            {
                Console.Write("match");
            }
            else
            {
                Console.WriteLine("Not match");
            }
        }
    }
}
