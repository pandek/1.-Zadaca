using System;

namespace _1.DZ
{
    class IntegerList : IIntegerList
    {
        private int[] _internalStorage;

        private int[] pomocnaLista;

        private int _initialSize;

        private int size;

        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        public IntegerList(int _initialSize)
        {
            _internalStorage = new int[_initialSize];
        }

        public void Add(int item)
        {
            if ((size + 1) > _internalStorage.Length)
            {
                pomocnaLista = new int[_internalStorage.Length * 2];

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
    

        public bool Remove(int item)
        {

            for (int i = 0; i <= size; i++)
            {
                if (_internalStorage[i] == item)
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
            _internalStorage[index] = 0;

            for (int i = index; i < (size - 1); i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            size--;
            return true;

        }

        public int GetElement(int index)
        {
            if (index < size)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Greska");
            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i] == item)
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
            _internalStorage = new int[i];
            size = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < size; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            IntegerList listOfIntegers = new IntegerList();
            listOfIntegers.Add(1);
            listOfIntegers.Add(2);
            listOfIntegers.Add(3);
            listOfIntegers.Add(4);
            listOfIntegers.Add(5);
            // lista je [1,2,3,4,5]
            // Mičemo prvi element liste.
            listOfIntegers.RemoveAt(0);
            // Lista je [2,3,4,5]
            // Mičemo element liste čija je vrijednost "5".
            listOfIntegers.Remove(5);
            // Lista je [2,3,4]
            Console.WriteLine(listOfIntegers.Count);
            // 3
            Console.WriteLine(listOfIntegers.Remove(100));
            // false, nemamo element u vrijednosti 100
            Console.WriteLine(listOfIntegers.RemoveAt(5));
            // false, nemamo ništa na poziciji 5
            // Brišemo sav sadržaj kolekcije
            listOfIntegers.Clear();
            Console.WriteLine(listOfIntegers.Count);
            // 0
            Console.ReadLine();

        }
    }
}