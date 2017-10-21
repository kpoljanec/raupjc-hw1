using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _counter;

        public IntegerList()
        {
            _internalStorage = new int[4];
            _counter = 0;
        }

        public IntegerList(int initialSize)
        {
            if (initialSize > 0)
            {
                _internalStorage = new int[initialSize];
                _counter = 0;
            }
            else
            {
                throw new ArgumentException("Initial size must be greater than zero!");
            }
        }

        public void Add(int item)
        {
            if (_counter == _internalStorage.Length - 1)
            {
                int[] tmp = _internalStorage;
                _internalStorage = new int[_internalStorage.Length * 2];
                Array.Copy(tmp, _internalStorage, tmp.Length);
            }
            _internalStorage[_counter++] = item;
        }

        public bool RemoveAt(int index)
        {
            if (index > _counter)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            else
            {
                _internalStorage[index] = 0;
                for (int i = index; i < _counter; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                _counter--;
                return true;
            }
        }

        public bool Remove(int item)
        {
            for (int i = 0; i < _counter; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index > _counter)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            return _internalStorage[index];
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _counter; i++)
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
                return _counter;
            }
        }

        public void Clear()
        {
            _internalStorage = new int[_internalStorage.Length];
            _counter = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _counter; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
