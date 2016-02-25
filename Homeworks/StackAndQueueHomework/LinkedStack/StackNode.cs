namespace LinkedStack
{
    internal class StackNode<T>
    {
        public StackNode(T value)
        {
            this.PrevNode = null;
            this.Value = value;
        }

        public StackNode<T> PrevNode { get; set; }

        public T Value { get; set; }
    }
}