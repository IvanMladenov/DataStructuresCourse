using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceNM
{
    class Item
    {
        public Item(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }

        public Item PrevItem { get; set; }
    }
}
