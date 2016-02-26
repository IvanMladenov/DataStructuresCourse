using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedStack;

namespace LinkedStackTests
{
    using System.Collections.Generic;

    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class LinkedStackTests
        {
            [TestMethod]
            public void TestPushPopElementAndCount_ShouldChangeCountAndElementMustBeTheSameAfterPop()
            {
                var numberToPush = 5;
                var stack = new LinkedStack<int>();

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
                var stack = new LinkedStack<string>();

                for (int i = 0; i < elements.Length; i++)
                {
                    Assert.AreEqual(i, stack.Count);

                    var currentString = "Ivan" + i;

                    elements[i] = currentString;
                    stack.Push(currentString);
                }

                for (int i = elements.Length - 1; i >= 0; i--)
                {
                    Assert.AreEqual(i, stack.Count - 1);
                    Assert.AreEqual(elements[i], stack.Pop());
                }
            }

            [TestMethod]
            [ExpectedException(typeof(InvalidOperationException))]
            public void PopFromEmptyStack_ShouldThrowExeption()
            {
                var stack = new LinkedStack<bool>();
                stack.Pop();
            }

            [TestMethod]
            public void TestToArrayMethod_TheArraysShouldBeEqualAfterReverseOfReturned()
            {
                var stack = new LinkedStack<int>();
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
                var stack = new LinkedStack<List<Dictionary<bool[], decimal>>>();

                var arr = stack.ToArray();

                Assert.AreEqual(0, arr.Length);
            }
        }
    }
}
