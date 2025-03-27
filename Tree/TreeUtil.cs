using System.Collections.Generic;
using System;

namespace Tree
{
    public static class TreeUtil
    {
        public static void BFS<T>(BinaryTreeNode<T> start)
        {
            // create a queue
            // add root to q
            // dequeue and operate
            // add other nodes to q
            // dequeue and operate

            Queue<BinaryTreeNode<T>> q = new Queue<BinaryTreeNode<T>>();
            q.Enqueue(start);

            while (q.Count > 0)
            {
                var cur = q.Dequeue();

                Console.WriteLine(cur.Data);
                if (cur.Left != null) q.Enqueue(cur.Left);
                if (cur.Right != null) q.Enqueue(cur.Right);
            }
        }

        // current, left, right
        public static void PreOrderDFS<T>(BinaryTreeNode<T> start)
        {
            if (start == null) return;

            Console.WriteLine(start.Data);
            PreOrderDFS(start.Left);
            PreOrderDFS<T>(start.Right);
        }

        // left, current, right
        public static void InOrderDFS<T>(BinaryTreeNode<T> start)
        {
            if (start == null) return;

            InOrderDFS(start.Left);
            Console.WriteLine(start.Data);
            InOrderDFS(start.Right);
        }

        // left, right, current
        public static void PostOrderDFS<T>(BinaryTreeNode<T> start)
        {
            if (start == null) return;

            PostOrderDFS(start.Left);
            PostOrderDFS(start.Right);
            Console.WriteLine(start.Data);
        }

        public static void Insert<T>(BinaryTreeNode<T> start, T value)
        {
            // move through tree until find an empty child node
            Queue<BinaryTreeNode<T>> q = new Queue<BinaryTreeNode<T>>();
            q.Enqueue(start);

            while (q.Count > 0)
            {
                var cur = q.Dequeue();

                if (cur.Left == null)
                {
                    cur.Left = new BinaryTreeNode<T>(value);
                    break;
                } else if (cur.Right == null)
                {
                    cur.Right = new BinaryTreeNode<T>(value);
                    break;
                }

                q.Enqueue(cur.Left);
                q.Enqueue(cur.Right);
            }
        }

        public static void Delete<T>(BinaryTreeNode<T> start, T value)
        {
            // find position of target
            // find position of last node
            // swap
            // delete last node

            var target = start;

            Queue<BinaryTreeNode<T>> q = new Queue<BinaryTreeNode<T>>();
            q.Enqueue(start);

            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                if(cur.Data.Equals(value))
                {
                    target = cur;
                    break;
                }

                if (cur.Left != null) q.Enqueue(cur.Left);
                if (cur.Right != null) q.Enqueue(cur.Right);
            }

            q.Clear();
            q.Enqueue(start);
            BinaryTreeNode<T> lastParent = null;
            BinaryTreeNode<T> lastNode = null;

            while (q.Count > 0)
            {
                var cur = q.Dequeue();

                if (cur.Left != null)
                {
                    lastNode = cur.Left;
                    lastParent = cur;
                    q.Enqueue(cur.Left);
                }
                if (cur.Right != null)
                {
                    lastNode = cur.Right;
                    lastParent = cur;
                    q.Enqueue(cur.Right);
                }
            }

            target.Data = lastNode.Data;
            if (lastParent.Right != null) lastParent.Right = null;
            else lastParent.Left = null;
        }
    }
}
