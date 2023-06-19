using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Tests
{
	public class RadixSortTest
	{

		[Theory]
		[InlineData(new int[] { 319, 212, 6, 8, 100, 50 }, new int[] { 6, 8, 50, 100, 212, 319 })]
		public void Sort_Returns_Sorted_Array(int[] array, int[] expected)
		{
			// Act
			RadixSort.Sort(array);

			// Assert
			Assert.Equal(expected, array);
		}
	}
}
