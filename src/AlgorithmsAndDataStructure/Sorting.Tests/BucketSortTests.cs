using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Tests
{
	public class BucketSortTests
	{

		[Theory]
		[InlineData(new int[] { 20, 88, 70, 85, 75, 95, 18, 82, 60 }, 5, new int[] { 18, 20, 60, 70, 75, 82, 85, 88, 95 })]
		public void Sort_Returns_Sorted_Array(int[] unsorted, int k, int[] expected)
		{
			// Arrange
			var array = unsorted;

			// Act
			BucketSort.Sort(array, k);

			// Assert
			Assert.Equal(expected, array);
		}


	}
}
