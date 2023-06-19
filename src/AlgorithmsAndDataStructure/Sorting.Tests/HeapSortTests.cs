using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Tests
{
	public class HeapSortTests
	{

		[Theory]
		[InlineData(new[] { 10, 15, 50, 4, 20 }, new[] { 50, 20, 10, 4, 15 })]
		public static void BuildMaxHeap_ShouldBuild_Correctly(int[] array, int[] expected)
		{
			HeapSort.BuildMaxHeap(array);

			Assert.True(array.SequenceEqual(expected));
		}

		[Theory]
		[InlineData(new[] { 10, 15, 50, 4, 20 }, new[] { 4, 10, 15, 20, 50 })]
		public static void HeabSort_ShouldSort_Correctly(int[] array, int[] expected)
		{
			HeapSort.Sort(array);

			Assert.True(array.SequenceEqual(expected));
		}

	}
}
