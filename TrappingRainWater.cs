using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class TrappingRainWater
    {
        static void Main(string[] args)
        {
        //    int[] height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int[] height = new int[] { 0, 1,0,1,0,1 };

            int water = Trap(height);
        }


        public static int Trap(int[] height)
        {
            if (height.Length == 0) return 0;


            int result = 0;
            int level = 0;
            int left = 0;
            int right = height.Length - 1;


            while(left<right)
            {
                int index = 0;
                if(height[left]< height[right])
                {
                    index = left;
                    left++;
                }
                else
                {
                    index = right;
                    right--;
                }

                int lower = height[index];

                level = Math.Max(level, lower);
                result += level - lower;
           
            }


            return result;

        }
    }
}
