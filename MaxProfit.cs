using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class MaxProfit
    {


        static void Main(string[] args)
        {
            int[] arr= new int[]{7,1,5,3,6,4};
            int ans = MaxProfit1(arr);

        }



        public static int MaxProfit1(int[] prices)
        {

            int min = int.MinValue;

            int max = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] > min)
                {
                    min = prices[i];
                }
                else if (prices[i] - min > max)
                {
                    max = prices[i] - min;
                }


            }

            return max;

        }
    }
}
