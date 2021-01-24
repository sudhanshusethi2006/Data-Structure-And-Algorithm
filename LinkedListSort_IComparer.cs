using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class LinkedListSort_IComparer
    {

        static void Main(string[] args)
        {
            List<int> stringList = new List<int>();
            stringList.Add(12);
            stringList.Add(24);
            stringList.Add(24);
            stringList.Add(24);
            stringList.Add(13);
            stringList.Add(13);
            stringList.Add(100);

            //stringList.Sort((log1, log2) => {
            //    Console.WriteLine(log1);
            //    Console.WriteLine(log2);
            //    return 1;
            //});

            //var dd = stringList.GroupBy(x => x, (key,value)=> new {value=value.Count()} ).ToArray();

            //stringList.Sort((x, y) =>
            //{
            //    int result = x.CompareTo(y);
            //    return result;
            //});


            int[] numbers = { 10, 15, 20, 25, 30, 35 };

            var result = numbers.GroupBy(n => (n % 10 == 0));

           Console.WriteLine("GroupBy has created two groups:");
            foreach (IGrouping<bool, int> group in result)
            {
                if (group.Key == true)
                    Console.WriteLine("Divisible by 10");
                else
                    Console.WriteLine("Not Divisible by 10");

                foreach (int number in group)
                    Console.WriteLine(number);
            }

        }
    }
}
