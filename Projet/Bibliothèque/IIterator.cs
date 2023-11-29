using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    internal interface IIterator
    {
        public interface IIterator<T>
        {
            T Next();
            bool HasNext();
        }
    }
}
