
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace LeetCodePractice
{


    public class circularQueue
    {
        static void Main(string[] args)
        {
            MyCircularQueue obj = new MyCircularQueue(3);
            bool param_1 = obj.EnQueue(7);
            bool param_7 = obj.DeQueue();
            int front1 = obj.Front();
            bool param_8 = obj.DeQueue();
            int front2 = obj.Front();
            int rear = obj.Rear();
            bool param_2 = obj.EnQueue(0);
            bool isfull = obj.IsFull();
            bool param_9 = obj.DeQueue();
            int rear2 = obj.Rear();
            bool param_10 = obj.EnQueue(3);
        }
        public class MyCircularQueue
        {

            public MyCircularQueue(int x, int z)
            {
                int s = x + z;
            }

            /** Initialize your data structure here. Set the size of the queue to be k. */
            int[] queue;

            int size;
            int front = 0;
            int rear = 0;

            public MyCircularQueue(int k)
            {
                size = k;
                queue = new int[k];
            }

            /** Insert an element into the circular queue. Return true if the operation is successful. */
            public bool EnQueue(int value)
            {
                if (size == rear) return false;
                else
                {
                    queue[rear] = value;
                    rear++;
                    return true;
                }

            }

            /** Delete an element from the circular queue. Return true if the operation is successful. */
            public bool DeQueue()
            {
                if (front == rear)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < rear - 1; i++)
                    {
                        queue[i] = queue[i + 1];

                    }

                    rear--;
                    queue[rear] = -1;
                    return true;
                }
            }

            /** Get the front item from the queue. */
            public int Front()
            {
                return queue[front];
            }

            /** Get the last item from the queue. */
            public int Rear()
            {
                return rear > 0 ? queue[rear - 1] : queue[rear];
            
            }

            /** Checks whether the circular queue is empty or not. */
            public bool IsEmpty()
            {
                return front == rear;
            }

            /** Checks whether the circular queue is full or not. */
            public bool IsFull()
            {
                return size == rear;
            }
        }



    }

}
