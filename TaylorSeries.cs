using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class TaylorSeries
    {

        static double p = 1; static double f = 1;

        public double taylorSeries(int x, int n)
        {
            if (n == 0) return 1;
            double r = taylorSeries(x, n - 1);
            p=p*x;
            f=f*n;
            return r + p / f; 
        }
        static void Main(string[] args)
        {
            TaylorSeries OBJ= new TaylorSeries();
            double ans = OBJ.taylorSeries(3,10);
             
        }

        static double s = 1;
        public double taylorSeries_Improved(int x, int n)
        {
            for (; n > 0; n--)
            {
                s = 1 + x / n * s;
            }

            return s;
        }

        public double taylorSeries_ImprovedRecursive(int x, int n)
        {
            if (n == 0) return s;
            s = 1 + x / n * s;
            return taylorSeries_ImprovedRecursive(x, n - 1);
        }


    }



}
