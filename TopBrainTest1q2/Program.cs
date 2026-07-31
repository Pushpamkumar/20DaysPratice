using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents an undirected social network graph where:
/// - Each vertex represents a user.
/// - Each edge represents a mutual friendship.
/// </summary>
public class SocialNetwork
{
    // Adjacency List
    private Dictionary<int, List<int>> graph;

    // Total number of users
    private int vertices;

    /// <summary>
    /// Initializes the social network with the specified number of users.
    /// </summary>
    /// <param name="vertices">Number of users.</param>
    public SocialNetwork(int vertices)
    {
        this.vertices = vertices;
        graph = new Dictionary<int, List<int>>();

        for (int i = 0; i < vertices; i++)
        {
            graph[i] = new List<int>();
        }
    }

    /// <summary>
    /// Adds a mutual friendship between two users.
    /// </summary>
    /// <param name="user1">First user.</param>
    /// <param name="user2">Second user.</param>
    public void AddFriendship(int user1, int user2)
    {
        graph[user1].Add(user2);
        graph[user2].Add(user1);
    }

    /// <summary>
    /// Returns all direct friends of the given user.
    /// </summary>
    /// <param name="user">User ID.</param>
    /// <returns>List of friends.</returns>
    public List<int> GetFriends(int user)
    {
        return graph[user];
    }

    /// <summary>
    /// Checks whether two users are connected directly or indirectly.
    /// Uses Breadth First Search (BFS).
    /// </summary>
    /// <param name="start">Starting user.</param>
    /// <param name="destination">Target user.</param>
    /// <returns>True if connected, otherwise false.</returns>
    public bool AreConnected(int start, int destination)
    {
        bool[] visited = new bool[vertices];
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == destination)
                return true;

            foreach (int neighbor in graph[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Finds the shortest friendship path between two users.
    /// Uses BFS because the graph is unweighted.
    /// </summary>
    /// <param name="start">Starting user.</param>
    /// <param name="destination">Destination user.</param>
    /// <returns>Shortest path as a list.</returns>
    public List<int> ShortestPath(int start, int destination)
    {
        bool[] visited = new bool[vertices];
        int[] parent = new int[vertices];

        for (int i = 0; i < vertices; i++)
            parent[i] = -1;

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == destination)
                break;

            foreach (int neighbor in graph[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    parent[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        List<int> path = new List<int>();

        if (!visited[destination])
            return path;

        int node = destination;

        while (node != -1)
        {
            path.Add(node);
            node = parent[node];
        }

        path.Reverse();

        return path;
    }

    /// <summary>
    /// Finds all users exactly two friendships away from the given user.
    /// </summary>
    /// <param name="user">Starting user.</param>
    /// <returns>Users at distance 2.</returns>
    public List<int> UsersAtDistanceTwo(int user)
    {
        int[] distance = Enumerable.Repeat(-1, vertices).ToArray();

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(user);
        distance[user] = 0;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            foreach (int neighbor in graph[current])
            {
                if (distance[neighbor] == -1)
                {
                    distance[neighbor] = distance[current] + 1;
                    queue.Enqueue(neighbor);
                }
            }
        }

        List<int> result = new List<int>();

        for (int i = 0; i < vertices; i++)
        {
            if (distance[i] == 2)
                result.Add(i);
        }

        return result;
    }

    /// <summary>
    /// Detects whether the undirected graph contains a cycle.
    /// </summary>
    /// <returns>True if a cycle exists.</returns>
    public bool HasCycle()
    {
        bool[] visited = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            if (!visited[i])
            {
                if (DFSHasCycle(i, visited, -1))
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// DFS helper for cycle detection.
    /// </summary>
    private bool DFSHasCycle(int current, bool[] visited, int parent)
    {
        visited[current] = true;

        foreach (int neighbor in graph[current])
        {
            if (!visited[neighbor])
            {
                if (DFSHasCycle(neighbor, visited, current))
                    return true;
            }
            else if (neighbor != parent)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Finds all connected components (friend groups).
    /// </summary>
    /// <returns>List of friend groups.</returns>
    public List<List<int>> ConnectedComponents()
    {
        bool[] visited = new bool[vertices];

        List<List<int>> groups = new List<List<int>>();

        for (int i = 0; i < vertices; i++)
        {
            if (!visited[i])
            {
                List<int> component = new List<int>();

                DFSComponent(i, visited, component);

                groups.Add(component);
            }
        }

        return groups;
    }

    /// <summary>
    /// DFS helper for connected components.
    /// </summary>
    private void DFSComponent(int current, bool[] visited, List<int> component)
    {
        visited[current] = true;
        component.Add(current);

        foreach (int neighbor in graph[current])
        {
            if (!visited[neighbor])
            {
                DFSComponent(neighbor, visited, component);
            }
        }
    }
}

/// <summary>
/// Driver Program.
/// </summary>
class Program
{
    static void Main()
    {
        SocialNetwork network = new SocialNetwork(6);

        // Add friendships
        network.AddFriendship(0, 1);
        network.AddFriendship(0, 2);
        network.AddFriendship(1, 3);
        network.AddFriendship(2, 3);
        network.AddFriendship(2, 4);
        network.AddFriendship(3, 5);
        network.AddFriendship(4, 5);

        Console.WriteLine("========== Social Network ==========\n");

        // 1. Friends of User 2
        Console.WriteLine("Friends of User 2:");

        foreach (int friend in network.GetFriends(2))
            Console.Write(friend + " ");

        Console.WriteLine("\n");

        // 2. Connection Check
        Console.WriteLine("Is User 0 connected to User 5?");
        Console.WriteLine(network.AreConnected(0, 5));

        Console.WriteLine();

        // 3. Shortest Path
        Console.WriteLine("Shortest Path from User 0 to User 5:");

        var path = network.ShortestPath(0, 5);

        Console.WriteLine(string.Join(" -> ", path));

        Console.WriteLine();

        // 4. Users at Distance 2
        Console.WriteLine("Users at Distance 2 from User 1:");

        foreach (int user in network.UsersAtDistanceTwo(1))
            Console.Write(user + " ");

        Console.WriteLine("\n");

        // 5. Cycle Detection
        Console.WriteLine("Network contains cycle: " + network.HasCycle());

        Console.WriteLine();

        // 6. Connected Components
        Console.WriteLine("Connected Components:");

        int count = 1;

        foreach (var component in network.ConnectedComponents())
        {
            Console.Write($"Group {count}: ");

            foreach (int user in component)
                Console.Write(user + " ");

            Console.WriteLine();
            count++;
        }
    }
}