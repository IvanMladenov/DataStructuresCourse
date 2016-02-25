namespace LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode<T> lastNode;

        private QueueNode<T> firstNode; 

        public int Count { get; private set; }

        public void Enqueue(T value)
        {
            var node = new QueueNode<T>(value) { NextNode = this.lastNode };
            if (this.Count==0)
            {
                this.lastNode = this.firstNode = node;
            }
            else if(this.Count==1)
            {
                this.firstNode.NextNode = node;
                this.lastNode = node;
            }
            else
            {
                this.lastNode.NextNode = node;
                this.lastNode = node;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            var value = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;
            return value;
        }

        public T[] ToArray()
        {
            var output = new T[this.Count];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = this.Dequeue();
            }

            return output;
        }
    }
}