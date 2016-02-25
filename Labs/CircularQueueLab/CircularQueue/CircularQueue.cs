using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 16;

    private T[] elementst;

    private int startIndex = 0;

    private int endIndex = 0;

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.elementst = new T[capacity];
    }

    public int Count { get; private set; }


    public void Enqueue(T element)
    {
        if (this.Count == this.elementst.Length)
        {
            this.Grow();
        }

        this.elementst[this.endIndex] = element;
        this.endIndex = (this.endIndex + 1) % this.elementst.Length;
        this.Count++;
    }

    private void Grow()
    {
        var newElements = new T[this.elementst.Length * 2];
        this.CopyAllElementsTo(newElements);
        this.elementst = newElements;
        this.startIndex = 0;
        this.endIndex = this.Count;
    }

    private void CopyAllElementsTo(T[] newElements)
    {
        var sourceIndex = this.startIndex;
        for (int i = 0; i < this.Count; i++)
        {
            newElements[i] = this.elementst[sourceIndex];
            sourceIndex = (sourceIndex + 1) % this.elementst.Length;
        }
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }

        var result = this.elementst[this.startIndex];
        this.startIndex = (this.startIndex + 1) % this.elementst.Length;
        this.Count--;

        return result;
    }

    public T[] ToArray()
    {
        var output = new T[this.Count];
        this.CopyAllElementsTo(output);

        return output;
    }
}


class Example
{
    static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        var first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
