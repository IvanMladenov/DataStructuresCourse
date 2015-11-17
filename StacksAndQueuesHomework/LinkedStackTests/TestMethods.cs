using System;
using LinkedStack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedStackTests
{
    [TestClass]
    public class TestMethods
    {
        [TestMethod]
        public void TestPushPopSingleElementShouldChangeCountPopTheSameElementLikePushed()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
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
            LinkedStack<int> stack = new LinkedStack<int>();

            for (int i = 1; i <= 1000; i++)
            {
                Assert.AreEqual(i - 1, stack.Count);
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
        [ExpectedException(typeof(InvalidOperationException), "Stack is empty")]
        public void PopFromEmptyStackShouldThrowExeption()
        {
            LinkedStack<int> stack = new LinkedStack<int>();

            stack.Pop();
        }

        [TestMethod]
        public void TestStackToArrayMethodShouldReturnSameArrayReversed()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            int[] arr = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(arr[i]);
            }

            int[] result = stack.ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], result[arr.Length - 1 - i]);
            }
        }

        [TestMethod]
        public void TestToArrayMethodWithEmptyStackShouldReturnEmptyArray()
        {
            LinkedStack<int> stack = new LinkedStack<int>();

            int[] result = stack.ToArray();

            Assert.AreEqual(0, result.Length);
        }
    }
}
