using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    class StackNode<T>
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
