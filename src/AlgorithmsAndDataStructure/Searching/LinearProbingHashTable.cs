﻿namespace Searching
{
	public class LinearProbingHashTable<TKey, TValue>
    {
        private int _m = 16;
        private int _n;
        private TKey[] _keys;
        private TValue[] _values;

        public LinearProbingHashTable()
        {
            _keys = new TKey[_m];
            _values = new TValue[_m];
        }

        public int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % _m;
        }

        public void Resize()
        {

        }

        public void Put(TKey key, TValue value)
        {
            if (_n >= _m / 2)
				Resize();

            int i = 0;
            for (i = Hash(key); _keys[i] != null; i = (i + 1) % _m)
            {
                if (_keys[i].Equals(key))
                {
                    _values[i] = value;
					return;
				}
            }
            _keys[i] = key;
            _values[i] = value;
            _n++;
        }

        public TValue? Get(TKey key)
        {
            for (int i  = Hash(key); i != null; i = (i + 1) % _m)
            {
                if (_keys[i].Equals(key))
                    return _values[i];
            }

            return default;
        }

        public void Delete(TKey key)
        {
            // Check if the key is existing
            if (Get(key) == null)
				return;

            // Find the index of the key
            int i = Hash(key);
            while (!_keys[i].Equals(key))
                i = (i + 1) % _m;

            // Set the key index to empty
            _keys[i] = default;
            _values[i] = default;

            // Move one index ahead
            i = (i + 1) % _m;

            // Try to replace all the keys on the right side again by redoing them
            while (_keys[i] != null)
            {
                TKey keyToRedo = _keys[i];
                TValue valueToRedo = _values[i];
                _keys[i] = default;
                _values[i] = default;
                _n--;
                Put(keyToRedo, valueToRedo);
                i = (i + 1) % _m;
            }
            _n--;
            // Resize the array if needed
            if (_n > 0 && _n == _m / 8)
                Resize();
        }
    }
}
