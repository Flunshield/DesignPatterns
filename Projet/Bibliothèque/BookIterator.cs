using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bibliothèque.IIterator;

namespace Bibliothèque
{
    internal class BookIteratorr
    {
        public class BookIterator : IIterator<Book>
        {
            private List<Book> books;
            private int currentIndex;

            public BookIterator(List<Book> books)
            {
                this.books = books;
                this.currentIndex = 0;
            }

            public Book Next()
            {
                if (HasNext())
                {
                    Book nextBook = books[currentIndex];
                    currentIndex++;
                    return nextBook;
                }
                else
                {
                    throw new InvalidOperationException("No more books in the iterator.");
                }
            }

            public bool HasNext()
            {
                return currentIndex < books.Count;
            }
        }

    }
}
