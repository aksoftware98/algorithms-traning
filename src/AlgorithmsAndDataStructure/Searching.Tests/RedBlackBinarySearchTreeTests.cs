using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.Tests;

public class RedBlackBinarySearchTreeTests
{

	[Fact]
	public void RedBlackBST_Should_WorkAsExpected()
	{
		var bst = new RedBlackBinarySearchTree<string, int>();

		bst.Insert("S", 3);
		bst.Insert("E", 55);
		bst.Insert("A", 38);
		bst.Insert("R", 41);
		bst.Insert("C", 67);
		bst.Insert("H", 33);
		bst.Insert("X", 51);
		bst.Insert("M", 23);
		bst.Insert("P", 51);
		bst.Insert("L", 12);
		
		Assert.Equal(3, bst.Search("S"));
		Assert.Equal(51, bst.Search("X"));
		Assert.Equal(12, bst.Search("L"));


		Assert.Equal("X", bst.Max());
		Assert.Equal("A", bst.Min());
	}

}
