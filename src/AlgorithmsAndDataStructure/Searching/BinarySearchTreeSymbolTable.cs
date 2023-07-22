using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
	public class BinarySearchTreeSymbolTable<TKey, TValue> where TKey : IComparable<TKey>
	{

		#region Node
		public class Node
		{
			public Node(TKey key,
						TValue? value,
						BinarySearchTreeSymbolTable<TKey, TValue>.Node? right,
						BinarySearchTreeSymbolTable<TKey, TValue>.Node? left,
						int n)
			{
				Key = key;
				Value = value;
				Right = right;
				Left = left;
				N = n;
			}

			public TKey Key { get; set; }

			public TValue? Value { get; set; }

			public Node? Right { get; set; }

			public Node? Left { get; set; }
			public int N { get; set; }
		}
		#endregion

		public Node? Root { get; set; }

		public int Count => Root?.N ?? 0;

		public TValue? Search(TKey key)
		{
			if (key == null)
				throw new ArgumentNullException(nameof(key));

			return Search(key, Root);

		}

		public TValue? Search(TKey key, Node? node)
		{
			if (node == null)
				return default;

			var result = key.CompareTo(node.Key);
			if (result == 0)
				return node.Value;
			else if (result > 0)
				return Search(key, node.Right);
			else
				return Search(key, node.Left);
		}

		public TValue SearchLoop(TKey key)
		{
			if (key == null)
				throw new ArgumentNullException(nameof(key));

			TValue? value = default;
			Node? node = Root;
			while(node != null)
			{
				var compare = key.CompareTo(node.Key);
				if (compare > 0 && node.Right != null)
				{
					node = node.Right;
				}
				else if (compare < 0 && node.Left != null)
				{
					node = node.Left;
				}
				else
				{
					return node.Value;
				}
			}
			return value; 
		}

		public void Insert(TKey key, TValue value)
		{
			Root = Insert(key, value, Root);
		}

		private Node Insert(TKey key, TValue value, Node? node)
		{
			if (key == null)
				throw new ArgumentNullException(nameof(key));

			if (node == null)
				return new Node(key, value, null, null, 1);

			var result = key.CompareTo(node.Key);
			if (result == 0)
				node.Value = value;
			if (result > 0)
			{
				node.Right = Insert(key, value, node.Right);
			}
			else
			{
				node.Left = Insert(key, value, node.Left);
			}
			node.N = (node.Left?.N ?? 0) + (node.Right?.N ?? 0) + 1;
			return node;
		}

		public void Delete(TKey key)
		{
			if (key == null)
				throw new ArgumentNullException(nameof(key));

			Root = Delete(key, Root);
		}

		public Node? Delete(TKey key, Node? node)
		{
			if (key == null)
				throw new ArgumentNullException(nameof(key));

			if (node == null)
				return null; 

			var compare = key.CompareTo(node.Key);
			if (compare == 0)
			{
				if (node.Right == null)
					return node.Left;
				if (node.Left == null)
					return node.Right;
				var temp = node;
				node = Min(temp.Right);
				node.Right = DeleteMin(temp.Right);
				node.Left = temp.Left;
			}
			else if (compare > 0)
			{
				node.Right = Delete(key, node.Right);
			}
			else if (compare < 0)
			{
				node.Left = Delete(key, node.Left);
			}
			node.N = (node.Left?.N ?? 0) + (node.Right?.N ?? 0) + 1;
			return node;
		}

		public void DeleteMin()
		{
			Root = DeleteMin(Root);
		}

		public Node? DeleteMin(Node? root)
		{
			if (root == null)
				return null;

			if (root.Left == null)
				return root.Right;

			root.Left = DeleteMin(root.Left);
			root.N = (root.Left?.N ?? 0) + (root.Right?.N ?? 0) + 1;
			return root;
		}

		public void DeleteMax()
		{
			Root = DeleteMax(Root);
		}

		public Node? DeleteMax(Node? node)
		{
			if (node == null) return null;

			if (node.Right == null) 
				return node.Left;

			node.Right = DeleteMax(node.Right);
			node.N = (node.Right?.N ?? 0) + (node.Left?.N ?? 0) + 1;
			return node;
		}

		public TKey Min()
		{
			if (Root == null)
				throw new InvalidOperationException("Tree is empty");

			return Min(Root).Key;
		}

		public Node Min(Node? node)
		{
			if (node.Left == null)
				return node;
			return Min(node.Left);
		}

		public TKey Max()
		{
			if (Root == null)
				throw new InvalidOperationException("Tree is empty");
			return Max(Root).Key;
		}

		public Node Max(Node? node)
		{
			if (node == null)
				return null; 
			return Max(node.Right);
		}

		public TKey Select(int rank)
		{
			if (rank < 0 || rank >= Count)
				throw new ArgumentOutOfRangeException(nameof(rank));

			return Select(Root, rank).Key;
		}

		public Node Select(Node node, int rank)
		{
			if (node == null)
				return null;

			int leftSize = node.Left?.N ?? 0;
			if (leftSize > rank)
			{
				return Select(node.Left, rank);
			}
			else if (leftSize < rank)
			{
				return Select(node.Right, rank - leftSize - 1);
			}
			else
				return node;
		}

		public IEnumerable<TKey> All()
		{
			return Range(Min(), Max());
		}

		public IEnumerable<TKey> Range(TKey low, TKey high)
		{
			var queue = new Queue<TKey>();
			AddKeysToQueue(Root, low, high, queue);
			return queue;
		}

		private void AddKeysToQueue(Node? node, TKey low, TKey high, Queue<TKey> queue)
		{
			if (node == null)
				return;
			var compareLow = low.CompareTo(node.Key);
			var compareHigh = high.CompareTo(node.Key);
			if (compareLow < 0)
				AddKeysToQueue(node.Left, low, high, queue);
			if (compareHigh > 0)
				AddKeysToQueue(node.Right, low, high, queue);
			if (compareLow <= 0 && compareHigh >= 0)
				queue.Enqueue(node.Key);
		}
	}
}
