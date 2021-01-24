using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    delegate int MyDelegate(int x, int y);
    class DelegatesBasics
    {
        static void Main(string[] args)
        {
           // one way of calling of calling the method through delegate
            MyDelegate obj = new MyDelegate(sum);
            Console.WriteLine("output from simple delegate: {0}", obj(5, 6));
            // second of calling the method through delegate
            MyDelegate obj2 = sum;
            //for multicast delegate
            obj2 = obj2 + subtract;

            Console.WriteLine("output from multicast delegate (output of last method overrides the previous ones): {0}", obj2(5, 6));

            //Annonymous functions

            //here there is no need to creare a separate function 

            MyDelegate obj3 = delegate(int a, int b)
            {
                return a * b;
            };

            Console.WriteLine("output from Annonymous function: {0}", obj3(5, 6));

            // replacing a delegate with a lambda expression 
            //lambda expression is a short cut way of writing the anonymous methods

       MyDelegate obj4 = (a, b) => a * b;
            Console.WriteLine("output from lambda expression: {0}",obj4(5,6));
        }
        static int sum(int a, int b)
        {
            return a + b;
        }


        static int subtract(int a, int b)
        {
            return a - b;
        }





    }



}
