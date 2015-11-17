using System;

namespace LinkedQueue
{
    public class LinkedQueue<T>
    {
        private QueueNode<T> first;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            QueueNode<T> newFirst = new QueueNode<T>(element, first);
            first = newFirst;
            Count++;
        }

        public T Dequeue()
        {
            if (Count==0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            if (Count==1)
            {
                Count--;
                return first.Value;
            }

            var current = first;
            var next = first.Next;
            while (next.Next!=null)
            {
                current = next;
                next = next.Next;
            }

            current.Next = null;
            Count--;
            return next.Value;
        }

        public T[] ToArray()
        {
            var arr = new T[Count];
            var node = first;
            for (int i = Count-1; i >=0; i--)
            {
                arr[i] = node.Value;
                node = node.Next;
            }

            return arr;
        }
        private class QueueNode<T>
        {
            public QueueNode(T value, QueueNode<T> next = null )
            {
                this.Next = next;
                this.Value = value;
            }

            public T Value { get; set; }

            public QueueNode<T> Next { get; set; }
        }
    }
}
