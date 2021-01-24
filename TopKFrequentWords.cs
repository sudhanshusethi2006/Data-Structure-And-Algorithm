using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class TopKFrequentWords
    {
        static void Main(string[] args)


        {

            List<string> names = new List<string>() {"wwww", "aaaaa",  };//, "srishti", "sethi" };
            names.Sort((x, y) => {
               Console.WriteLine("value of x is {0} value of y is {1} and the the comare to answer is {2}", x, y, x.CompareTo(y));
              //  return x.CompareTo(y);

                return  x.CompareTo(y);
            });
            string[] arr2 = new string[] { "glarko", "zlfiwwb", "nsfspyox", "pwqvwmlgri", "qggx", "qrkgmliewc", "zskaqzwo", "zskaqzwo", "ijy", "htpvnmozay", "jqrlad", "ccjel", "qrkgmliewc", "qkjzgws", "fqizrrnmif", "jqrlad", "nbuorw", "qrkgmliewc", "htpvnmozay", "nftk", "glarko", "hdemkfr", "axyak", "hdemkfr", "nsfspyox", "nsfspyox", "qrkgmliewc", "nftk", "nftk", "ccjel", "qrkgmliewc", "ocgjsu", "ijy", "glarko", "nbuorw", "nsfspyox", "qkjzgws", "qkjzgws", "fqizrrnmif", "pwqvwmlgri", "nftk", "qrkgmliewc", "jqrlad", "nftk", "zskaqzwo", "glarko", "nsfspyox", "zlfiwwb", "hwlvqgkdbo", "htpvnmozay", "nsfspyox", "zskaqzwo", "htpvnmozay", "zskaqzwo", "nbuorw", "qkjzgws", "zlfiwwb", "pwqvwmlgri", "zskaqzwo", "qengse", "glarko", "qkjzgws", "pwqvwmlgri", "fqizrrnmif", "nbuorw", "nftk", "ijy", "hdemkfr", "nftk", "qkjzgws", "jqrlad", "nftk", "ccjel", "qggx", "ijy", "qengse", "nftk", "htpvnmozay", "qengse", "eonrg", "qengse", "fqizrrnmif", "hwlvqgkdbo", "qengse", "qengse", "qggx", "qkjzgws", "qggx", "pwqvwmlgri", "htpvnmozay", "qrkgmliewc", "qengse", "fqizrrnmif", "qkjzgws", "qengse", "nftk", "htpvnmozay", "qggx", "zlfiwwb", "bwp", "ocgjsu", "qrkgmliewc", "ccjel", "hdemkfr", "nsfspyox", "hdemkfr", "qggx", "zlfiwwb", "nsfspyox", "ijy", "qkjzgws", "fqizrrnmif", "qkjzgws", "qrkgmliewc", "glarko", "hdemkfr", "pwqvwmlgri" };
            string[] arr = new string[] { "sudhanshu", "is", "sudhanshu", "is", "and", "and", "sudhanshu"};

            int k = 14;
            IList<string> ans = TopKFrequent(arr, k);
        }


        public static IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> dd = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (dd.ContainsKey(word))
                {
                    dd[word]++;
                }
                else
                {
                    dd.Add(word, 1);
                }
            }

         //   dd = dd.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            List<KeyValuePair<string, int>> tempList = dd.ToList();

            tempList.Sort((x, y) =>
            {

                Console.WriteLine("value of x is {0} value of y is {1} and the the comare to answer is {2} and Differene value is {3}", x, y, x.Key.CompareTo(y.Key), y.Value - x.Value);
                return x.Value == y.Value ? x.Key.CompareTo(y.Key) : y.Value - x.Value;
                //if (x.Value == y.Value)
                //{
                //    return x.Key.CompareTo(y.Key);
                //}

                //return 0;
                //else
                //{
                //    return x.Value > y.Value ? x.Value : y.Value;
                //}

            });

            List<string> ans = tempList.Take(k).Select(x => x.Key).ToList();

            return ans;


        }
    }



}
