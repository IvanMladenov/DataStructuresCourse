namespace LinkedQueue
{
    internal class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public QueueNode<T> NextNode { get; set; }

        public T Value { get; private set; }
    }
}