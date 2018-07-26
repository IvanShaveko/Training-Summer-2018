using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Tests
{
    public class Book : IComparable<Book>
    {
        private readonly string _title;

        public Book(string title)
        {
            _title = title;
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            if (Title == other.Title)
            {
                return 0;
            }
            return _title.Length - other._title.Length > 0 ? 1 : -1;
        }

        public string Title => _title;
    }
}
