using System;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Learning;

class PriorityQueue<T>
{
    private const int MAX_SIZE = 1000;
    private int size;
    private T[] heapArray;
    private Func<T, T, int> comparer;

    public PriorityQueue(Func<T, T, int> comparison)
    {
        size = 0;
        heapArray = new T[MAX_SIZE];
        comparer = comparison;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public void Enqueue(T item)
    {
        if (size == MAX_SIZE)
        {
            Console.WriteLine("Priority Queue Overflow");
            return;
        }

        heapArray[size] = item;
        HeapifyUp(size);
        size++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Priority Queue Underflow");
            return default(T);
        }

        T root = heapArray[0];
        heapArray[0] = heapArray[size - 1];
        size--;
        HeapifyDown(0);
        return root;
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parent = (index - 1) / 2;
            if (comparer(heapArray[index], heapArray[parent]) < 0)
            {
                Swap(index, parent);
                index = parent;
            }
            else
            {
                break;
            }
        }
    }

    private void HeapifyDown(int index)
    {
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        int smallest = index;

        if (leftChild < size && comparer(heapArray[leftChild], heapArray[smallest]) < 0)
            smallest = leftChild;

        if (rightChild < size && comparer(heapArray[rightChild], heapArray[smallest]) < 0)
            smallest = rightChild;

        if (smallest != index)
        {
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }

    private void Swap(int i, int j)
    {
        T temp = heapArray[i];
        heapArray[i] = heapArray[j];
        heapArray[j] = temp;
    }
}

class Progr
{
    static void Main(string[] args)
    {
        // Example: Priority Queue of integers (min-heap)
        var priorityQueue = new PriorityQueue<int>((a, b) => a.CompareTo(b));

        priorityQueue.Enqueue(10);
        priorityQueue.Enqueue(5);
        priorityQueue.Enqueue(20);

        while (!priorityQueue.IsEmpty())
        {
            Console.WriteLine(priorityQueue.Dequeue());
        }
    }
}

