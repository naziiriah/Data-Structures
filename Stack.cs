using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    class Stack
    {
        private const int MAX_SIZE = 1000;
        private int top;
        private int[] stackArray;

        public Stack()
        {
            top = -1;
            stackArray = new int[MAX_SIZE];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == MAX_SIZE - 1;
        }

        public void Push(int data)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack Overflow");
                return;
            }

            stackArray[++top] = data;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }

            return stackArray[top--];
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }

            return stackArray[top];
        }

        public void PrintStack()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty.");
                return;
            }

            Console.WriteLine("Items in the stack:");
            for (int i = top; i >= 0; i--)
            {
                Console.WriteLine(stackArray[i]);
            }
        }
    }

}
