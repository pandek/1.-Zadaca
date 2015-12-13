
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;

        private X[] pomocnaLista;

        private int _initialSize;

        private int size;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int _initialSize)
        {
            _internalStorage = new X[_initialSize];
        }

        public void Add(X item)
        {
            if ((size + 1) > _internalStorage.Length)
            {
                pomocnaLista = new X[_internalStorage.Length * 2];

                for (int i = 0; i < size; i++)
                {
                    pomocnaLista[i] = _internalStorage[i];
                }

                pomocnaLista[size] = item;
                _internalStorage = pomocnaLista;
                pomocnaLista = null;
            }
            else
            {
                _internalStorage[size] = item;
            }
            size++;
        }


        public bool Remove(X item)
        {

            for (int i = 0; i <= size; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index > size)
            {
                return false;
            }
            _internalStorage[index] = default(X);

            for (int i = index; i < (size - 1); i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            size--;
            return true;

        }

        public X GetElement(int index)
        {
            if (index < size)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new System.IndexOutOfRangeException("Greska");
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public void Clear()
        {
            int i = _internalStorage.Length;
            _internalStorage = null;
            _internalStorage = new X[i];
            size = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class GenericListEnumerator<T> : IEnumerator<T>
        {
            private IGenericList<T> _collection;

            private T sljedeci;

            private int preostalo, size;
            public GenericListEnumerator(IGenericList<T> collection)
            {
                _collection = collection;
                preostalo = _collection.Count;
            }
            public bool MoveNext()
            {
                if (preostalo == 0)
                {
                    return false;
                }
                preostalo--;
                sljedeci = _collection.GetElement(preostalo);
                return preostalo >= 0;
            }
            public T Current
            {
                get
                {
                    return sljedeci;
                }
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
            public void Dispose()
            {
            }
            public void Reset()
            {
            }
        }
    }
}
