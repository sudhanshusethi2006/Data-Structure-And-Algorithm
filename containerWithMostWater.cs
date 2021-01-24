using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class containerWithMostWater
    {
        public int MaxArea(int[] height)
        {

            int i = 0;
            int j = height.Length - 1;
            int max = 0;

            while (i < j)
            {
                int tempArea = getArea((j - i), Math.Min(height[i], height[j]));

                max = tempArea > max ? tempArea : max;


                if (height[i] < height[j])
                {
                    i++;
                }
                else
                {
                    j--;
                }

            }

            return max;
        }

        private int getArea(int len, int width)
        {
            return len * width;
        }
    }
}
