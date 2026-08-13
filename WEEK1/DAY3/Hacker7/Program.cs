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
    /// Points to the next node.
    /// </summary>
    public Node Next;

    /// <summary>
    /// Initializes a new node.
    /// </summary>
    /// <param name="data">Node value.</param>
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
    /// Inserts a node at the end.
    /// </summary>
    /// <param name="data">Value to insert.</param>
    public void InsertLast(int data)
    {
        Node newNode = new Node(data);

        if (Head == null)
        {
            Head = newNode;
            return;
        }

        Node temp = Head;

        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        temp.Next = newNode;
    }

    /// <summary>
    /// Inserts a node at the specified position.
    /// </summary>
    /// <param name="data">Value to insert.</param>
    /// <param name="position">Zero-based position.</param>
    public void InsertAtPosition(int data, int position)
    {
        Node newNode = new Node(data);

        // Insert at beginning.
        if (position == 0)
        {
            newNode.Next = Head;
            Head = newNode;
            return;
        }

        Node temp = Head;

        // Move to the node before the position.
        for (int i = 0; i < position - 1; i++)
        {
            temp = temp.Next;
        }

        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    /// <summary>
    /// Displays the linked list.
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

        list.InsertLast(10);
        list.InsertLast(20);
        list.InsertLast(40);
        list.InsertLast(50);

        Console.WriteLine("Original Linked List:");
        list.Display();

        list.InsertAtPosition(30, 2);

        Console.WriteLine("\nAfter Inserting 30 at Position 2:");
        list.Display();
    }
}