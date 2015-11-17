using System;
using ArrayStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayStackTests
{
    [TestClass]
    public class TestMethods
    {
        [TestMethod]
        public void TestPushPopSingleElementShouldChangeCountPopTheSameElementLikePushed()
        {
            ArrayStack<int> stack = new ArrayStack<int>();
            int number = 5;

            int count = stack.Count;
            Assert.AreEqual(count, 0);

            stack.Push(number);
            Assert.AreEqual(1, stack.Count);

            int poped = stack.Pop();
            Assert.AreEqual(number, poped);

            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestPushPopTousendElementsTheCountShouldBeCorrectIndirectlyTestAutoGrow()
        {
            ArrayStack<int> stack = new ArrayStack<int>();
         
            for (int i = 1; i <= 1000; i++)
            {
                Assert.AreEqual(i-1, stack.Count);
                stack.Push(i);
            }

            for (int i = 1000; i >= 1; i--)
            {
                Assert.AreEqual(i, stack.Count);
                int current = stack.Pop();
                Assert.AreEqual(i, current);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PopFromEmptyStackShouldThrowExeption()
        {
            ArrayStack<int> stack = new ArrayStack<int>();

            stack.Pop();
        }

        [TestMethod]
        public void TestStackToArrayMethodShouldReturnSameArrayReversed()
        {
            ArrayStack<int> stack = new ArrayStack<int>();
            int[] arr = {1, 2, 3, 4, 5};
            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(arr[i]);
            }

            int[] result = stack.ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], result[arr.Length-1-i]);
            }
        }

        [TestMethod]
        public void TestToArrayMethodWithEmptyStackShouldReturnEmptyArray()
        {
            ArrayStack<int> stack = new ArrayStack<int>();

            int[] result = stack.ToArray();

            Assert.AreEqual(0, result.Length);
        }
    }
}
