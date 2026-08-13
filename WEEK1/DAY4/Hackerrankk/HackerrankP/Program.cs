using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a directed graph for Course Prerequisite System.
/// Edge Direction:
/// Prerequisite Course ---> Dependent Course
/// </summary>
public class CourseGraph
{
    // Adjacency List
    private Dictionary<int, List<int>> graph;

    // Total number of courses
    private int vertices;

    /// <summary>
    /// Initializes the graph with given number of courses.
    /// </summary>
    /// <param name="vertices">Number of courses.</param>
    public CourseGraph(int vertices)
    {
        this.vertices = vertices;
        graph = new Dictionary<int, List<int>>();

        for (int i = 0; i < vertices; i++)
        {
            graph[i] = new List<int>();
        }
    }

    /// <summary>
    /// Adds a prerequisite relationship.
    /// prerequisite --> course
    /// </summary>
    /// <param name="prerequisite">Prerequisite course.</param>
    /// <param name="course">Dependent course.</param>
    public void AddEdge(int prerequisite, int course)
    {
        graph[prerequisite].Add(course);
    }

    /// <summary>
    /// Finds all direct and indirect prerequisites of a course.
    /// </summary>
    /// <param name="course">Target course.</param>
    /// <returns>Set of prerequisite courses.</returns>
    public HashSet<int> GetAllPrerequisites(int course)
    {
        // Reverse graph for prerequisite traversal
        Dictionary<int, List<int>> reverseGraph = new Dictionary<int, List<int>>();

        for (int i = 0; i < vertices; i++)
            reverseGraph[i] = new List<int>();

        foreach (var node in graph)
        {
            foreach (var neighbor in node.Value)
            {
                reverseGraph[neighbor].Add(node.Key);
            }
        }

        HashSet<int> result = new HashSet<int>();

        DFSReverse(course, reverseGraph, result);

        return result;
    }

    /// <summary>
    /// DFS on reverse graph.
    /// </summary>
    private void DFSReverse(int node,
                            Dictionary<int, List<int>> reverseGraph,
                            HashSet<int> visited)
    {
        foreach (int parent in reverseGraph[node])
        {
            if (!visited.Contains(parent))
            {
                visited.Add(parent);
                DFSReverse(parent, reverseGraph, visited);
            }
        }
    }

    /// <summary>
    /// Returns direct prerequisites of a course.
    /// </summary>
    public List<int> GetDirectPrerequisites(int course)
    {
        List<int> prerequisites = new List<int>();

        foreach (var node in graph)
        {
            if (node.Value.Contains(course))
                prerequisites.Add(node.Key);
        }

        return prerequisites;
    }

    /// <summary>
    /// Detects cycle using DFS.
    /// </summary>
    public bool HasCycle()
    {
        bool[] visited = new bool[vertices];
        bool[] recursionStack = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            if (DetectCycleDFS(i, visited, recursionStack))
                return true;
        }

        return false;
    }

    /// <summary>
    /// DFS helper for cycle detection.
    /// </summary>
    private bool DetectCycleDFS(int node, bool[] visited, bool[] recursionStack)
    {
        if (recursionStack[node])
            return true;

        if (visited[node])
            return false;

        visited[node] = true;
        recursionStack[node] = true;

        foreach (int neighbor in graph[node])
        {
            if (DetectCycleDFS(neighbor, visited, recursionStack))
                return true;
        }

        recursionStack[node] = false;

        return false;
    }

    /// <summary>
    /// Performs Topological Sorting using Kahn's Algorithm.
    /// </summary>
    public List<int> TopologicalSort()
    {
        int[] indegree = new int[vertices];

        // Calculate indegree
        foreach (var node in graph)
        {
            foreach (int neighbor in node.Value)
            {
                indegree[neighbor]++;
            }
        }

        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < vertices; i++)
        {
            if (indegree[i] == 0)
                queue.Enqueue(i);
        }

        List<int> order = new List<int>();

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            order.Add(current);

            foreach (int neighbor in graph[current])
            {
                indegree[neighbor]--;

                if (indegree[neighbor] == 0)
                    queue.Enqueue(neighbor);
            }
        }

        return order;
    }

    /// <summary>
    /// Finds all courses having no prerequisites.
    /// </summary>
    public List<int> CoursesWithoutPrerequisites()
    {
        int[] indegree = new int[vertices];

        foreach (var node in graph)
        {
            foreach (int neighbor in node.Value)
            {
                indegree[neighbor]++;
            }
        }

        List<int> result = new List<int>();

        for (int i = 0; i < vertices; i++)
        {
            if (indegree[i] == 0)
                result.Add(i);
        }

        return result;
    }

    /// <summary>
    /// Counts how many courses directly depend on a given course.
    /// </summary>
    public int CountDirectDependents(int course)
    {
        return graph[course].Count;
    }
}

/// <summary>
/// Driver Program.
/// </summary>
class Program
{
    static void Main()
    {
        CourseGraph graph = new CourseGraph(6);

        // Add prerequisite relationships
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 5);
        graph.AddEdge(4, 5);

        Console.WriteLine("========== Course Prerequisite System ==========\n");

        // 1. All prerequisites for Course 5
        Console.WriteLine("All prerequisites for Course 5:");

        var prerequisites = graph.GetAllPrerequisites(5);

        foreach (int course in prerequisites.OrderBy(x => x))
        {
            Console.Write(course + " ");
        }

        Console.WriteLine("\n");

        // 2. Direct prerequisites for Course 3
        Console.WriteLine("Direct prerequisites of Course 3:");

        foreach (int course in graph.GetDirectPrerequisites(3))
        {
            Console.Write(course + " ");
        }

        Console.WriteLine("\n");

        // 3. Cycle Detection
        Console.WriteLine("Graph contains cycle: " + graph.HasCycle());

        Console.WriteLine();

        // 4. Topological Sort
        if (!graph.HasCycle())
        {
            Console.WriteLine("Topological Order:");

            foreach (int course in graph.TopologicalSort())
            {
                Console.Write(course + " ");
            }

            Console.WriteLine("\n");
        }

        // 5. Courses without prerequisites
        Console.WriteLine("Courses with no prerequisites:");

        foreach (int course in graph.CoursesWithoutPrerequisites())
        {
            Console.Write(course + " ");
        }

        Console.WriteLine("\n");

        // 6. Direct dependents of Course 2
        Console.WriteLine("Number of courses directly dependent on Course 2: "
                          + graph.CountDirectDependents(2));
    }
}