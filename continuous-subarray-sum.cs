using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class continuous_subarray_sum
    {
        static void Main(string[] args)
        {

            
            int sum = 0;
            int[] nums = new int[] { 23, 2, 4, 6, 7 };

            int[] nums123 = new int[] { 23, 2, 4, 6, 7 };

            
            int k = 6;
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, -1);
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (k != 0)
                {
                    sum = sum % k;
                }
                if (map.ContainsKey(sum))
                {
                    if (i - map[sum] > 1)
                    {
                        Console.Write("true");
                        break;
                    }


                }
                else map.Add(sum, i);
            }


            Console.Write("false");
        }
    }
}
