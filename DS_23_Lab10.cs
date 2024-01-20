using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijsktra
{
    internal class Program
    {
        public static double INFINITY = Double.PositiveInfinity;
        static void Main(string[] args)
        {
            double[,] cost = {
               { INFINITY,    5,    3, INFINITY,    2},
               { INFINITY, INFINITY,    2,    6, INFINITY},
               { INFINITY,    1, INFINITY,    2, INFINITY},
               { INFINITY, INFINITY, INFINITY, INFINITY, INFINITY},
               { INFINITY,    6,   10,    4,    INFINITY}  };            
            double[] distance = new double[cost.GetLength(0)];
            int [] previous = Dijsktra(0, cost, distance);
            printArray(distance);
            printShortestPath(3, previous);

            Console.Read();
        }

        static int[] Dijsktra(int src, double[,] cost, double[] distance)
        {
            int size = cost.GetLength(0);
            bool[] visited = new bool[size];
            int[] previous = new int[size];
            //Inıtialization
            for (int i = 0; i < size; i++)
            {
                distance[i] = INFINITY;
                previous[i] = -1;
                visited[i] = false;
            }
            distance[src] = 0;

            //Searching for shortest paths
            for (int i = 0; i < size; i++)
            {
                double min = INFINITY;
                int minIndex = -1;
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] && distance[j] < min)
                    {
                        minIndex = j;
                        min = distance[j];
                    }
                }
				if (minIndex == -1) break;
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] && min + cost[minIndex,j] < distance[j])
                    {
                        distance[j] = min + cost[minIndex, j];
                        previous[j] = minIndex;
                    } 
                }
                visited[minIndex] = true;
            }
            return previous;
        }

        static void printShortestPath(int dest, int[] previous)
        {
            Stack<int> stack = new Stack<int>();
            int current = dest;
            while(current != -1)
            {
                stack.Push(current);
                current = previous[current];
            }
            string output = "";
            while(stack.Count > 0)
            {
                output += stack.Pop();
                if(stack.Count > 0) output += " -> ";
            }
            Console.WriteLine(output);
        }

        static void printArray(double[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length; i++)
            {
                if(i!=0) Console.Write(", ");
                Console.Write($"{arr[i]}");
            }
            Console.Write("]\n");
        }
    }
}
