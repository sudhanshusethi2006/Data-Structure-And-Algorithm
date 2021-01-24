using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class RemoveKDuplicatesAdjacentStrings
    {
        static void Main(string[] args)
        {
           // string s = "yfttttfbbbbnnnnffbgffffgbbbbgssssgthyyyy";
            string s = "abba";
          
            // string s = "deeedbbcccbdaa";
            string ans = RemoveDuplicates(s, 3);
        }

        class pair
        {
            public int count;
            public char c;
            public pair(int count, char c)
            {
                this.c = c;
                this.count = count;
            }
        }
        public static string RemoveDuplicates(string s, int k)
        {
            StringBuilder sb = new StringBuilder();
            Stack<pair> ss = new Stack<pair>();

            for (int i = 0; i < s.Length;i++)
            {
                if(ss.Count==0 || s[i]!=ss.Peek().c)
                {
                    ss.Push(new pair(1, s[i]));
                }
                else
                {
                    ss.Peek().count++;
                    if(ss.Peek().count ==k)
                    {
                        ss.Pop();
                    }
                }

            }

            while(ss.Count>0)
            {
                pair p = ss.Pop();
                for(int i=0;i<p.count;i++)
                {
                    sb.Append(p.c);
                }
            }

          
            char[] ans = sb.ToString().ToCharArray();
            Array.Reverse(ans);
             return new string(ans);

            //StringBuilder sb = new StringBuilder();
            ////  Stack<char> ss= new Stack<char>();
            //int count = 0;
            //int i = 0;
            //while(i<s.Length)
            //{
            //    if (sb.Length == 0)
            //    {

            //        sb.Append(s[i]);
            //        count++;
            //        i++;
            //    }

            //    else
            //    {

            //        int temp = 1;
            //        int j = i;
            //        while (j < s.Length - 1 && sb[count - 1] == s[j] && temp <= k)
            //        {
            //            temp++;
            //            j++;
            //        }
            //        if (temp == k)
            //        {
            //            sb.Remove(count - 1, 1);
            //            count--;
            //            i = i + k - 1;
            //        }
            //        else if (temp > 1 && temp < k)
            //        {
            //            int backdistance = k - (temp-1);
            //            if (backdistance <= count && sb[count - backdistance] == s[i])
            //            {

            //                sb.Remove(count - backdistance, backdistance);
            //                count = count - backdistance;
            //                i++;
            //                continue;
            //            }
            //            for (int l = 0; l < temp-1; l++)
            //            {
            //                sb.Append(s[i]);
            //                count++;
            //                i++;
            //            }

            //        }

            //        else
            //        {
            //            sb.Append(s[i]);
            //            count++;
            //            i++;
            //        }


            //    }
            //}



            //return sb.ToString();
        }
    }
}
