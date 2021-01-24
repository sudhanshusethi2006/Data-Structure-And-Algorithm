using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    public class LRUCache
    {
        static void Main(string[] args)
        {
            LRUCacheRun lc = new LRUCacheRun(1);

            lc.Put(2, 1);
            int ans = lc.Get(2);
            lc.Put(3, 2);
            int ans2 = lc.Get(2);
            int ans3 = lc.Get(3);
            //lc.Put(3, 3);
          
            //lc.Put(4, 4);
            //int ans3 = lc.Get(1);
            //int ans4 = lc.Get(3);
            //int ans5 = lc.Get(4);



        }
    }
    public class LRUCacheRun
    {

        public int maxSize;

        int CurrentSize = 0;
        Dictionary<int, Node> cache = new Dictionary<int, Node>();
        DoublyLinkedList dbl = new DoublyLinkedList();


        public LRUCacheRun(int capacity)
        {
            this.maxSize = maxSize > 1 ? maxSize : 1;
        }

        public int Get(int key)
        {


            //  Console.WriteLine(cache.Count());
            if (!cache.ContainsKey(key)) return -1;

            updateMostRecent(cache[key]);

            return cache[key].value;

        }


        public void DeleteLeastRecent()
        {
            int key = dbl.tail.key;
            dbl.DeleteTail();

            cache.Remove(key);

        }

        public void Put(int key, int value)
        {
            if (!cache.ContainsKey(key))
            {

                if (CurrentSize == maxSize)
                {
                    DeleteLeastRecent();
                }

                else
                {
                    CurrentSize++;
                }
                //      Console.WriteLine(" Adding value : " + key);
                cache.Add(key, new Node(key, value));
            }
            else
            {
                ReplaceValue(key, value);
            }

            updateMostRecent(cache[key]);
        }

        public void ReplaceValue(int key, int value)
        {
            cache[key].value = value;
        }


        public void updateMostRecent(Node node)
        {
            dbl.InsertInFront(node);

        }



        public class DoublyLinkedList
        {

            public Node head;
            public Node tail;


            public void InsertInFront(Node node)
            {

                if (head == node) return;
                else if (head == null)
                {
                    head = node;
                    tail = node;
                }


                else if (head == tail)
                {
                    node.next = head;
                    head.prev = node;
                    head = node;
                }

                else
                {
                    if (node == tail)
                    {
                        DeleteTail();
                    }
                    else
                    {
                        if (node.prev != null) node.prev.next = node.next;
                        if (node.next != null) node.next.prev = node.prev;

                        node.next = null;
                        node.prev = null;
                    }

                    node.next = head;
                    head.prev = node;
                    head = node;
                }
            }



            public void DeleteTail()
            {
                if (tail == head)
                {
                    tail = null;
                    head = null;
                }

                if (tail == null)
                {
                    return;
                }
                else
                {
                    tail = tail.prev;
                    tail.next = null;
                }
            }




        }


        public class Node
        {
            public Node prev;
            public Node next;
            public int key;
            public int value;


            public Node(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }






}
