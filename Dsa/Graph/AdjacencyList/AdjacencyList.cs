using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.Graph.AdjacencyList
{
    public class AdjacencyList
    {
        private Dictionary<int, List<int>> graph;

        public AdjacencyList()
        {
            graph = new Dictionary<int, List<int>>();
        }

        public void AddVertex(int vertex)
        {
            if (!graph.ContainsKey(vertex))
            {
                graph[vertex] = new List<int>();
            }
        }

        public void AddEdge(int source, int destination)
        {
            AddVertex(source);
            AddVertex(destination);

            graph[source].Add(destination);
            graph[destination].Add(source);
        }

        public void Display()
        {
            Console.WriteLine("Adjacency List");

            foreach (var vertex in graph)
            {
                Console.Write(vertex.Key + " -> ");
                foreach (int neighbor in vertex.Value)
                {
                    Console.Write(neighbor + " ");
                }

                Console.WriteLine();
            }
        }

        public void DFS(int start)
        {
            HashSet<int> visited = new HashSet<int>();

            Console.Write("DFS: ");

            DFSHelper(start, visited);

            Console.WriteLine();
        }

        private void DFSHelper(int vertex, HashSet<int> visited)
        {
            visited.Add(vertex);

            Console.Write(vertex + " ");

            foreach (int neighbor in graph[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    DFSHelper(neighbor, visited);
                }
            }
        }

        public void BFS(int start)
        {
            HashSet<int> visited = new(); // use hash set to avoid duplications
            Queue<int> queue = new();

            visited.Add(start);
            queue.Enqueue(start);

            Console.Write("BFS");

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                Console.Write(vertex + " ");

                foreach(int neighbor in graph[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            Console.WriteLine();
        }

    }
}
