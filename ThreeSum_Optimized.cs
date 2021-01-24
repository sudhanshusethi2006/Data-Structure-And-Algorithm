using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class ThreeSum_Optimized
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };

            IList<IList<int>> ans = ThreeSum2(nums);

        }



        public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
        {
            // Write your code here.
            List<int[]> ans = new List<int[]>();

            for (int i = 0; i < array.Length - 2; i++)
            {
                for (int j = i + 1; j < array.Length - 1; j++)
                {
                    for (int k = j + 1; k < array.Length; k++)
                    {
                        if (array[i] + array[j] + array[k] == targetSum)
                        {

                            int[] arr = new int[] { array[i], array[j], array[k] };
                            Array.Sort(arr);
                            ans.Add(arr);
                        }
                    }
                }
            }


            ans.Sort((x, y) =>
            {

                if (x[0] == y[0])
                {
                    return x[1].CompareTo(y[1]);
                }

                if (x[1] == y[1] && x[0] == y[0])
                {
                    return x[2].CompareTo(y[2]);
                }
                else
                {
                    return x[0].CompareTo(y[0]);
                }


            });

            return ans;
        }

        public static IList<IList<int>> ThreeSum2(int[] nums)
        {
            //  HashSet<Triplets> myHashSet= new HashSet<Triplets>();
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(nums);
            int targetSum = 0;

            for (int curr = 0; curr < nums.Length - 2; curr++)
            {

                if (curr == 0 || nums[curr] != nums[curr - 1])
                {
                    int left = curr + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {

                        int tempSum = nums[curr] + nums[left] + nums[right];
                        if (tempSum == targetSum)
                        {
                            // int[] arr= new int[] {array[curr], array[left] , array[right]  }
                            IList<int> temp = new List<int> { nums[curr], nums[left], nums[right] };


                            //   bool contains = ans.Any(x => x[0].Equals(temp[0]) && x[1].Equals(temp[1]) && x[2].Equals(temp[2]) );


                            //	ans.Add(new int[] {array[curr], array[left] , array[right] });
                            //   if (!contains)
                            //   {
                            ans.Add(new List<int>() { nums[curr], nums[left], nums[right] });

                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;

                            //  }

                            left++;
                            right--;
                        }

                        else if (tempSum < targetSum)
                        {
                            left++;
                        }

                        else
                        {
                            right--;
                        }
                    }


                }
            }


            return ans;
        }



        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            HashSet<Triplets> myHashSet = new HashSet<Triplets>();
            IList<IList<int>> ans = new List<IList<int>>();
            Dictionary<int, List<Couples>> myDictionary = new Dictionary<int, List<Couples>>();
            //bruteforce
            //         for(int i=0;i<nums.Length-2;i++){
            //             for(int j=i+1;j<nums.Length-1;j++){
            //                 for(int k=j+1; k<nums.Length;k++){
            //                     if((nums[i] + nums [j] + nums[k])==0){
            //                         List<int> tempList= new List<int>();

            //                         Triplets obj= new Triplets(nums[i],nums[j],nums[k]);

            //                         if(!myHashSet.Contains(obj)){
            //                             myHashSet.Add(obj);
            //                         }

            //                     }
            //                 }
            //             }
            //         }


            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int sum = nums[i] + nums[j];

                    if (!myDictionary.ContainsKey(sum))
                    {
                        List<Couples> l = new List<Couples>();
                        l.Add(new Couples(i, j));
                        myDictionary.Add(sum, l);

                    }
                    else
                    {
                        List<Couples> l = myDictionary[sum];
                        l.Add(new Couples(i, j));
                    }

                }
            }

            foreach (int key in myDictionary.Keys)
            {
                int targetNumber = 0 - key;
                if (!nums.Contains(targetNumber)) continue;
                int index_targetNumber = Array.IndexOf(nums, targetNumber);

                List<Couples> CurrCouple = myDictionary[key];

                foreach (Couples c in CurrCouple)
                {
                    if (index_targetNumber == c.a || index_targetNumber == c.b) { continue; }
                    Triplets obj = new Triplets(nums[c.a], nums[c.b], targetNumber);

                    if (!myHashSet.Contains(obj))
                    {
                        myHashSet.Add(obj);
                    }
                }

            }




            foreach (Triplets t in myHashSet)
            {
                IList<int> tempList = new List<int>();
                tempList.Add(t.a);
                tempList.Add(t.b);
                tempList.Add(t.c);
                ans.Add(tempList);
            }

            return ans;
        }

        class Couples
        {
            public int a, b;
            public Couples(int a, int b)
            {
                this.a = a;
                this.b = b;
            }

            public override bool Equals(Object o)
            {
                Couples c = (Couples)o;
                return a == c.a || a == c.b || b == c.a || b == c.b;
            }

            public override int GetHashCode()
            {
                return 0;
            }
        }

        class Triplets
        {
            public int a, b, c;

            public Triplets(int a, int b, int c)
            {
                int[] arr = new int[3];
                arr[0] = a;
                arr[1] = b;
                arr[2] = c;
                Array.Sort(arr);
                this.a = arr[0];
                this.b = arr[1];
                this.c = arr[2];
            }

            public override bool Equals(Object o)
            {
                Triplets t = (Triplets)o;
                return t.a == a && t.b == b && t.c == c;
            }
            public override int GetHashCode()
            {
                return 0;
            }


        }
    }
}
