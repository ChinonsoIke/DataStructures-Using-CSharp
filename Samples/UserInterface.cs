using System;

using LinkedList;
using Stack.List;
using Queue.List;
using Graph;

namespace SampleApp
{
    internal class UserInterface
    {
        /// <summary>
        /// Run the application
        /// </summary>
        public static void Run()
        {
            //ListIt();

            //Console.WriteLine("These books are stacked on top of one another:");
            //StackIt();

            //Console.WriteLine("I will read these books in this order:");
            //QueueIt();

            //string str = "}()";
            //Console.WriteLine($"CheckBrackets - {str} - : {CheckBrackets(str)}");

            GraphIt();
        }

        /// <summary>
        /// Test linked list implementation
        /// </summary>
        public static void ListIt()
        {
            var newlist = new SingleLinkedList<string>();
            newlist.Add("Chelsea");
            newlist.Add("Bayern");
            newlist.Add("Real Madrid");
            newlist.Add("AC Milan");

            Console.WriteLine(newlist[1].Data);

            var notherList = new SingleLinkedList<int>(new int[] { 2, 43, 3, 2, 4, 2, 1, 3, 2 });
            Console.WriteLine(notherList.Count);
            Console.WriteLine(notherList[0].Data);
            Console.WriteLine(notherList.Check(43));
            Console.WriteLine(notherList.IndexOf(4));
            notherList.Remove(4);
            Console.WriteLine(notherList.Check(4));
            newlist.RemoveLast();
            newlist.RemoveFirst();

            for (int i = 0; i < newlist.Count; i++)
            {
                Console.WriteLine(newlist[i].Data);
            }
        }

        /// <summary>
        /// Test stack implementation
        /// </summary>
        public static void StackIt()
        {
            var stack = new Stack<string>(new string[]
            {
                "Angels and Demons",
                "A Song of Ice and Fire",
                "Percy Jackson and the Lightening Thief",
                "Lord of the Rings",
                "Harry Potter"
            });

            while (!stack.IsEmpty())
            {
                var book = stack.Pop();
                Console.WriteLine($"\t{book}");
            }
        }

        /// <summary>
        /// Test queue implementation
        /// </summary>
        public static void QueueIt()
        {
            var queue = new Queue<string>(new string[]
            {
                "Angels and Demons",
                "A Song of Ice and Fire",
                "Percy Jackson and the Lightening Thief",
                "Lord of the Rings",
                "Harry Potter"
            });

            while (!queue.IsEmpty())
            {
                var book = queue.Dequeue();
                Console.WriteLine($"\t{book}");
            }
        }

        public static string CheckBrackets(string str) //(({}}))
        {
            char[] chars = str.ToCharArray();
            var newStack = new Stack<char>();
            string valid= "valid";

            foreach (char chara in chars)
            {
                switch(chara){
                    case '(':
                    case '{':
                    case '[':
                        newStack.Push(chara);
                        break;
                    case ')':
                    case '}':
                    case ']':
                        if (newStack.IsEmpty())
                        {
                            valid = "invalid";
                        }
                        else
                        {
                            char open = newStack.Pop();
                            if ((chara == ')' && open != '(')
                                || (chara == '}' && open != '{')
                                || (chara == ']' && open != '['))
                            {
                                valid = "invalid";
                            }
                        }
                        break;
                }
            }

            if (newStack.Size() > 0) { valid = "invalid"; }

            return valid;
        }

        public static void GraphIt()
        {
            MultipurposeGraph<string> graph = new MultipurposeGraph<string>(5);
            graph.AddNodeData("A", 0);
            graph.AddNodeData("B", 1);
            graph.AddNodeData("C", 2);
            graph.AddNodeData("D", 3);
            graph.AddNodeData("E", 4);

            graph.AddEdge(0, 1, directed: false, weight: 4);
            graph.AddEdge(1, 2, directed: false, weight: 3);
            graph.AddEdge(2, 4, directed: false, weight: 2);
            graph.AddEdge(0, 3, directed: false, weight: 2);
            graph.AddEdge(3, 4, directed: false, weight: 5);

            //graph.PrintMatrix();
            //graph.DFS();
            //Console.WriteLine();
            //graph.BFS();

            int[] distances = graph.Dijkstra(0);
            Console.WriteLine(string.Join(",", distances));
        }
    }
}
