using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching;

public class FrequencyCounter
{

}

public class SequentialSearchSymbolTable<TKey, TValue>
{

	public class Node
	{
		public Node(TKey key, TValue value, SequentialSearchSymbolTable<TKey, TValue>.Node? next)
		{
			Key = key;
			Value = value;
			Next = next;
		}

		public TKey Key { get; set; }

		public TValue Value { get; set; }

		public Node Next { get; set; }
	}

	private Node? _first;

	public TValue? Get(TKey key)
	{
		if (key == null)
			throw new ArgumentNullException(nameof(key));
		if (_first == null)
			return default;
		for(Node x = _first; x != null; x = x.Next)
		{
			if (key.Equals(x.Key))
				return x.Value;
		}
		return default;
	}

	public void Put(TKey key, TValue value)
	{
		if (key == null)
			throw new ArgumentNullException(nameof(key));
		if (_first == null)
		{
			_first = new Node(key, value, null);
			return;
		}
		for(Node x = _first; x != null; x = x.Next)
		{
			if (key.Equals(x.Key))
			{
				x.Value = value;
				return; 
			}
		}
		_first = new Node(key, value, _first);

	}

}
