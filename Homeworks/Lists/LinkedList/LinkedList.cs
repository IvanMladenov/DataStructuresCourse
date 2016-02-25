using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList<T>
    {
        private ListNode<T> firstNode;
        private ListNode<T> lastNode;

        public LinkedList()
        {
            this.firstNode = null;
            this.lastNode = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(T value)
        {

            var current = new ListNode<T>(value);

            if (firstNode == null)
            {
                firstNode = current;
                lastNode = current;
            }
            else
            {
                lastNode.Next = current;
                lastNode = current;
            }

            this.Count++;
        }

        public IEnumerator<ListNode<T>> GetEnumerator()
        {
            ListNode<T> current = this.firstNode;

            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        public int LastIndexOf(T value)
        {
            var currentNode = this.firstNode;
            var counter = 0;
            var index = -1;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    index = counter;
                }

                counter++;
                currentNode = currentNode.Next;
            }

            return index;
        }

        public int FirstIndexOf(T value)
        {
            var currentNode = this.firstNode;
            var counter = 0;

            while (currentNode!=null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return counter;
                }

                counter++;
                currentNode = currentNode.Next;
            }

            return -1;
        }

        public void Remove(int index)
        {
            ListNode<T> prev = null;
            var node = firstNode;
            ListNode<T> next = node.Next;

            for (int i = 0; i < index; i++)
            {
                prev = node;
                node = node.Next;
                next = node.Next;
            }

            if (prev == null)
            {
                firstNode = next;
            }
            else if (node.Next == null)
            {
                this.lastNode = prev;
                this.lastNode.Next = null;
            }
            else
            {
                prev.Next = next;
            }

            this.Count--;
        }
    }
}
