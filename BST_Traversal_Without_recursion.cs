using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class BST_Traversal_Without_recursion
    {
        static void Main(string[] args)
        {
            BinarySearchTree obj = new BinarySearchTree();
            obj.Insert(12);
            obj.Insert(11);
            obj.Insert(10);
            obj.Insert(14);
            obj.Insert(19);
            obj.Insert(15);
            obj.Insert(13);

            obj.InorderTraversal_BestAproach();

            int[] j = new int[3];
            Array.Reverse(j);

        }
    }

    public class BinarySearchTree
    {
        private Node Root;
        // BST traversal through recursion
        public void InorderTraversal()
        {


            List<int> ans = new List<int>();
            Stack<Node> myStack = new Stack<Node>();

            Node temp = Root;
            while (temp != null)
            {
                myStack.Push(temp);
                temp = temp.Leftchild;
            }
            while (myStack.Count > 0)
            {
                Node a = myStack.Pop();

                ans.Add(a.value);
                Console.WriteLine(a.value + " ");
                a = a.Rightchild;
                while (a != null)
                {
                    myStack.Push(a);
                    a = a.Leftchild;
                }
            }


        }


        public void InorderTraversal_BestAproach()
        {


            List<int> ans = new List<int>();
            Stack<Node> myStack = new Stack<Node>();

            Node temp = Root;
            while (temp != null || myStack.Count > 0)
            {
                if (temp != null)
                {
                    if (temp.Leftchild == null)
                    {
                        ans.Add(temp.value);
                        if (temp.Rightchild == null)
                        {
                            temp = null;
                            continue;
                        }
                        else
                        {
                            temp = temp.Rightchild;
                            continue;
                        }
                    }
                    else
                    {
                        myStack.Push(temp);
                        temp = temp.Leftchild;
                        continue;
                    }
                    
                }
                else
                {
                    temp = myStack.Pop();
                    ans.Add(temp.value);
                    if (temp.Rightchild == null)
                    {
                        temp = null;
                        continue;
                    }
                    else
                    {
                        temp = temp.Rightchild;
                        continue;
                    }

                }

            }


            foreach (int i in ans)
            {
                Console.Write(i + " ");
            }



        }

        public void PreOrder()
        {

        }


        public void PostOrder()
        {


        }

        public Node getTree()
        {
            return this.Root;
        }
        public void Insert(int value)
        {
            Node obj = new Node(value);
            if (Root == null)
            {
                Root = obj;
            }
            else
            {
                Node temp = Root;
                //        Node CurrentParent;

                while (true)
                {

                    if (value < temp.value)
                    {

                        if (temp.Leftchild == null)
                        {
                            temp.Leftchild = obj;
                            return;
                        }
                        else
                        {
                            temp = temp.Leftchild;
                        }

                    }
                    else
                    {

                        if (temp.Rightchild == null)
                        {
                            temp.Rightchild = obj;
                            return;
                        }
                        else
                        {
                            temp = temp.Rightchild;
                        }

                    }

                }


                //while (true)
                //{
                //    CurrentParent = temp;
                //    if (value < temp.value)
                //    {
                //        temp = temp.Leftchild;
                //        if (temp == null)
                //        {
                //            CurrentParent.Leftchild = obj;
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        temp = temp.Rightchild;
                //        if (temp == null)
                //        {
                //            CurrentParent.Rightchild = obj;
                //            return;
                //        }
                //    }

                //}
            }
        }
    }


}
