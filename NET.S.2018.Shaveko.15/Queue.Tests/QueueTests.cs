using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Queue.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [TestCase(new[] {1, 2, 3, 4, 5}, ExpectedResult = 5)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 8, 9 }, ExpectedResult = 7)]
        [TestCase(new[] { 1, 2, 3 }, ExpectedResult = 3)]

        public int Queue_Count_Sucess(int[] array)
        {
            Queue<int> queue = new Queue<int>(array);
            return queue.Count;
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 8, 9 })]
        [TestCase(new[] { 1, 2, 3 })]

        public void Queue_Clear_Sucess(int[] array)
        {
            Queue<int> queue = new Queue<int>(array);
            queue.Clear();
            Assert.AreEqual(queue.Count, 0);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 18)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 8, 9 }, 32)]
        [TestCase(new[] { 1, 2, 3 }, 44)]

        public void Queue_Enqueue_Sucess(int[] array, int item)
        {
            Queue<int> queue = new Queue<int>(array);
            queue.Enqueue(item);
            Assert.AreEqual(queue.Count, array.Length + 1);
            Assert.IsTrue(queue.Contains(item));
        }

        [Test]
        public void Queue_ForEach()
        {
            var queue = new Queue<int>(new []{ 1, 2, 3, 4, 5, 6, 7, 8, 15, 28, 32});
            int[] array = queue.ToArray();
            int i = 0;
            foreach (var item in queue)
            {
                Assert.AreEqual(array[i++], item);
            }
        }
    }
}
