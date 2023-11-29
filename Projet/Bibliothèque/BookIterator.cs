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
        public class Iterator<T> : IIterator<T>
        {
            private List<T> items;
            private int currentIndex;

            public Iterator(List<T> items)
            {
                this.items = items;
                this.currentIndex = 0;
            }

            public T Next()
            {
                if (HasNext())
                {
                    T nextItem = items[currentIndex];
                    currentIndex++;
                    return nextItem;
                }
                else
                {
                    throw new InvalidOperationException("No more items in the iterator.");
                }
            }

            public bool HasNext()
            {
                return currentIndex < items.Count;
            }
        }


    }
}
