using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Collection
{
    class CustomDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private struct Element
        {
            public int hashCode;
            public TKey key;
            public TValue value;
            public bool isActive; 
        }
        private const int startCount = 8;
        private int currentSize = startCount;
        private int lastElement = 0;
        private Element[] customDictionary = new Element[startCount];


        public void Add(TKey key, TValue value)
        {
            // check if null 
            if (key == null)
            {
                throw new Exception("Keys couldn't be null");
            }

            // find the same key 
            int index = FindIndex(key);
            if (index >= 0)
            {
                if (!customDictionary[index].isActive) 
                {
                    customDictionary[index].value = value;
                    customDictionary[index].isActive = true; 
                }
                else
                {
                    throw new Exception("Key already exists");
                }
            }

            createElement(key, value);

        }
        private void createElement(TKey key, TValue value)
        {
            // check if there is some place for new element
            if (lastElement == currentSize)
            {
                // increase size
                currentSize *= 2;
                Array.Resize(ref customDictionary, currentSize);
            }

            // create new element
            Element e = new Element();
            e.hashCode = key.GetHashCode();
            e.key = key;
            e.value = value;
            e.isActive = true;
            customDictionary[lastElement++] = e;
        }
        public void Clear()
        {
            Array.Clear(customDictionary, 0, customDictionary.Length);
            lastElement = 0;
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null) throw new Exception("Key is null");

            int index = FindIndex(key);
            if (index >= 0 && customDictionary[index].isActive)
            {
                return true;
            }
            return false;
        }
        private int FindIndex(TKey key)
        {
            int hash = key.GetHashCode();
            for (int i = 0; i < lastElement; i++)
            {
                if (hash == customDictionary[i].hashCode && object.Equals(key, customDictionary[i].key))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(TKey key)
        {
            if (key == null) throw new Exception("Key is null");

            int index = FindIndex(key);
            if (index >= 0)
            {
                customDictionary[index].isActive = false;
                return true;
            }
            throw new Exception("Key not found");
        }

        public TValue this[TKey key]
        {
            get
            {
                if (key == null) throw new Exception("Key is null");
                int index = FindIndex(key);
                if (index >= 0) return customDictionary[index].value;
                throw new Exception("Key not found");
            }
            set
            {
                if (key == null) throw new Exception("Key is null");
                int index = FindIndex(key);
                if (index >= 0)
                {
                    customDictionary[index].value = value;
                    customDictionary[index].isActive = true;
                }
                else
                {
                    createElement(key, value);
                }

            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();

                foreach (Element el in customDictionary)
                {
                    if (el.isActive) keys.Add(el.key);
                }

                return keys;
            }
        }
        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> values = new List<TValue>();

                foreach (Element el in customDictionary)
                {
                    if (el.isActive) values.Add(el.value);
                }

                return values;
            }
        }

        public int Count {
            get
            {
                int count = 0;
                for (int i = 0; i < lastElement; i++)
                {
                    if (customDictionary[i].isActive)
                    {
                        count++;
                    }
                }
                return count;

            }
        }

        public bool IsReadOnly => false;

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            if (key == null) throw new Exception("Key is null");
            int index = FindIndex(key);
            if (index >= 0 && customDictionary[index].isActive)
            {
                value = customDictionary[index].value;
                return true;
            }
            throw new Exception("Key not found");
        }

        // not ready
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
