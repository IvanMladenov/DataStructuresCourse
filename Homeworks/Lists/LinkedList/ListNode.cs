﻿using System;

namespace LinkedList
{
    class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value { get; set; }

        public ListNode<T> Next { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
