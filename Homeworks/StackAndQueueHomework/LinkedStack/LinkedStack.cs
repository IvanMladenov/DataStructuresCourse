namespace LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private StackNode<T> lastPushed;

        public int Count { get; set; }

        public void Push(T value)
        {
            if (this.Count == 0)
            {
                this.lastPushed = new StackNode<T>(value);
            }
            else
            {
                var newLast = new StackNode<T>(value);
                newLast.PrevNode = this.lastPushed;
                this.lastPushed = newLast;
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var output = this.lastPushed;
            this.lastPushed = output.PrevNode;
            this.Count--;

            return output.Value;
        }

        public T[] ToArray()
        {
            int lenght = this.Count;
            var arr = new T[lenght];

            for (int i = 0; i < lenght; i++)
            {
                arr[i] = this.Pop();
            }

            return arr;
        }
    }
}