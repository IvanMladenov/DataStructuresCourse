using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayBasedStack;

namespace ArrayBasedStackTests
{
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void TestPushPopElementAndCount_ShouldChangeCountAndElementMustBeTheSameAfterPop()
        {
            var numberToPush = 5;
            var stack = new ArrayStack<int>();

            Assert.AreEqual(0, stack.Count);

            stack.Push(numberToPush);

            Assert.AreEqual(1, stack.Count);

            var popedNumber = stack.Pop();

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(numberToPush, popedNumber);
        }

        [TestMethod]
        public void PushPopTosendElements_TheCountShouldBeCorrectWillTestAutoGrowTheStringsShouldBeTheSame()
        {
            var elements = new string[1000];
            var stack = new ArrayStack<string>();

            for (int i = 0; i < elements.Length; i++)
            {
                Assert.AreEqual(i, stack.Count);

                var currentString = "Ivan" + i;

                elements[i] = currentString;
                stack.Push(currentString);
            }

            for (int i = elements.Length-1; i >=0 ; i--)
            {
                Assert.AreEqual(i, stack.Count-1);
                Assert.AreEqual(elements[i], stack.Pop());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStack_ShouldThrowExeption()
        {
            var stack = new ArrayStack<bool>();
            stack.Pop();
        }

        [TestMethod]
        public void TestStackWithInitialCapacityOfOne()
        {
            int numberOne = 1;
            int numberTwo = 2;
            var stack = new ArrayStack<int>(1);

            Assert.AreEqual(0, stack.Count);
            stack.Push(numberOne);
            Assert.AreEqual(1, stack.Count);
            stack.Push(numberTwo);
            Assert.AreEqual(2, stack.Count);
            Assert.AreEqual(numberTwo, stack.Pop());
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(numberOne, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestToArrayMethod_TheArraysShouldBeEqualAfterReverseOfReturned()
        {
            var stack = new ArrayStack<int>();
            var arrToTest = new int[100];

            for (int i = 0; i < arrToTest.Length; i++)
            {
                stack.Push(i);
                arrToTest[i] = i;
            }

            var returnedArray = stack.ToArray();
            Array.Reverse(returnedArray);

            CollectionAssert.AreEqual(arrToTest, returnedArray);
        }

        [TestMethod]
        public void TestEmptyStackToArray_ShouldReturnEmptyArray()
        {
            var stack = new ArrayStack<List<Dictionary<bool[], decimal>>>();

            var arr = stack.ToArray();

            Assert.AreEqual(0, arr.Length);
        }
    }
}
