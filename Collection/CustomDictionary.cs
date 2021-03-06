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
        }
        private const int startCount = 8;
        private int currentSize = startCount;
        private int currentElement = 0;
        private Element[] customDictionary = new Element[startCount];


        public void Add(TKey key, TValue value)
        {
            // check if there is some place for new element
            if (currentElement == currentSize)
            {
                // increase size
                currentSize *= 2;
                Array.Resize(ref customDictionary, currentSize);
            }
            Element e = new Element();
            e.hashCode = key.GetHashCode();
            e.key = key;
            e.value = value;
            customDictionary[currentElement++] = e;

        }
        public void Clear()
        {
            Array.Clear(customDictionary, 0, customDictionary.Length);
            currentElement = 0;
            currentSize = startCount;
            Array.Resize(ref customDictionary, currentSize);

        }

        public bool ContainsKey(TKey key)
        {
            int hash = key.GetHashCode();
            foreach (Element el in customDictionary)
            {
                if (hash == el.hashCode && object.Equals(key, el.key))
                {
                    return true;
                }
            }
            return false;
        }
        private int FindIndex(TKey key)
        {
            int hash = key.GetHashCode();
            foreach (Element el in customDictionary)
            {
                if (hash == el.hashCode && object.Equals(key, el.key))
                {
                    return Array.IndexOf(customDictionary, el);
                }
            }
            return -1;
        }

        public bool Remove(TKey key)
        {
            int index = FindIndex(key);
            if (index >= 0)
            {
                customDictionary = customDictionary.Where((val, idx) => idx != index).ToArray();
                currentElement--;
                return true;
            }
            return false;
        }

        public TValue this[TKey key]
        {
            get
            {
                int index = FindIndex(key);
                if (index >= 0) return customDictionary[index].value;
                return default(TValue);
            }
            set {
                int index = FindIndex(key);
                if (index >= 0) customDictionary[index].value = value;
            }
        }

        public ICollection<TKey> Keys => getAllKeys();
        private ICollection<TKey> getAllKeys()
        {
            List<TKey> keys = new List<TKey>();

            foreach (Element el in customDictionary)
            {
                keys.Add(el.key);
            }

            return keys;
        }
        public ICollection<TValue> Values => getAllValues();
        private ICollection<TValue> getAllValues()
        {
            List<TValue> values = new List<TValue>();

            foreach (Element el in customDictionary)
            {
                values.Add(el.value);
            }

            return values;
        }

        public int Count => currentElement;

        public bool IsReadOnly => false;

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            int hash = key.GetHashCode();
            foreach (Element el in customDictionary)
            {
                if (hash == el.hashCode && object.Equals(key, el.key))
                {
                    value = el.value;
                    return true;
                }
            }
            value = default(TValue);
            return false;
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
