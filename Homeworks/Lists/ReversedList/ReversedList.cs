using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedList
{
    class ReversedList<T>
    {
        private const int DefaultLenght = 16;
        private T[] arr;
        private int currentIndex = 0;

        public ReversedList()
        {
            this.arr = new T[DefaultLenght];
            this.Capacity = DefaultLenght;
        }

        public int Count
        {
            get
            {
                return this.currentIndex;
            }
        }

        public int Capacity { get; private set; }

        public void Add(T argument)
        {
            this.arr[currentIndex++] = argument;
            if (this.currentIndex == this.Capacity - 1)
            {
                Resize();
            }
        }

        public void Remove(int index)
        {
            var newArray = new T[this.Capacity];

            for (int i = 0, newIndex = 0; i < this.Count; i++, newIndex++)
            {
                if (i != index)
                {
                    newArray[newIndex] = this.arr[i];
                }
                else
                {
                    newIndex--;
                }
            }

            this.arr = newArray;
            this.currentIndex--;
        }

        public T this[int index]
        {
            get
            {
                return this.arr[this.currentIndex -1 - index];
            }

            set
            {
                this.arr[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.currentIndex-1; i >= 0; i--)
            {
                yield return this.arr[i];
            }
        }

        private void Resize()
        {
            this.Capacity *= 2;
            T[] newArray = new T[this.Capacity];
            Array.Copy(this.arr, newArray, this.arr.Length - 1);
            arr = newArray;
        }
    }
}
