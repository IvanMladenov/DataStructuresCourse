using System;

namespace LinkedStack
{
    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            Node<T> node = new Node<T>(element);
            if (Count>0)
            {
                node.NextNode = firstNode;
            }

            firstNode = node;
            Count++;
        }

        public T Pop()
        {
            if (Count==0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var toReturn = firstNode.Value;
            firstNode = firstNode.NextNode;
            Count--;
            return toReturn;
        }

        public T[] ToArray()
        {
            var arr = new T[Count];
            var node = firstNode;
            for (int i = 0; i < Count; i++)
            {
                arr[i] = node.Value;
                node = node.NextNode;
            }

            return arr;
        }

        public class Node<T>
        {

            public Node(T value, Node<T> nextNode = null)
            {
                Value = value;
                this.NextNode = nextNode;
            }

            public Node<T> NextNode { get; set; }

            public T Value { get; set; }
        }
    }
}
