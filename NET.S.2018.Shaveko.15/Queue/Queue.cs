using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    /// <summary>
    /// Queue
    /// </summary>
    /// <typeparam name="T">
    /// Type
    /// </typeparam>
    public class Queue<T>
    {
        #region Fields

        private const int DefaultCapacity = 4; 

        private T[] _queue;
        private int _head;
        private int _tail;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Queue()
        {
            _queue = new T[DefaultCapacity];
            Count = 0;
            _head = 0;
            _tail = 0;
        }

        /// <summary>
        /// /Constructor with size
        /// </summary>
        /// <param name="size">
        /// Size of queue
        /// </param>
        public Queue(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException($"{nameof(size)} must be grater than 0");
            }

            _queue = new T[size];
            Count = 0;
            _head = 0;
            _tail = 0;
        }

        /// <summary>
        /// Constructor with array
        /// </summary>
        /// <param name="queue">
        /// Array
        /// </param>
        public Queue(T[] queue)
        {
            _queue = queue;
            Count = queue.Length;
            _tail = Count;
            _head = 0;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Property of count 
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///  Property of version
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// Addd item to queue
        /// </summary>
        /// <param name="item">
        /// Item which added
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws when item is null
        /// </exception>
        public void Enqueue(T item)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException($"{nameof(item)} can not be null");
            }

            if (Count == _queue.Length)
            {
                Array.Resize(ref _queue, Count * 2);
            }

            _queue[_tail++] = item;
            Count++;
            Version++;
        }

        /// <summary>
        /// Remove first item
        /// </summary>
        /// <returns>
        /// Returns new queue
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Throws when queue is null
        /// </exception>
        public T Dequeue()
        {
            if (_queue.Length == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var result = _queue[_head];
            _queue[_head++] = default(T);
            Count--;
            Version++;
            return result;
        }

        /// <summary>
        /// Get first element
        /// </summary>
        /// <returns>
        /// Returns first element
        /// </returns>
        public T Peek()
        {
            if (_queue.Length == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _queue[_head];
        }

        /// <summary>
        /// Check queue contains this item
        /// </summary>
        /// <param name="item">
        /// Item
        /// </param>
        /// <returns>
        /// True or false
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throws when item is null
        /// </exception>
        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException($"{nameof(item)} can not be null");
            }

            return _queue.Contains(item);
        }

        /// <summary>
        /// Clear queue
        /// </summary>
        public void Clear()
        {
            _head = 0;
            _tail = 0;
            Count = 0;
            Version++;
            Array.Clear(_queue, 0, _queue.Length);
        }

        /// <summary>
        /// To array
        /// </summary>
        /// <returns>
        /// Array of elements
        /// </returns>
        public T[] ToArray() => _queue.ToArray();

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>
        /// Returns iterator
        /// </returns>
        public CustomIterator GetEnumerator() => new CustomIterator(this);

        /// <summary>
        /// Struct of custom iterator
        /// </summary>
        public struct CustomIterator
        {
            private readonly Queue<T> _queue;
            private int _currentIndex;
            private readonly int _version;
            
            /// <summary>
            /// Constructor of enumerator
            /// </summary>
            /// <param name="queue">
            /// Queue
            /// </param>
            public CustomIterator(Queue<T> queue)
            {
                _queue = queue;
                _currentIndex = -1;
                _version = queue.Version;
            }

            /// <summary>
            /// Property of current
            /// </summary>
            /// <exception cref="InvalidOperationException">
            /// Throws when index is -1 or count
            /// </exception>
            public T Current
            {
                get
                {
                    if (_currentIndex == - 1 || _currentIndex == _queue.Count)
                    {
                        throw new InvalidOperationException();
                    }

                    return _queue._queue[_currentIndex];
                }
            }

            /// <summary>
            /// Make index -1
            /// </summary>
            public void Reset() => _currentIndex = -1;

            /// <summary>
            /// Move to next element
            /// </summary>
            /// <returns>
            /// True or false
            /// </returns>
            /// <exception cref="InvalidOperationException">
            /// Throws when version ic changed
            /// </exception>
            public bool MoveNext()
            {
                if (_version != _queue.Version)
                {
                    throw new InvalidOperationException("Queue was modified");
                }

                return ++_currentIndex < _queue.Count;  
            }
        }

        #endregion
    }
}
