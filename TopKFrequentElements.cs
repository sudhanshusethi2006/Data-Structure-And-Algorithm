using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class TopKFrequentElements
    {
        static void Main(string[] args)
        {

            string s = "suddhanddshuddso";

            StringBuilder sb = new StringBuilder(s);
            
            string p = "dd";
            string r = new string('0', p.Length);
            List<int> ans1= new List<int>();
           
            while (sb.ToString().IndexOf(p) > 0)
            {
                int temp= sb.ToString().IndexOf(p);

                ans1.Add(temp);
              
                sb.Replace(p, r, temp, p.Length);
            }


            int[] nums = new int[9] {1,1,2,2,3,3,3,1,2};
            int k = 2;

            var dd = nums.GroupBy(X => X, (key, value) => new { key = key, value = value.Count() }).ToDictionary(x => x.key, x => x.value);
            dd = dd.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int[] ans = new int[k];
            int count = 0;
            foreach (int num in dd.Keys)
            {
                if (count < k)
                {
                    ans[count] = num;
                    count++;
                }
            }


            Dictionary<char, int> ddp = p.GroupBy(x => x, (key, Value) => new { key = key, Value = Value.Count() }).ToDictionary(x => x.key, x => x.Value);
      
            int[] arr = nums.GroupBy(x => x).OrderByDescending(x=>x.Count()).Select(x=>x.Key).Take(k).ToArray();
            
          //  int[] arr = nums.GroupBy(x => x).OrderByDescending(x => x.Count()).Take(k).Select(x => x.Key).ToArray();

            // return ans;
        }
    }
}
