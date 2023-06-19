using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Tests
{
	public class CountingSortTests
	{

		[Theory]
		[InlineData(new int[] { 1, 4, 4, 1, 0, 1 }, 5, new int[] { 0, 1, 1, 1, 4, 4 })]
		public void NaiveSort_Returns_Sorted_Array(int[] unsorted, int k,int[] expected)
		{
			// Arrange
			var array = unsorted;

			// Act
			CountingSort.NaiveSort(array, k);

			// Assert
			Assert.Equal(expected, array);
		}

		[Theory]
		[InlineData(new int[] { 1, 4, 4, 1, 0, 1 }, 5, new int[] { 0, 1, 1, 1, 4, 4 })]
		public void Sort_Returns_Sorted_Array(int[] unsorted, int k, int[] expected)
		{
			// Arrange
			var array = unsorted;

			// Act
			CountingSort.Sort(array, k);

			// Assert
			Assert.Equal(expected, array);
		}


	}
}
