using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class LongestCommonSubsequence
    {


        static void Main(string[] args)
        {
            string string1 = "longest";
            string string2 = "stone";

            

            string s = "as";
            string t = "ast";

            if (s == t.Substring(0,2))
            {
               int ans= LCSByRecursion( 0, 0);

                int temp = ans2.Count;
                for (int i = 0; i < temp; i++)
                {
                    Console.Write(ans2.Pop());


                }
            }
            LCSWithoutRecursion("dbbc", "cbbd");
        }
        //string string1 = "abcdefghij";
        //string string2 = "cdgi";

        static string string1 = "longest";
        static string string2 = "stone";


        static int LCSWithoutRecursion(string string1, string string2)
        {

            int[,] matrix = new int[string1.Length + 1, string2.Length + 1];

           


                for (int i = 1; i <= string1.Length; i++) // count for x axis 
                {
                    for (int j = 1; j <= string2.Length; j++) //count for y axis
                    {
                        if (string1[i - 1] == string2[j - 1])
                        {
                            matrix[i, j] = 1 + matrix[i - 1, j - 1];
                        }
                        else
                        {
                            matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                        }
                    }
                }

                int index = matrix[string1.Length, string2.Length];
                char[] ans = new char[index + 1];


                int x = string1.Length;
                int y = string2.Length;

                while (x > 0 && y > 0)
                {
                    if (string1[x - 1] == string2[y - 1])
                    {
                        ans[index-1]= string1[x-1];
                        x--;
                        y--;
                        index--;
                    }
                    else if (matrix[x, y - 1] > matrix[x - 1, y])
                    {
                        y--;
                    }
                    else
                    {
                        x--;
                    }
                }
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k<= matrix[string1.Length, string2.Length]; k++)
                {
                    sb.Append(ans[k]);
                }

                string myAns = sb.ToString();

                   

                    return matrix[string1.Length, string2.Length];
            
        }
       static Stack<char> ans2 = new Stack<char>();
        static int LCSByRecursion( int i, int j)
        {
            if (i == string1.Length || j == string2.Length)
            {
                return 0;
            }
            if(string1[i].Equals(string2[j])){
                if (!ans2.Contains(string1[i])) ans2.Push(string1[i]); 
                
                return 1 + LCSByRecursion(i + 1, j + 1);
            }

            else
            {
                return Math.Max(LCSByRecursion( i, j+1) , LCSByRecursion(i+1, j)); 
            }


            //if (i == string1.Length || j == string2.Length)
            //{
            //    return 0;
            //}

            //else if (string1[i] == string2[j])
            //{
            //    return 1 + LCSByRecursion(string1, string2, i + 1, j + 1);
            //}

            //else
            //{
            //    return Math.Max(LCSByRecursion(string1, string2, i + 1, j), LCSByRecursion(string1, string2, i, j + 1));
            //}
        }
    }
}
