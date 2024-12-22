using System;
using System.Collections.Generic;

namespace doklad_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nGraph Operations:");
                Console.WriteLine("1. Add Vertex");
                Console.WriteLine("2. Add Edge");
                Console.WriteLine("3. Remove Vertex");
                Console.WriteLine("4. Remove Edge");
                Console.WriteLine("5. Print Graph");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter vertex to add: ");
                        if (int.TryParse(Console.ReadLine(), out int vertex))
                        {
                            graph.AddVertex(vertex);
                            Console.WriteLine($"Vertex {vertex} added.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter first vertex of the edge: ");
                        if (int.TryParse(Console.ReadLine(), out int from) &&
                            int.TryParse(Console.ReadLine(), out int to))
                        {
                            graph.AddEdge(from, to);
                            Console.WriteLine($"Edge ({from}, {to}) added.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter valid integers.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter vertex to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int vertexToRemove))
                        {
                            graph.RemoveVertex(vertexToRemove);
                            Console.WriteLine($"Vertex {vertexToRemove} removed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter first vertex of the edge to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int fromEdge) &&
                            int.TryParse(Console.ReadLine(), out int toEdge))
                        {
                            graph.RemoveEdge(fromEdge, toEdge);
                            Console.WriteLine($"Edge ({fromEdge}, {toEdge}) removed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter valid integers.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Graph:");
                        graph.PrintGraph();
                        break;

                    case "6":
                        running = false;
                        Console.WriteLine("Exiting the program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

    public class Graph
    {
        private Dictionary<int, List<int>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<int, List<int>>();
        }

        // Добавление вершины
        public void AddVertex(int vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<int>();
            }
        }

        // Добавление ребра
        public void AddEdge(int from, int to)
        {
            if (!adjacencyList.ContainsKey(from))
            {
                AddVertex(from);
            }
            if (!adjacencyList.ContainsKey(to))
            {
                AddVertex(to);
            }
            adjacencyList[from].Add(to);
            adjacencyList[to].Add(from); // Для неориентированного графа
        }

        // Удаление вершины
        public void RemoveVertex(int vertex)
        {
            if (adjacencyList.ContainsKey(vertex))
            {
                foreach (var neighbor in adjacencyList[vertex])
                {
                    adjacencyList[neighbor].Remove(vertex);
                }
                adjacencyList.Remove(vertex);
            }
        }

        // Удаление ребра
        public void RemoveEdge(int from, int to)
        {
            if (adjacencyList.ContainsKey(from) && adjacencyList.ContainsKey(to))
            {
                adjacencyList[from].Remove(to);
                adjacencyList[to].Remove(from); // Для неориентированного графа
            }
        }

        // Вывод графа
        public void PrintGraph()
        {
            foreach (var vertex in adjacencyList.Keys)
            {
                Console.Write($"{vertex}: ");
                foreach (var neighbor in adjacencyList[vertex])
                {
                    Console.Write($"{neighbor} ");
                }
                Console.WriteLine();
            }
        }
    }
}