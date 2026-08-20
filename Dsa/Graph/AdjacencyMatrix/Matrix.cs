using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Graph.AdjacencyMatrix
{
    public class Matrix
    {
        private int[,] matrix;
        private int vertices; // for length of row and column

        public Matrix(int vertices)
        {
            this.vertices = vertices;
            matrix = new int[vertices, vertices];
        }

        public void AddEdge(int source, int destination)
        {
            matrix[source, destination] = 1;
            matrix[destination, source] = 1;
        }

        public void Display()
        {
            Console.WriteLine("Adjacency Matrix");

            for (int i = 0; i < vertices; i++)
            {
                for(int j = 0; j < vertices; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
        
        public void DFS(int start)
        {
            bool[] visited = new bool[vertices];
            Console.Write("DFS: ");
            DFSHelper(start, visited);
        }

        private void DFSHelper(int vertex, bool[] visited)
        {
            visited[vertex] = true;

            Console.Write(vertex + " ");

            for(int i = 0; i < vertices; i++)
            {
                if (matrix[vertex, i] == 1 && !visited[i])
                {
                    DFSHelper(i, visited);
                }
            }
        }

        public void BFS(int start)
        {
            bool[] visited = new bool[vertices];

            Queue<int> queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);

            Console.Write("BFS: ");

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();

                Console.Write(vertex + " ");

                for (int i = 0; i < vertices; i++)
                {
                    if (matrix[vertex, i] == 1 && !visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
