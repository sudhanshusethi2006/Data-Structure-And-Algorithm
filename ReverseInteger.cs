using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class ReverseInteger
    {

        static void Main(string[] args)
        {

            for (int i = 1; i < 10; ++i)
            {
                Console.WriteLine(i);
            }

            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            int j = 1;
            Console.WriteLine(j++);

            int k = 1;
            Console.WriteLine(++k);
            int x = 55698;
            int res = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x = x / 10;
                if (res > int.MaxValue / 10 || res < int.MinValue / 10) { res = 0; break; }
                res = 10 * res + pop;
            };

            Console.WriteLine(res);
        }

    }
}
