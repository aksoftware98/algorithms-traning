namespace Sorting.Tests
{
    public class MergeSortTests
    {
        [Theory]
        [InlineData(new[] { 10, 15, 20, 11, 30 }, 0, 2, 4, new[] { 10, 11, 15, 20, 30 })]
        [InlineData(new[] { 10, 20, 40, 20, 30 }, 0, 2, 4, new[] { 10, 20, 20, 30, 40 })]
        public void MergeFunctionShouldMergeTwoSortedArraysAsExptected(int[] array, int low, int medium, int high, int[] expected)
        {
            MergeSort.MergeTwoSortedArrays(array, low, medium, high);

            Assert.True(array.SequenceEqual(expected));
        }


        [Theory]
        [InlineData(new[] { 10, 5, 30, 15, 7 }, 0, 4, new[] { 5, 7, 10, 15, 30 })]
        public void MergeSortShouldWorkAsExptected(int[] array, int low, int high, int[] expected)
        {
            MergeSort.Sort(array, low, high);

            Assert.True(array.SequenceEqual(expected));
        }
    }
}

