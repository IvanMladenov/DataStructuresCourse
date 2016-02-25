using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBasedStack
{
    class ArrayStack<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;

        public ArrayStack(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int  Count { get; set; }

        public void Push(T element)
        {
            if (this.elements.Length == this.Count)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count==0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            this.Count--;
            return this.elements[this.Count];
        }

        public T[] ToArray()
        {
            var arr = new T[this.Count];
            Array.Copy(this.elements, arr, this.Count);

            return arr;
        }

        private void Grow()
        {
            var newArray = new T[this.elements.Length * 2];
            Array.Copy(this.elements, newArray, this.elements.Length);

            this.elements = newArray;
        }
    }
}
