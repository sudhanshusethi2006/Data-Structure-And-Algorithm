using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class fourSumProblemOptimized
    {


        static void Main(string[] args)
        {
              int[] nums = new int[] { 1, 0, -1, 0, -2, 2 };
           // int[] nums = new int[] { 1, 1, 1, 1, 1, 1 };
            int target = 0;
            List<IList<int>> ans = FourSum(nums, target);
        }
        public static List<IList<int>> FourSum(int[] nums, int target)
        {
            Dictionary<int, List<couple>> hm = new Dictionary<int, List<couple>>();

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int sum = nums[i] + nums[j];


                    if (!hm.ContainsKey(sum))
                    {
                        List<couple> l = new List<couple>();
                        l.Add(new couple(i, j));

                       
                        hm.Add(sum, l);
                    }

                    else
                    {
                        hm[sum].Add(new couple(i, j));
                    }
                }
            }

            HashSet<Quadraplet> qset = new HashSet<Quadraplet>();
            //IEnumerator en_hm = hm.Keys.GetEnumerator();
            //while (en_hm.MoveNext())
            foreach (int key in hm.Keys)
            {
              //  int currentsum = (int)en_hm.Current;
                int currentsum = key;
                int needed = target - currentsum;
                if (!hm.ContainsKey(needed)) continue;


                List<couple> curentsumList = hm[currentsum];
                List<couple> targetsumList = hm[needed];


                foreach (couple currentListCouple in curentsumList)
                {
                    foreach (couple targetListCouple in targetsumList)
                    {
                        if (currentListCouple.Equals(targetListCouple)) continue;
                        Quadraplet q = new Quadraplet(nums[currentListCouple.i], nums[currentListCouple.j], nums[targetListCouple.i], nums[targetListCouple.j]);
                        if (qset.Contains(q)) continue;
                        qset.Add(q); ;
                    }
                }
            }

            var ans = qset.Select(x => new List<int>
            {
               
                x.a,
                x.b,
                x.c,
                x.d
            }).ToList();


            List<IList<int>> ans2 = new List<IList<int>>();
            foreach (Quadraplet eachQuadraplet in qset)
            {
                List<int> singlelist = new List<int>();

                singlelist.Add(eachQuadraplet.a);
                singlelist.Add(eachQuadraplet.b);
                singlelist.Add(eachQuadraplet.c);
                singlelist.Add(eachQuadraplet.d);
                ans2.Add(singlelist);

            }

            return ans2;
        }



        class couple
        {
            public int i, j;
            public couple(int i, int j)
            {
                this.i = i;
                this.j = j;
            }

            public override bool Equals(object obj)
            {
                couple o = (couple)obj;

                bool eq = this.i == o.i || this.i == o.j || this.j == o.i || this.j == o.j;

                return eq;


            }

            public override int GetHashCode()
            {
                return 0;
            }
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
                bool ans = this.a == o.a && this.b == o.b && this.c == o.c && this.d == o.d;
                return ans;

            }

            public override int GetHashCode()
            {
                return 0;
            }

        }
    }
}
