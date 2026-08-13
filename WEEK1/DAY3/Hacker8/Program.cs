using System;

/// <summary>
/// Represents a node in a binary tree.
/// </summary>
class Node
{
    /// <summary>
    /// Stores the node value.
    /// </summary>
    public int data;

    /// <summary>
    /// Reference to the left child.
    /// </summary>
    public Node left;

    /// <summary>
    /// Reference to the right child.
    /// </summary>
    public Node right;

    /// <summary>
    /// Initializes a new tree node.
    /// </summary>
    /// <param name="value">Node value.</param>
    public Node(int value)
    {
        data = value;
        left = null;
        right = null;
    }
}

/// <summary>
/// Represents a Binary Search Tree.
/// </summary>
class BinaryTree
{
    /// <summary>
    /// Root node of the tree.
    /// </summary>
    public Node root;

    /// <summary>
    /// Inserts a value into the Binary Search Tree.
    /// </summary>
    /// <param name="root">Current root node.</param>
    /// <param name="data">Value to insert.</param>
    /// <returns>Updated root node.</returns>
    public Node Insert(Node root, int data)
    {
        if (root == null)
        {
            return new Node(data);
        }

        if (data <= root.data)
        {
            root.left = Insert(root.left, data);
        }
        else
        {
            root.right = Insert(root.right, data);
        }

        return root;
    }

    /// <summary>
    /// Performs postorder traversal of the binary tree.
    /// Traversal Order:
    /// Left → Right → Root
    /// </summary>
    /// <param name="root">Root node of the tree.</param>
    public void PostOrder(Node root)
    {
        if (root == null)
        {
            return;
        }

        // Traverse left subtree.
        PostOrder(root.left);

        // Traverse right subtree.
        PostOrder(root.right);

        // Visit current node.
        Console.Write(root.data + " ");
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
        BinaryTree tree = new BinaryTree();

        Console.Write("Enter number of nodes: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter node values:");

        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            tree.root = tree.Insert(tree.root, value);
        }

        Console.WriteLine("\nPostorder Traversal:");

        tree.PostOrder(tree.root);
    }
}