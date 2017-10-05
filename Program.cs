using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Post_In_Pre
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] treeArray = new int[]{9,4,1,5,12,11,10,15,2,3}; //欲要轉換的陣列
            while (true)
            {
                BinarySearchTree bst = new BinarySearchTree(); 
                for (int i = 0; i < treeArray.Length; i++)
                {
                    bst.InsertVertex(treeArray[i]);
                }
                if (!bst.isBSTEmpty())
                {
                    Console.WriteLine();
                    Console.Write("PreOrder : ");
                    bst.PreOrder(bst.root);
                    Console.WriteLine();
                    Console.Write("InOrder : ");
                    bst.InOrder(bst.root);
                    Console.WriteLine();
                    Console.Write("PostOrder : ");
                    bst.PostOrder(bst.root);
                    Console.WriteLine();
                    Console.Write("BFS : ");
                    bst.BFS(bst.root);
                    Console.WriteLine();
                    Console.Write("DFS : ");
                    bst.DFS(bst.root);
                    Console.WriteLine();
                }
                string key = Console.ReadLine();
            }
        }


        class TreeNode
        {
            public int parent;
            public TreeNode left, right;
            public TreeNode(int data)
            {
                parent = data;
                left = null; right = null;
            }
        }

        class BinarySearchTree
        {
            public TreeNode root;
            public BinarySearchTree() { root = null; }
            public bool isBSTEmpty() 
            {
                if (root == null) return true;
                else return false;
            }

            public void InsertVertex(int data)
            {
                if (root == null)
                {
                    root = new TreeNode(data);
                    return;
                }
                TreeNode current = this.root;
                while (true)
                {
                    if (data < current.parent) 
                    {
                        if (current.left == null)
                        {
                            current.left = new TreeNode(data);
                            return;
                        }
                        else { current = current.left; }
                    }
                    else
                    {
                        if (current.right == null)
                        {
                            current.right = new TreeNode(data);
                            return;
                        }
                        else { current = current.right; }
                    }
                }
            }

            public void PreOrder(TreeNode treenode)
            {
                if (treenode != null)
                {
                    Console.Write(string.Format("[{0}]", treenode.parent));
                    PreOrder(treenode.left);
                    PreOrder(treenode.right);
                }
            }

            public void InOrder(TreeNode treenode)
            {
                if (treenode != null)
                {
                    InOrder(treenode.left);
                    Console.Write(string.Format("[{0}]", treenode.parent));
                    InOrder(treenode.right);
                }
            }

            public void PostOrder(TreeNode treenode)
            {
                if (treenode != null)
                {
                    PostOrder(treenode.left);
                    PostOrder(treenode.right);
                    Console.Write(string.Format("[{0}]", treenode.parent));
                }
            }

            public void BFS(TreeNode treenode)
            {
                if (treenode != null)
                {
                    Queue<TreeNode> queue = new Queue<TreeNode>();
                    queue.Enqueue(treenode);
                    while (queue.Count != 0)
                    {
                        TreeNode current = queue.Dequeue();
                        Console.Write(string.Format("[{0}]", current.parent));
                        if (current.left != null) queue.Enqueue(current.left);
                        if (current.right != null) queue.Enqueue(current.right);
                    }
                }
            }

            public void DFS(TreeNode treenode)
            {
                if (treenode != null)
                {
                    Stack<TreeNode> stack = new Stack<TreeNode>();
                    stack.Push(treenode);
                    while (stack.Count != 0)
                    {
                        TreeNode current = stack.Pop();
                        Console.Write(string.Format("[{0}]", current.parent));
                        if (current.right != null) stack.Push(current.right);
                        if (current.left != null) stack.Push(current.left);
                    }
                }
            }
        }
    }
}
