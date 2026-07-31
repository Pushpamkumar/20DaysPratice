// Summary: Demonstrates basic queue and stack operations with fixed-size arrays.
// Shows enqueue/dequeue for a queue and push/pop for a stack.
using System;

class QueueArray
{
    private int[] queue = new int[5];
    private int front = 0;
    private int rear = -1;

    public void Enqueue(int value)
    {
        if (rear == queue.Length - 1)
        {
            Console.WriteLine("Queue Full");
            return;
        }

        queue[++rear] = value;
    }

    public void Dequeue()
    {
        if (front > rear)
        {
            Console.WriteLine("Queue Empty");
            return;
        }

        Console.WriteLine("Deleted: " + queue[front++]);
    }

    public void Display()
    {
        if (front > rear)
        {
            Console.WriteLine("Queue Empty");
            return;
        }

        for (int i = front; i <= rear; i++)
        {
            Console.WriteLine(queue[i]);
        }
    }
}

class StackArray
{
    private int[] stack = new int[5];
    private int top = -1;

    public void Push(int value)
    {
        if (top == stack.Length - 1)
        {
            Console.WriteLine("Stack Overflow");
            return;
        }

        stack[++top] = value;
    }

    public void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack Underflow");
            return;
        }

        Console.WriteLine("Deleted: " + stack[top--]);
    }

    public void Display()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack Empty");
            return;
        }

        for (int i = top; i >= 0; i--)
            Console.WriteLine(stack[i]);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Queue Operations");

        QueueArray q = new QueueArray();
        q.Enqueue(10);
        q.Enqueue(20);
        q.Enqueue(30);
        q.Display();

        q.Dequeue();

        Console.WriteLine("\nAfter Dequeue");
        q.Display();

        Console.WriteLine("\nStack Operations");

        StackArray s = new StackArray();
        s.Push(10);
        s.Push(20);
        s.Push(30);
        s.Display();

        s.Pop();

        Console.WriteLine("\nAfter Pop");
        s.Display();
    }
}