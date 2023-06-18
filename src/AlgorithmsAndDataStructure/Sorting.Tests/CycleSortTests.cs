using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Tests
{
	public class CycleSortTests
	{
		[Theory]
		[InlineData(new int[] { 20, 40, 50, 10, 30 }, new int[] { 10, 20, 30, 40, 50 })]
		public void Sort_Returns_Sorted_Array(int[] unsorted, int[] expected)
		{
			// Arrange
			var array = unsorted;

			// Act
			CycleSort.Sort(array);

			// Assert
			Assert.Equal(expected, array);
		}
	}
}
