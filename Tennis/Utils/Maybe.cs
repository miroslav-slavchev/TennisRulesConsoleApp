using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Utils
{
    public class Maybe<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _items;

        public Maybe(T item) => _items = new[] { item };

        public Maybe() => _items = Array.Empty<T>();

        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
