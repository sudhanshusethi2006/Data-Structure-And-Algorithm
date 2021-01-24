using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class FibonacciSeries
    {
        public int fibonacciSeries( int n)
        {

            if (n == 0 || n == 1) return n;
            return fibonacciSeries(n - 1) + fibonacciSeries(n - 2);
        }
        static void Main(string[] args)
        {
            FibonacciSeries OBJ = new FibonacciSeries();
            int ans = OBJ.fibonacciSeries(4);
            ans = OBJ.fib(4);

            memorizationArray = new int[4];
            for (int i = 0; i < 4; i++)
            {
                memorizationArray[i] = -1;
            }
                ans = OBJ.fibonacciByMemoization(4);
        }

        public int fib(int n)
        {
            int t1 = 0; int t2 = 1;
            int ans=0;
            if (n == 0 || n == 1) return 1;
            for (int i = 2; i <= n; i++)
            {
                ans = t1 + t2;
                t1 = t2;
                t2 = ans;

            }

            return ans;
        }

      static  int[] memorizationArray;

        public int fibonacciByMemoization(int n)
        {
            if (n <= 1)
            {
                return n;

            }

            if (memorizationArray[n - 2] == -1)
            {
                memorizationArray[n - 2] = fibonacciByMemoization(n - 2);
            }
            if (memorizationArray[n - 1] == -1)
            {
                memorizationArray[n - 1] = fibonacciByMemoization(n - 1);
            }

            return memorizationArray[n - 2] + memorizationArray[n - 1];
        }
    }
}
