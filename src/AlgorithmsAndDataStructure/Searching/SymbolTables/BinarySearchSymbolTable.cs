using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.SymbolTables;

public class BinarySearchSymbolTable<TKey, TValue> where TKey : IComparable<TKey>
{
	private const int DefaultCapacity = 4;
	private TKey[] _keys;
	private TValue[] _values;
	private int _n = 0;
	public BinarySearchSymbolTable(int capacity)
	{
		_keys = new TKey[capacity];
		_values = new TValue[capacity];
	}

	public BinarySearchSymbolTable() : this(DefaultCapacity)
	{
	}

	public int Count => _n;

	public bool IsEmpty => _n == 0;

	public TValue? Search(TKey key)
	{
		if (key == null)
			throw new ArgumentNullException("key");

		if (_keys.Length == 0)
			return default;

		var rank = Rank(key);
		if (rank < _n && key.CompareTo(_keys[rank]) == 0)
			return _values[rank];

		return default;
	}

	public void Insert(TKey key, TValue value)
	{
		if (key == null)
			throw new ArgumentNullException("key");

		if (value == null)
		{
			Delete(key);
			return;
		}

		// Key is already in the table 
		var rank = Rank(key);
		if (rank < _n && key.CompareTo(_keys[rank]) == 0)
		{
			_values[rank] = value;
			return;
		}

		// Check and resize
		if (_keys.Length == _n)
			Resize(_keys.Length * 2);

		for (int j = _n; j > rank; j--)
		{
			_keys[j] = _keys[j - 1];
			_values[j] = _values[j - 1];
		}

		_keys[rank] = key;
		_values[rank] = value;
		_n++;
	}

	public void Delete(TKey key)
	{
		if (key == null)
			throw new ArgumentNullException("key");

		var i = Rank(key);
		if (i < _n && key.CompareTo(_keys[i]) != 0)
		{
			return;
		}
		
		for(int j = i; j < _n - 1; j++)
		{
			_keys[j] = _keys[j + 1];
			_values[j] = _values[j + 1];
		}

		_n--;
		_keys[_n] = default;
		_values[_n] = default;
		if (_n == _keys.Length / 4)
		{
			Resize(_keys.Length / 2);
		}
	}

	public int Rank(TKey key)
	{
		if (key == null)
			throw new ArgumentNullException(nameof(key));

		int low = 0;
		int high = _n;
		while (low <= high)
		{
			int mid = low + (high - low) / 2;
			var value = _keys[mid];
			if (key.CompareTo(value) == 0)
			{
				return mid;
			}
			else if (key.CompareTo(value) < 0)
			{
				high = mid - 1;
			}
			else
			{
				low = mid + 1;
			}
		}
		return low;
	}

	public void Resize(int capacity)
	{
		var tempKeys = new TKey[capacity];
		var tempValues = new TValue[capacity];
		for (int i = 0;i < _n;i++)
		{
			tempKeys[i] = _keys[i];
			tempValues[i] = _values[i];
		}

		_keys = tempKeys;
		_values = tempValues;
	}


}
