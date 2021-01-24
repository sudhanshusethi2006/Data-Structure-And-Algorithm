using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class GroupAnagrams
    {

        static void Main(string[] args)
        {
            //erertertert
        }


        public IList<IList<string>> GroupAnagrams1(string[] strs)
        {

            Dictionary<string, IList<string>> dd = new Dictionary<string, IList<string>>();
            foreach (string word in strs)
            {
                char[] arr = word.ToCharArray();
                Array.Sort(arr);
                string temp = new string(arr);

                if (dd.ContainsKey(temp))
                {
                    dd[temp].Add(word);
                }
                else
                {
                    dd[temp] = new List<string>() { word };
                }
            

            }

            IList<IList<string>> ans = new List<IList<string>>();
            foreach (IList<string> li in dd.Values)
            {
                ans.Add(li);
            }

            return ans;

        }

        public IList<int> FindAnagrams(string s, string p)
        {

            IList<int> ans = new List<int>();
            int ns = s.Length;
            int np = p.Length;

            Dictionary<char, int> pCount = p.GroupBy(x => x, (key, Value) => new { key = key, Value = Value.Count() }).ToDictionary(x => x.key, x => x.Value);

            Dictionary<char, int> sCount = new Dictionary<char, int>();


            for (int i = 0; i < ns; i++)
            {
                if (sCount.ContainsKey(s[i]))
                {
                    sCount[s[i]]++;
                }
                else
                {
                    sCount[s[i]] = 1;
                }


                if (i > np)
                {
                    if (sCount[s[i - np]] == 1)
                    {
                        sCount.Remove(s[i - np]);
                    }
                    else
                    {
                        sCount.Add(s[i - np], sCount[s[i - np]] - 1);
                    }
                }

                if (sCount.Equals(pCount))
                {
                    ans.Add(i - np + 1);
                }
            }



            return ans;


        }

    }
}
