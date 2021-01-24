using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{

    public class circularDeque
    {
        static void Main(string[] args)
        {

        }
    }
    public class MyCircularDeque
    {
        int[] dequeue; int size; int front = -1; int rear = -1;
      
     
        public MyCircularDeque(int k)
        {
            size = k;
            dequeue = new int[k];
        }

        /** Adds an item at the front of Deque. Return true if the operation is successful. */
        public bool InsertFront(int value)
        {
            if (IsFull()) return false;
            if (front == -1 && rear == -1)
            {
                front++;
                rear++;
            }
            else if (front == 0) front = size - 1;
            else front--;
            dequeue[front] = value;
            return true;
        }

        /** Adds an item at the rear of Deque. Return true if the operation is successful. */
        public bool InsertLast(int value)
        {
            if (IsFull()) return false;
            if (front == -1 && rear == -1)
            {
                front++;
                rear++;
            }
            else if (rear == size - 1) rear = 0;
            else rear++;
            dequeue[rear] = value;
            return true;
        }

        /** Deletes an item from the front of Deque. Return true if the operation is successful. */
        public bool DeleteFront()
        {
            if (IsEmpty()) return false;
            else if (front == rear) front = rear = -1;
            else if (front == size - 1) front = 0;
            else front++;
            return true;
        }

        /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
        public bool DeleteLast()
        {
            if (IsEmpty()) return false;
            else if (front == rear) front = rear = -1;
            else if (rear == 0) rear = size - 1;
            else rear--;
            return true;
        }

        /** Get the front item from the deque. */
        public int GetFront()
        {
            if (front > -1) return dequeue[front];
            else return -1;
        }

        /** Get the last item from the deque. */
        public int GetRear()
        {
            if (rear > -1) return dequeue[rear];
            else return -1;
        }

        /** Checks whether the circular deque is empty or not. */
        public bool IsEmpty()
        {
            if (front == -1 && rear == -1) return true;
            return false;
        }

        /** Checks whether the circular deque is full or not. */
        public bool IsFull()
        {
            if ((front == 0 && rear == size - 1) || front == rear + 1) return true;
            return false;
        }
    }

}
