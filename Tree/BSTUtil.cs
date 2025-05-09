using System;
using System.Collections.Generic;

namespace Tree
{
    public static class BSTUtil
    {
        public static BinarySearchTreeNode Insert(BinarySearchTreeNode root, int value)
        {
            // if value greater than current go right
            // else go left
            if (root == null) return new BinarySearchTreeNode(value);

            if (root.Value > value)
            {
                root.Left = Insert(root.Left, value);
            }
            else if (root.Value < value)
            {
                root.Right = Insert(root.Right, value);
            }

            return root;
        }

        public static void BFS(BinarySearchTreeNode start)
        {
            // create a queue
            // add root to q
            // dequeue and operate
            // add other nodes to q
            // dequeue and operate

            Queue<BinarySearchTreeNode> q = new Queue<BinarySearchTreeNode>();
            q.Enqueue(start);

            while (q.Count > 0)
            {
                var cur = q.Dequeue();

                Console.WriteLine(cur.Value);
                if (cur.Left != null) q.Enqueue(cur.Left);
                if (cur.Right != null) q.Enqueue(cur.Right);
            }
        }

        public static bool Search(BinarySearchTreeNode start, int value)
        {
            if (start == null) return false;

            if (start.Value == value) return true;

            if(start.Value > value) return Search(start.Left, value);
            else return Search(start.Right, value);
        }
    }
}
