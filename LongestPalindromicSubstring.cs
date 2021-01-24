          using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class LongestPalindromicSubstring
    {
        static void Main(string[] args)
        {
            string s = "babad";


            string palindrom;
            bool[,] myMatrix = new bool[s.Length, s.Length];

            int maxLength = 1; 

            for (int i = 0; i < s.Length; i++)
            {
                myMatrix[i, i] = true;

                 palindrom= s.Substring(i,1);


            }

            for (int i = 0; i < s.Length-1; i++)
            {
                if (s[i].Equals(s[i + 1]))
                {
                    myMatrix[i, i + 1] = true;
                    maxLength = 2;
                    palindrom = s.Substring(i, 2);
                }
            

            }

        //    int j = 0; 
            for (int k = 2; k <= s.Length; k++)
            {
                for (int i = 0; i < s.Length - k; i++)
                {
                    int j= k + i;


                    if (myMatrix[i + 1, j - 1] && s[i] == s[j])
                    {
                        myMatrix[i, j] = true;

                        if (s.Substring(i,j-i+1).Length > maxLength)
                        {
                            palindrom = s.Substring(i,j-i+1);
                            maxLength = s.Substring(i,j-i+1).Length;
                        } 
                    }
                }
            }

          //  Console.WriteLine(s.Substring(start, maxLength));

            
        }
    }
}
