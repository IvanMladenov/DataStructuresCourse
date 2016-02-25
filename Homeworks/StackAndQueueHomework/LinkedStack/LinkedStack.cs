using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    class LinkedStack<T>
    {
        private StackNode<T> lastPushed;

        public int Count { get; set; }

        public void Push(T value)
        {
            if (this.Count==0)
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
            var arr = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                arr[i] = this.Pop();
            }

            return arr;
        }
    }
}
