using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning;

using System;

class Queue
{
    private const int MAX_SIZE = 1000;
    private int front;
    private int rear;
    private int[] queueArray;

    public Queue()
    {
        front = -1;
        rear = -1;
        queueArray = new int[MAX_SIZE];
    }

    public bool IsEmpty()
    {
        return front == -1;
    }

    public bool IsFull()
    {
        return rear == MAX_SIZE - 1;
    }

    public void Enqueue(int data)
    {
        if (IsFull())
        {
            Console.WriteLine("Queue Overflow");
            return;
        }

        if (IsEmpty())
            front = 0;

        queueArray[++rear] = data;
    }

    public int Dequeue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue Underflow");
            return 0;
        }

        int dequeuedItem = queueArray[front];
        if (front == rear)
        {
            front = -1;
            rear = -1;
        }
        else
        {
            front++;
        }

        return dequeuedItem;
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty.");
            return 0;
        }

        return queueArray[front];
    }

    public void PrintQueue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Console.WriteLine("Items in the queue:");
        for (int i = front; i <= rear; i++)
        {
            Console.WriteLine(queueArray[i]);
        }
    }
}
