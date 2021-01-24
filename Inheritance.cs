using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{

    class myinterface1
    {

        public myinterface1()
        {
            Console.WriteLine("daddy constructor");
        }


        public myinterface1(int j)
        {
            Console.WriteLine("daddy constructor"+ j);
        }
        
        

    }
    abstract class figue : myinterface1
    {
      
        public figue()
        {
            Console.WriteLine("figure constructor");
        }

        public figue(int i)
        {
            Console.WriteLine("figure constructor" + i);
        }
        public abstract double area(double heigth, double width);
        public double area1(double heigth, double width)
        {
            return 0;
        }

    }
    class Inheritance : figue
    {

    
        public Inheritance(int height, int width) : base(2)
        {

            Console.WriteLine("inheritance constructor");
        }

    
 


        public override double area(double heigth, double width)
        {
            return 0;
        }
    }

    class MainClass
    {
        static void Main(string[] args)
        {
            Inheritance obj = new Inheritance(2,1);
        }
    }


   
}
