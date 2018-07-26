using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    internal class Node<T>
    {
        internal Node<T> Left;
        internal Node<T> Right;

        /// <summary>
        /// Constructor of Node
        /// </summary>
        /// <param name="value"></param>
        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Property of value
        /// </summary>
        public T Value { get; set; }
    }
}
