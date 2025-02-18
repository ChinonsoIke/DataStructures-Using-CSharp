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

        public int[] Dijkstra(int startIndex)
        {
            // initial distances arr and set all to int.max, set start to 0
            // intialize visited arr, set all to false
            // loop through starting from source 
            // find the min distance from source
            // set distances of neighbors of min

            bool[] visited = new bool[Size];
            int[] distances = new int[Size];
            Array.Fill(distances, int.MaxValue);
            distances[startIndex] = 0;

            for (int i = 0;i < Size; i++)
            {
                int minDistance = int.MaxValue;
                int? nearestNode = null;

                for(int j = 0; j < Size; j++)
                {
                    if(!visited[j] && distances[j] < minDistance)
                    {
                        minDistance = distances[j];
                        nearestNode = j;
                    }
                }

                if(!nearestNode.HasValue) break;

                visited[nearestNode.Value] = true;

                for(int j = 0;j < Size; j++)
                {
                    if (AdjMatrix[nearestNode.Value,j] > 0 && !visited[j])
                    {
                        int alt = distances[nearestNode.Value] + AdjMatrix[nearestNode.Value, j];
                        if(alt < distances[j]) distances[j] = alt;
                    }
                }
            }

            return distances;
        }
    }
}
