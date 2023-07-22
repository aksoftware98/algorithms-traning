using Searching.SymbolTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.Tests;

public class BinarySearchSymbolTableTests
{

	[Fact]
	public void BinarySearchSymbolTable_ShouldWork_AsExpected()
	{
		var table = new BinarySearchSymbolTable<string, int>();
		table.Insert("E", 44);
		table.Insert("N", 14);
		table.Insert("R", 54);
		table.Insert("W", 74);
		table.Insert("Q", 43);
		table.Insert("H", 64);
		table.Insert("F", 58);
		table.Insert("X", 17);
		table.Insert("Z", 31);
		table.Insert("P", 70);
		table.Insert("T", 79);
		table.Insert("U", 20);
		table.Insert("O", 31);


		Assert.Equal(14, table.Search("N"));
		Assert.Equal(20, table.Search("U"));

	}

}

public class BSTSymbolTableTests
{
	[Fact]
	public void BSTSymbolTable_ShouldWork_AsExpected()
	{
		var bst = new BinarySearchTreeSymbolTable<string, int>();

		bst.Insert("E", 44);
		bst.Insert("N", 14);
		bst.Insert("R", 54);
		bst.Insert("W", 74);
		bst.Insert("Q", 43);
		bst.Insert("H", 64);
		bst.Insert("F", 58);
		bst.Insert("X", 17);
		bst.Insert("Z", 31);
		bst.Insert("P", 70);
		bst.Insert("T", 79);
		bst.Insert("U", 20);
		bst.Insert("O", 31);

		var range = bst.Range("Q", "Z");

		Assert.Equal("Z", bst.Select(12));

		Assert.Equal(14, bst.SearchLoop("N"));
		Assert.Equal(20, bst.SearchLoop("U"));

		bst.Delete("R");

		bst.DeleteMin();
		bst.DeleteMax();



	}
}
