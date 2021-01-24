using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    // this solution works only for identical elements in array
    class FourSumShortAndOptimized
    {
        static void Main(string[] args)
        {
            var ans = Forsum(new int[] {7,6,4,-1,1,2 }, 16);
        }
        

        static List<int[]> Forsum(int[] array, int targetSum)
        {
            Dictionary<int, List<int[]>> dd = new Dictionary<int, List<int[]>>();


            List<int[]> ans = new List<int[]>();


            for(int i=1;i<array.Length;i++)
            {
                for(int j=i+1 ;j<array.Length;j++)
                {
                    int currentSum = array[i] + array[j];
                    int difference = targetSum - currentSum;
                    if(dd.ContainsKey(difference))
                    {
                        foreach(int[] pair in dd[difference])
                        {
                            ans.Add(new int[] { pair[0], pair[1], array[i], array[j] });
                        }
                    }


                }

                for(int k=0;k<i;k++)
                {
                    int currentSum = array[i] + array[k];

                    if (!dd.ContainsKey(currentSum))
                    {
                        dd.Add(currentSum, new List<int[]> { new int[] { array[i], array[k] } });

                    }
                    else
                    {
                        dd[currentSum].Add(new int[] { array[i], array[k] });
                    }


                }
            }


            return ans;

        }


    }
}
