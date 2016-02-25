using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedQueue;

namespace LinkedQueueTests
{
    using System.Linq;

    [TestClass]
    public class LinkedQueueUnitTests
    {
        [TestMethod]
        public void testCountProperty_ShouldStartFromZeroAndGrowAndShrinks()
        {
            var queue = new LinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);

            queue.Enqueue(5);
            Assert.AreEqual(1, queue.Count);

            queue.Dequeue();
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void TestDequeueMethod_ShouldReturnValuesInInitialOrder()
        {
            var queue = new LinkedQueue<int>();
            var array = Enumerable.Range(1, 51).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }

            var output = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                output[i] = queue.Dequeue();
            }

            CollectionAssert.AreEqual(array, output);
        }

        [TestMethod]
        public void TestToArrayMethod_ShouldReturnEqualArrayAsQueued()
        {
            var queue = new LinkedQueue<int>();
            var array = Enumerable.Range(1, 51).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }

            var output = queue.ToArray();

            CollectionAssert.AreEqual(array, output);
        }
    }
}
