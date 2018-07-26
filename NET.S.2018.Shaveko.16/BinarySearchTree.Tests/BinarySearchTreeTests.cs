using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void BinarySearchTree_Contains_Int()
        {
            var tree = new BinarySearchTree<int> {15, 55, 44};

            Assert.IsTrue(tree.Contains(15));
            Assert.IsTrue(tree.Contains(44));
            Assert.IsFalse(tree.Contains(32));
        }

        [TestCase(new[] {1, 22, 13}, 15, ExpectedResult = true)]
        [TestCase(new[] { 1, 22, 13 }, 84, ExpectedResult = true)]

        public bool BinarySearchTree_Add_Int(int[] array, int item)
        {
            var tree = new BinarySearchTree<int>(array);

            tree.Add(item);

            return tree.Contains(item);
        }

        [TestCase(new[] { 6, 3, 8, 4 }, ExpectedResult = new[] { 6, 3, 4, 8 })]

        public IEnumerable<int> BinarySearchTree_PreOrder_Foreach_Int(int[] array)
        {
            var tree = new BinarySearchTree<int>(array);

            return tree.PreOrder();
        }

        [TestCase(new[] { 6, 3, 8, 4 }, ExpectedResult = new[] { 4, 3, 8, 6 })]

        public IEnumerable<int> BinarySearchTree_PostOrder_Foreach_Int(int[] array)
        {
            var tree = new BinarySearchTree<int>(array);

            return tree.PostOrder();
        }

        [TestCase(new[] { 6, 3, 8, 4 }, ExpectedResult = new[] { 3, 4, 6, 8 })]

        public IEnumerable<int> BinarySearchTree_InOrder_Foreach_Int(int[] array)
        {
            var tree = new BinarySearchTree<int>(array);

            return tree.InOrder();
        }

        [Test]
        public void BinarySearchTree_Contains_String()
        {
            var tree = new BinarySearchTree<string> { "Ivan", "Egor", "Sasha" };

            Assert.IsTrue(tree.Contains("Ivan"));
            Assert.IsTrue(tree.Contains("Sasha"));
            Assert.IsFalse(tree.Contains("Gleb"));
        }

        [TestCase(new[] { "Ivan", "Egor", "Sasha" }, "Gleb", ExpectedResult = true)]
        [TestCase(new[] { "Ivan", "Egor", "Sasha" }, "Vanya", ExpectedResult = true)]

        public bool BinarySearchTree_Add_String(string[] array, string item)
        {
            var tree = new BinarySearchTree<string>(array) { item };

            tree.Add(item);

            return tree.Contains(item);
        }

        [Test]
        public void BinarySearchTree_Contains_Book()
        {
            var book = new[] {new Book("I"), new Book("Ok"), new Book("Ro"), new Book("Lok") };
            var tree = new BinarySearchTree<Book>(new []{new Book("I"), new Book("Ok"), new Book("Lok"), new Book("Ro")});

            Assert.IsTrue(tree.Contains(book[1]));
        }
    }
}
