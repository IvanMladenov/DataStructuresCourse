using System.Collections;
using System.Collections.Generic;

namespace TreesAndTreeLikeStructures
{
    class Tree<T>
    {
        public Tree(T value, params Tree<T>[] children )
        {
            Value = value;
            Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                Children.Add(child);
                child.Parent = this;
            }
        }

        public T Value { get; set; }

        public Tree<T> Parent { get; set; }

        public IList<Tree<T>>  Children { get; set; }
    }
}
