using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching;

public class RedBlackBinarySearchTree<TKey, TValue> where TKey : IComparable<TKey>
{

	public const bool Red = true;
	public const bool Black = false; 

	public Node? Root { get; set; }


	public class Node
	{
		public Node(TKey key, TValue value,
					RedBlackBinarySearchTree<TKey, TValue>.Node? right,
					RedBlackBinarySearchTree<TKey, TValue>.Node? left,
					bool color, int count)
		{
			Key = key;
			Value = value;
			Right = right;
			Left = left;
			Color = color;
			Count = count;
		}

		public TKey Key { get; set; }

		public TValue Value { get; set; }

		public Node? Right { get; set; }

		public Node? Left { get; set; }

		public bool Color { get; set; }

		public int Count { get; set; }

		public int LeftCount => Left?.Count ?? 0;
		public int RightCount => Right?.Count ?? 0;
	}

	#region Rotation 
	private Node? RotateLeft(Node? node)
	{
		if (node == null) return null;
		var rightNode = node.Right;
		rightNode.Left = node;
		node.Right = rightNode.Left;
		rightNode.Color = node.Color;
		node.Color = Red;
		rightNode.Count = node.Count;
		node.Count = (rightNode?.Left?.Count ?? 0) + 1 + (rightNode?.Right?.Count ?? 0);
		return rightNode;
	}

	private Node? RotateRight(Node? node)
	{
		if (node == null) return null;
		var leftNode = node.Left;
		leftNode.Right = node;
		node.Left = leftNode.Right;
		leftNode.Color = node.Color;
		node.Color = Red;
		leftNode.Count = node.Count;
		node.Count = 1 + leftNode.LeftCount + leftNode.RightCount;
		return leftNode;
	}

	private void FlipColors(Node? node)
	{
		node.Color = Red;
		node.Right.Color = Black;
		node.Left.Color = Black;
	}
	#endregion

	#region Search 
	public TValue Search(TKey key)
	{
		if (key == null)
			throw new ArgumentNullException(nameof(key));

		return Search(key, Root);
	}

	public TValue? Search(TKey key, Node node)
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
	#endregion

	private bool IsRed(Node node)
	{
		return node.Color == Red;
	}

	#region Insert 
	public void Insert(TKey key, TValue value)
	{
		if (key == null)
			throw new ArgumentNullException(nameof(key));

		Root = Insert(key, value, Root);
	}

	private Node Insert(TKey key, TValue value, Node node)
	{
		if (node == null)
			return new Node(key, value, null, null, Red, 1);
		var result = key.CompareTo(node.Key);
		if (result == 0)
		{
			node.Value = value;
			return node;
		}
		else if (result > 0)
		{
			node.Right = Insert(key, value, node.Right);
		}
		else
			node.Left = Insert(key, value, node.Left);

		if (IsRed(node.Left) && !IsRed(node.Right))
			node = RotateLeft(node);
		if (!IsRed(node.Left) && IsRed(node.Right))
			node = RotateRight(node);
		if (IsRed(node.Left) && IsRed(node.Right))
			FlipColors(node);

		node.Count = 1 + node.LeftCount + node.RightCount;
		return node;
	}
	#endregion 

}
