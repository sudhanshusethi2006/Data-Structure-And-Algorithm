using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class LongestCommonPrefix
    {

        static void Main(string[] args)
        {
            string[] strs = new string[] { "flowed", "flowedoiio", "flighted", "flooooooed" };


           // string str = "flowed";
           // Array.Reverse(str.ToCharArray());


           // char[] arr = str.ToArray();
           // Array.Reverse(arr);
           //string s = new String(arr);

           // Console.WriteLine(strs[0].Substring(1));




            string prefix = strs[0];


            for (int i = 1; i < strs.Length; i++)
            {

               //  this is to calculate common suffix
                while (!strs[i].StartsWith(prefix))
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                }



                //OR

                //int temp = strs[i].IndexOf(prefix);
                //while (strs[i].IndexOf(prefix) != 0)
                //{
                //    prefix = prefix.Substring(0, prefix.Length - 1);
                //    if (prefix.Length == 0)
                //    {
                //        Console.WriteLine("");
                //        break;
                //    }
                //}
            }




        }
    }
}

