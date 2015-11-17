using System;
using LinkedQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedQueueTests
{
    [TestClass]
    public class TestMethods
    {
        [TestMethod]
        public void TestEnqueueDequeueSingleElementShouldChangeCountDequeueTheSameElementLikeEnqueueed()
        {
            LinkedQueue<int> q = new LinkedQueue<int>();
            int number = 5;

            int count = q.Count;
            Assert.AreEqual(count, 0);

            q.Enqueue(number);
            Assert.AreEqual(1, q.Count);

            int Dequeueed = q.Dequeue();
            Assert.AreEqual(number, Dequeueed);

            Assert.AreEqual(0, q.Count);
        }

        [TestMethod]
        public void TestEnqueueDequeueTousendElementsTheCountShouldBeCorrectIndirectlyTestAutoGrow()
        {
            LinkedQueue<int> q = new LinkedQueue<int>();

            for (int i = 1; i <= 1000; i++)
            {
                Assert.AreEqual(i - 1, q.Count);
                q.Enqueue(i);
            }

            for (int i = 1000; i >= 1; i--)
            {
                Assert.AreEqual(i, q.Count);
                int current = q.Dequeue();
                Assert.AreEqual(1001-i, current);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Queue is empty.")]
        public void DequeueFromEmptyqShouldThrowExeption()
        {
            LinkedQueue<int> q = new LinkedQueue<int>();

            q.Dequeue();
        }

        [TestMethod]
        public void TestqToArrayMethodShouldReturnSameArray()
        {
            LinkedQueue<int> q = new LinkedQueue<int>();
            int[] arr = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < arr.Length; i++)
            {
                q.Enqueue(arr[i]);
            }

            int[] result = q.ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], result[i]);
            }
        }

        [TestMethod]
        public void TestToArrayMethodWithEmptyqShouldReturnEmptyArray()
        {
            LinkedQueue<int> q = new LinkedQueue<int>();

            int[] result = q.ToArray();

            Assert.AreEqual(0, result.Length);
        }
    }
}
