using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class eightHousesProblem
    {

        static void Main(string[] args)
        {
            int[] blocks = new int[] { 0, 1, 0, 1, 0, 1, 0, 1 };
       //     int[] temp = cellCompete(blocks, 2);

            int[] temp2 = cellCompete_2(blocks, 3);
        }




        //METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public static int[] cellCompete(int[] states, int days)
        {
            // if the number of cells is not equals to 8 
            // or number of days is less than 1
            if (states.Length != 8 || days < 1)
            {
                return states;
            }

            // local variables
            int index, previousValue, nextValue;

            // loop for each day
            for (int i = 0; i < days; i++)
            {
                // index of current cell
                index = 0;
                // value of the previous cell
                previousValue = 0;
                // value of the next cell
                nextValue = 0;

                // loop for each cell in the array 
                while (index < states.Length)
                {
                    // if the current index is not last index of the given array,
                    // set the value of nextValue, else it would remain 0.
                    if (index < states.Length - 1)
                    {
                        nextValue = states[index + 1];
                    }
                    else if (index == states.Length - 1)
                    {
                        nextValue = 0;
                    }

                    // if nextValue is same as previousValue
                    if (nextValue == previousValue)
                    {
                        // save the current index value for next iteration of loop
                        previousValue = states[index];
                        // set current index value
                        states[index] = 0;
                    }
                    else
                    {
                        // save the current index value for next iteration of loop
                        previousValue = states[index];
                        // set current index value
                        states[index] = 1;
                    }

                    // next item in the loop
                    index++;
                }
            }

            // return states array
            return states;

            // INSERT YOUR CODE HERE
        }

        public static int[] cellCompete_2(int[] states, int days)
        { 
            int len= states.Length;
            int[] temp = new int[len];
          
            for (int j = 1; j <= days; j++)
            {
                int index = 0;
                while(index<len)
                {
                    if (index == 0 )
                    {
                        
                        if (states[index + 1] == 0)
                        {
                            temp[index] = 0;
                        }

                        else
                        {
                            temp[index] = 1;
                        }
                      
                    }

                    else   if (index == len - 1)
                    {
                        if (states[index - 1] == 0)
                        {
                            temp[index] = 0;
                        }

                        else
                        {
                            temp[index] = 1;
                        }
                    }
                    else
                    {
                        if (states[index - 1] == states[index + 1])
                        {
                            temp[index] = 0;
                        }
                        else
                        {
                            temp[index] = 1;
                        }
                    
                        
                    }
                    index++;
                }

                states = temp;
                //for (int i = 0; i < len; i++)
                //{
                //    states[i] = temp[i];
                //}
                temp = new int[len];

            }

            return states;
        }

    }

}
        // METHOD SIGNATURE ENDS
   
