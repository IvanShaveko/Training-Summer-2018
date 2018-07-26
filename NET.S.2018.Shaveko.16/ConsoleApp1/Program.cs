using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;
using BinarySearchTree.Tests;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new[] { new Book("I"), new Book("Ok"), new Book("Ro"), new Book("Lok") };
            var tree = new BinarySearchTree<Book>(new[] { new Book("I"), new Book("Ok"), new Book("Lok"), new Book("Ro") });

            int i = 0;
            foreach (var item in tree)
            {
                Console.WriteLine(item.Title);
            }

            Console.ReadKey();
        }
    }
}
