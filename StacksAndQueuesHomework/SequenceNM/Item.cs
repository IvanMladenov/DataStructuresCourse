using System.Runtime.InteropServices.ComTypes;

namespace SequenceNM
{
    public class Item
    {
        public Item(int value, Item previouse)
        {
            this.Value = value;
            this.Previouse = previouse;
        }

        public Item Previouse { get; set; }

        public int Value { get; set; }
    }
}
