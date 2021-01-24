using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace LeetCodePractice
{


    class fourSumProblemBruteForce
    {


        static void Main(string[] args)
        {

            
            int[] nums = new int[] { 1, 0, -1, 0, -2, 2 };
           // int[] nums = new int[] { 1, 1, 1, 1, 1, 1 };
            int target = 0;
            List<List<int>> ans = FourSum(nums, target);
        }
        public static List<List<int>> FourSum(int[] nums, int target)
        {
            HashSet<Quadraplet> allQuadraplets = new HashSet<Quadraplet>();


            for (int i = 0; i < nums.Length - 3; i++)
            {
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    for (int k = j + 1; k < nums.Length - 1; k++)
                    {
                        for (int l = k + 1; l < nums.Length; l++)
                        {
                            if (nums[i] + nums[j] + nums[k] + nums[l] == target)
                            {
                                Quadraplet obj = new Quadraplet(nums[i], nums[j], nums[k], nums[l]);
                                if (!allQuadraplets.Contains(obj))
                                {
                                    allQuadraplets.Add(obj);
                                }
                            }
                        }
                    }
                }
            }


            List<IList<int>> ans = new List<IList<int>>();
            foreach (Quadraplet eachQuadraplet in allQuadraplets)
            {
                List<int> singlelist = new List<int>();

                singlelist.Add(eachQuadraplet.a);
                singlelist.Add(eachQuadraplet.b);
                singlelist.Add(eachQuadraplet.c);
                singlelist.Add(eachQuadraplet.d);
                ans.Add(singlelist);

            }
            var ss = 
            allQuadraplets.Select(x => new List<int>
            {
               
                x.a,
                x.b,
                x.c,
                x.d
            }).ToList();
            
            
          


            //foreach (IList<int> i in ans)
            //{
            //    foreach (int k in i)
            //    {
            //        Console.WriteLine(k);
            //    }
            //}


            return ss;
        }

        class Quadraplet
        {

            public int a, b, c, d;
            public Quadraplet(int a, int b, int c, int d)
            {
                int[] nums = new int[4];
                nums[0] = a;
                nums[1] = b;
                nums[2] = c;
                nums[3] = d;
                Array.Sort(nums);
                this.a = nums[0];
                this.b = nums[1];
                this.c = nums[2];
                this.d = nums[3];


            }

            public override bool Equals(object obj)
            {
                Quadraplet o = (Quadraplet)obj;
                bool ans = o.a == a && o.b == b && o.c == c && o.d == d;
                return ans;

            }

            public override int GetHashCode()
            {
                return 0;
            }

        }

    }

   


}
