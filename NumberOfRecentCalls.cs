 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class NumberOfRecentCalls
    {

        static void Main(string[] args)
        {

            int[] arr = new int[] { 642, 1849, 1900, 4899, 4921, 5936, 5957, 7922 };
            RecentCounter obj = new RecentCounter();
            foreach (int i in arr)
            {
                int ans = obj.Ping(i);
                Console.Write(ans + " ");
            }
        }



    }


    	


    public class RecentCounter
    {
        class node
        {
            public node next;
            public int data;
            public node(int data)
            {
                this.data = data;
            }
        }
        public RecentCounter()
        {

        }
        node head;
        node tail;
        int ans;

        public int Ping(int t)
        {

            if (head == null)
            {
                head = new node(t);
                tail = head;
                ans = 1;
                return ans;



            }

            if (t - tail.data <= 3000)
            {
                node obj = new node(t);
                obj.next = head;
                head = obj;
                ans++;
                return ans;
            }

            if (t - head.data > 3000)
            {
                head = new node(t);
                tail = head;
                ans = 1;
                return ans;
            }

            node temp = head;
            ans = 1;
            while (temp.next.data >= t - 3000)
            {
                ans++;
                temp = temp.next;
            }

            temp.next = null;
            tail = temp;
            node newobj = new node(t);
            newobj.next = head;
            head = newobj;
            ans++;
            return ans;
        }


        //class node
        //{
        //   public int val;
        //   public node next;
        //    public node(int val)
        //    {
        //        this.val = val;
        //    }
        //}


        //node head;
        //node tail;
        //int size = 0;


        //public RecentCounter()
        //{

        //}

        //public int Ping(int t) {

        //    if (head == null || t - head.val > 3000)
        //    {
        //        head = new node(t);
        //        tail = head;
        //        size = 1;
        //        return 1;
        //    }

        //    if (t - tail.val <= 3000)
        //    {
        //        node obj = new node(t);
        //        obj.next = head;
        //        head = obj;
        //        size++;
        //        return size;
        //    }

        //    node temp = head;
        //    size = 1;

        //    while (t - temp.next.val <= 3000)
        //    {
        //        size++;
        //        temp = temp.next;
        //    }


        //    temp.next = null;

        //    tail = temp;
        //    node temp2 = new node(t);
        //    temp2.next = head;
        //    head = temp2;
        //    size++;
        //    return size;
        //}

        //Queue<int> myQueue; 

        //public RecentCounter()
        //{
        //    myQueue = new Queue<int>();
        //}
        //int size = 0;
        //int head = 0;
        //public int Ping(int t)
        //{
        //    if (myQueue.Count == 0)
        //    {
        //        myQueue.Enqueue(t);
        //        size++;
        //        head = t;
        //        return 1;
        //    }

        //    else if (t - myQueue.Peek() <= 3000)
        //    {
        //        head = t;
        //        myQueue.Enqueue(t);
        //        size++;
        //        return size;
        //    }


        //    else if (t - head > 3000)
        //    {
        //        myQueue = new Queue<int>();
        //        myQueue.Enqueue(t);
        //        size = 1;
        //        head = t;
        //        return 1;
        //    }

        //    size = 1;
        //    int pos = 0;
        //    for (int i = myQueue.Count - 1; i >= 0; i--)
        //    {
        //        if (t - 3000 <= myQueue.ElementAt(i))
        //        {
        //            size++;
        //            pos++;
        //        }
        //        else
        //        {
        //            break;
        //        }


        //    }

        //    for (int i = 0; i < myQueue.Count-pos; i++)
        //    {
        //        myQueue.Dequeue();
        //    }
        //        myQueue.Enqueue(t);
        //    head = t;

        //    return size;




        //}
    }

}