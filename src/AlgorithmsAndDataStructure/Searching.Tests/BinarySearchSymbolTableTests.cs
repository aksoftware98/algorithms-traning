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
