using System;

/// <summary>
/// Represents a node in a singly linked list.
/// </summary>
class Node
{
    /// <summary>
    /// Stores the node value.
    /// </summary>
    public int Data;

    /// <summary>
    /// Reference to the next node.
    /// </summary>
    public Node Next;

    /// <summary>
    /// Initializes a new node.
    /// </summary>
    /// <param name="data">Value of the node.</param>
    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

/// <summary>
/// Represents a singly linked list.
/// </summary>
class LinkedList
{
    /// <summary>
    /// Head node of the linked list.
    /// </summary>
    public Node Head;

    /// <summary>
    /// Inserts a node at the beginning of the linked list.
    /// </summary>
    /// <param name="data">Value to insert.</param>
    public void InsertAtHead(int data)
    {
        Node newNode = new Node(data);

        // Link the new node to the current head.
        newNode.Next = Head;

        // Update the head.
        Head = newNode;
    }

    /// <summary>
    /// Displays all nodes in the linked list.
    /// </summary>
    public void Display()
    {
        Node temp = Head;

        while (temp != null)
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Next;
        }

        Console.WriteLine("NULL");
    }
}

/// <summary>
/// Entry point of the application.
/// </summary>
class Program
{
    /// <summary>
    /// Main method.
    /// </summary>
    static void Main()
    {
        LinkedList list = new LinkedList();

        list.InsertAtHead(30);
        list.InsertAtHead(20);
        list.InsertAtHead(10);
        list.InsertAtHead(5);

        Console.WriteLine("Linked List:");

        list.Display();
    }
}