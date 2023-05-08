using System;
namespace Sorting.Tests
{
	public class SelectionSortTests
	{
		[Fact]
		public void SelectionSortShouldSortProperly()
		{
			var array = new[] { 10, 5, 8, 20, 2, 18 };

			SelectionSort.Sort(array);

			Assert.True(array.SequenceEqual(new[] { 2, 5, 8, 10, 18, 20 }));
		}
	}
}

