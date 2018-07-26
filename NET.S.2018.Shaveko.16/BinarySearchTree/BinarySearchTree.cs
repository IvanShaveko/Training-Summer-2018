using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    /// <summary>
    /// Binary search tree
    /// </summary>
    /// <typeparam name="T">
    /// T
    /// </typeparam>
    public class BinarySearchTree<T> : IEnumerable<T> 
    {
        #region Fields

        private Node<T> _root;
        private readonly Comparison<T> _comparer;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BinarySearchTree()
        {
            _comparer = Comparer<T>.Default.Compare;
        }

        /// <summary>
        /// Costructor with delegate
        /// </summary>
        /// <param name="comparer">
        /// Delegate comparison
        /// </param>
        public BinarySearchTree(Comparison<T> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Constructor with interfac
        /// </summary>
        /// <param name="comparer">
        /// Interface ICOmparer
        /// </param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            _comparer = comparer.Compare;
        }

        /// <summary>
        /// Constructor with collection
        /// </summary>
        /// <param name="items">
        /// Collection of items
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <see cref="items"/> is null
        /// </exception>
        public BinarySearchTree(IEnumerable<T> items) : this()
        {
            if (items == null)
            {
                throw new ArgumentNullException($"{nameof(items)} ca not be null");
            }

            foreach (var item in items)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Constructor with collection and delgate
        /// </summary>
        /// <param name="items">
        /// Collection of items
        /// </param>
        /// <param name="comparer">
        /// Delegate
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <see cref="items"/> is null
        /// </exception>
        public BinarySearchTree(IEnumerable<T> items, Comparison<T> comparer) : this(comparer)
        {
            if (items == null)
            {
                throw new ArgumentNullException($"{nameof(items)} ca not be null");
            }

            foreach (var item in items)
            {
                Add(item);
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Property of count 
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item">
        /// Item
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <see cref="item"/> is null
        /// </exception>
        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException($"{nameof(item)} con not be null");
            }

            _root = Add(_root, item);
            Count++;
        }

        /// <summary>
        /// Check contains item of not
        /// </summary>
        /// <param name="item">
        /// Item
        /// </param>
        /// <returns>
        /// True or false
        /// </returns>
        public bool Contains(T item) => Contains(_root, item);

        #endregion

        #region Iterator

        /// <summary>
        /// Iterator of interface IEnumerator with type 
        /// </summary>
        /// <returns>
        /// GetRnumerator
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        /// <summary>
        /// Iterator of interface IEnumerator with type 
        /// </summary>
        /// <returns>
        /// GetEnumerator
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Pre order method
        /// </summary>
        /// <returns>
        /// Items in pre order
        /// </returns>
        public IEnumerable<T> PreOrder()
        {
            if (_root == null)
            {
                yield break;
            }

            foreach (var item in PreOrder(_root))
            {
                yield return item;
            }
        }

        /// <summary>
        /// In order method
        /// </summary>
        /// <returns>
        /// Items in in order
        /// </returns>
        public IEnumerable<T> InOrder()
        {
            if (_root == null)
            {
                yield break;
            }

            foreach (var item in InOrder(_root))
            {
                yield return item;
            }
        }

        /// <summary>
        /// Post order method
        /// </summary>
        /// <returns>
        /// Items in post order
        /// </returns>
        public IEnumerable<T> PostOrder()
        {
            if (_root == null)
            {
                yield break;
            }

            foreach (var item in PostOrder(_root))
            {
                yield return item;
            }
        }

        #endregion

        #region Private methods

        private Node<T> Add(Node<T> root, T item)
        {
            if (ReferenceEquals(root, null)) 
            {
                return new Node<T>(item);
            }

            if (_comparer(root.Value, item) > 0)
            {
                root.Left = Add(root.Left, item);
            }
            else
            {
                root.Right =  Add(root.Right, item);
            }

            return root;
        }

        private bool Contains(Node<T> root, T item)
        {
            while (true)
            {
                if (root == null)
                {
                    return false;
                }

                if (_comparer(root.Value, item) == 0)
                {
                    return true;
                }

                root = _comparer(root.Value, item) > 0 ? root.Left : root.Right;
            }
        }

        private IEnumerable<T> PreOrder(Node<T> root)
        {
            yield return root.Value;

            if (root.Left != null)
            {
                foreach (var item in PreOrder(root.Left))
                {
                    yield return item;
                }
            }

            if(root.Right != null)
            {
                foreach (var item in PreOrder(root.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> InOrder(Node<T> root)
        {
            while (true)
            {
                if (root.Left != null)
                {
                    foreach (var item in InOrder(root.Left))
                    {
                        yield return item;
                    }
                }

                yield return root.Value;

                if (root.Right != null)
                {
                    root = root.Right;
                    continue;
                }

                break;
            }
        }

        private IEnumerable<T> PostOrder(Node<T> root)
        {
            if (root.Left != null)
            {
                foreach (var item in PostOrder(root.Left))
                {
                    yield return item;
                }
            }

            if (root.Right != null)
            {
                foreach (var item in PostOrder(root.Right))
                {
                    yield return item;
                }
            }

            yield return root.Value;
        }

        #endregion
    }
}
