using Searching.SymbolTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.Tests;

public class LinearProbingHashTableTests
{

	[Fact]
	public void LinearProbingHashTable_ShouldWork_AsExpected()
	{
		var table = new LinearProbingHashTable<string, int>();
		table.Put("E", 44);
		table.Put("N", 14);
		table.Put("R", 54);
		table.Put("W", 74);
		table.Put("Q", 43);
		table.Put("H", 64);
		table.Put("F", 58);
		table.Put("X", 17);
		table.Put("Z", 31);
		table.Put("P", 70);
		table.Put("T", 79);
		table.Put("U", 20);
		table.Put("O", 31);

		table.Delete("Z");
	}
	

}

