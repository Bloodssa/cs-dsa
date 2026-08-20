using Dsa.LinkedList;
using Dsa.BTree.Implementation;
using Dsa.LinkedList.Implementation;
using System;
using Dsa.BTree;
using Dsa.BTree.BST;
using Dsa.Graph.AdjacencyMatrix;
using Dsa.Graph.AdjacencyList;

namespace Dsa
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BinarySearchTree<int> bst = new();

            //bst.Insert(1);
            //bst.Insert(2);
            //bst.Insert(3);
            //bst.Insert(4);
            //bst.Insert(5);
            //bst.Insert(6);
            //bst.Insert(7);
            //bst.Insert(80);
            //bst.Insert(-10000);

            //bst.InOrder(bst.root);
            //Console.WriteLine();
            //Console.WriteLine(bst.Search(-80) == null ? "Null" : "Found");

            //Matrix graph = new Matrix(5);

            //graph.AddEdge(0, 1);
            //graph.AddEdge(0, 2);
            //graph.AddEdge(1, 3);
            //graph.AddEdge(2, 3);
            //graph.AddEdge(3, 4);

            //graph.Display();

            //Console.WriteLine();
            //graph.DFS(0);
            //Console.WriteLine();
            //graph.BFS(0);

            AdjacencyList graph = new AdjacencyList();

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            graph.Display();

            Console.WriteLine();
            graph.DFS(0);
            graph.BFS(0);
        }   
    }
}