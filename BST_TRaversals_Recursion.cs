using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class BST_TRaversals_Recursion
    {
        BST obj = new BST();
        static void Main(string[] args)
        {
            BST obj = new BST();
            obj.Insert(12);
            obj.Insert(11);
            obj.Insert(10);
            obj.Insert(14);
            obj.Insert(19);
            obj.Insert(15);
            obj.Insert(13);

   
      
            Node head = obj.getTree();
            Console.WriteLine("Inorder-----");
            obj.InorderTraversal(head);
            Console.WriteLine();
            Console.WriteLine("PreOrder-----");
            Console.WriteLine();
            obj.PreOrder(head);
            Console.WriteLine();
            Console.WriteLine("PostOrder-----");
            obj.PostOrder(head);
        }
    }


    public class BST
    {
        private Node Root;
        // BST traversal through recursion
        public void InorderTraversal(Node temp)
        {
            if (temp == null) { return; }
            InorderTraversal(temp.Leftchild);
            Console.Write(temp.value + " , ");
            InorderTraversal(temp.Rightchild);
            
        }

        public IList<int> InorderTraversalRecursive(IList<int> ans, Node root)
        {
            if (root == null) { return null; }

            InorderTraversalRecursive(ans, root.Leftchild);
            ans.Add(root.value);
            InorderTraversalRecursive(ans, root.Rightchild);
            return ans;
        }

        public void PreOrder(Node temp)
        {
            if (temp == null) { return; }
            Console.Write(temp.value + "  ");
            PreOrder(temp.Leftchild);
            PreOrder(temp.Rightchild);
        }


        public void PostOrder(Node temp)
        {
            if (temp == null) { return; }
            PostOrder(temp.Leftchild);
            PostOrder(temp.Rightchild);
            Console.Write(temp.value + " , ");

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

    public class Node
    {
       // public int key;
        public int value;
        public Node Leftchild, Rightchild;
        public Node( int value)
        {
           // this.key = key;
            this.value = value;
        }

    }
}
