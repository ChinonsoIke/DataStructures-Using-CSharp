using System;
using System.Collections.Generic;

namespace Graph
{
    public class MultipurposeGraph<T>
    {
        public int[,] AdjMatrix { get; set; }
        public T[] Nodes { get; set; }
        public int Size { get; set; }

        public MultipurposeGraph(int size)
        {
            AdjMatrix = new int[size,size];
            Nodes = new T[size];
            Size = size;
        }

        public void AddNodeData(T node, int index)
        {
            Nodes[index] = node;
        }

        public void AddEdge(int index1,  int index2, bool directed = true, int weight = 1)
        {
            AdjMatrix[index1, index2] = weight;
            if(!directed) AdjMatrix[index2, index1] = weight;
        }

        public void PrintMatrix()
        {
            Console.WriteLine("Adjacency Matrix:");
            for (int i = 0; i < AdjMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < AdjMatrix.GetLength(1); j++)
                {
                    Console.Write(AdjMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }
            int k = 0;
            Console.WriteLine("\nNodes:");
            foreach (var item in Nodes)
            {
                Console.WriteLine($"Node {k}: {item}");
                k++;
            }
        }

        public void DFSUtil(int startIndex, bool[] visited)
        {
            visited[startIndex] = true;
            Console.WriteLine(Nodes[startIndex]);

            for (int i = 0;i < Size;i++)
            {
                if (AdjMatrix[startIndex,i] > 0 && !visited[i]) 
                    DFSUtil(i, visited);
            }
        }

        public void DFS()
        {
            bool[] visited = new bool[Size];
            DFSUtil(0, visited);
        }

        public void BFS()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            bool[] visited = new bool[Size];
            visited[0] = true;

            while(queue.Count > 0)
            {
                var cur = queue.Dequeue();
                Console.WriteLine(Nodes[cur]);

                for (int i = 0; i < Size; i++)
                {
                    if (AdjMatrix[cur,i] > 0 && !visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }
    }
}
