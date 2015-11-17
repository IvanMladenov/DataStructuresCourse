using System;

namespace ArrayStack
{
    public class ArrayStack<T>
    {
        private T[] elements;
        private const int InitialCapacity = 16;

        public ArrayStack()
        {
            elements = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (elements.Length==Count)
            {
                Grow();
            }

            elements[Count] = element;
            Count++;
        }

        public T Pop()
        {
            T element = elements[Count - 1];
            Count--;
            return element;
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                arr[i] = elements[i];
            }
            
            Array.Reverse(arr);
            return arr;
        }

        private void Grow()
        {
            T[] newArr = new T[2*elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                newArr[i] = elements[i];
            }

            elements = newArr;
        }
    }
}