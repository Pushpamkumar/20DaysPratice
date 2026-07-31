using System;

/// <summary>
/// Represents a node in a circular linked list.
/// </summary>
class Node
{
    /// <summary>
    /// Stores the value of the node.
    /// </summary>
    public int Data;

    /// <summary>
    /// Reference to the next node.
    /// </summary>
    public Node? Next;

    /// <summary>
    /// Initializes a new node with the specified value.
    /// </summary>
    /// <param name="data">Value to store in the node.</param>
    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

/// <summary>
/// Represents a circular linked list.
/// Supports insertion and display operations.
/// </summary>
class CircularLinkedList
{
    /// <summary>
    /// Points to the first node of the list.
    /// </summary>
    private Node? head;

    /// <summary>
    /// Inserts a new node at the end of the circular linked list.
    /// </summary>
    /// <param name="data">Value to insert.</param>
    public void Insert(int data)
    {
        Node newNode = new Node(data);

        // If the list is empty, make the new node point to itself.
        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            return;
        }

        Node temp = head;

        // Traverse to the last node.
        while (temp.Next != head)
        {
            temp = temp.Next!;
        }

        // Insert the new node and maintain circular linkage.
        temp.Next = newNode;
        newNode.Next = head;
    }

    /// <summary>
    /// Displays all nodes in the circular linked list.
    /// </summary>
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("Circular Linked List is Empty");
            return;
        }

        Node temp = head;

        do
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Next!;
        }
        while (temp != head);

        Console.WriteLine("(Back to Head)");
    }

    /// <summary>
    /// Entry point of the application.
    /// Creates and displays a circular linked list.
    /// </summary>
    static void Main()
    {
        CircularLinkedList list = new CircularLinkedList();

        list.Insert(10);
        list.Insert(20);
        list.Insert(30);
        list.Insert(40);

        Console.WriteLine("Circular Linked List:");
        list.Display();
    }
}