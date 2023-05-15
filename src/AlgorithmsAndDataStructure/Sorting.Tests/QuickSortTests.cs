namespace Sorting.Tests
{
    public class QuickSortTests
    {
        [Theory]
        [InlineData(new[] { 3, 2, 1, 78, 9798, 97 }, 0, 5, new[] { 3, 2, 1, 78, 97, 9798})]
        public void NaviePartioningShoudWorkAsExpected(int[] array, int low, int high, int[] expected)
        {
            QuickSort.PartitionNaive(array, low, high);

            Assert.True(array.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(new[] { 10, 80, 30, 90, 40, 50, 70 }, 0, 6, new[] { 10, 30, 40, 50, 70, 90, 80}, 4)]
        public void LomutoPartioningShoudWorkAsExpected(int[] array, int low, int high, int[] expectedArray, int expectedIndex)
        {
            var result = QuickSort.LomutoPartion(array, low, high);

            Assert.True(array.SequenceEqual(expectedArray));
            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData(new[] { 10, 7, 8, 9, 1, 5 }, 0, 5, new[] { 5, 7, 8, 9, 1, 10 }, 4)]
        public void HoarePartioningShoudWorkAsExpected(int[] array, int low, int high, int[] expectedArray, int expectedIndex)
        {
            var result = QuickSort.HoarePartition(array, low, high);

            Assert.True(array.SequenceEqual(expectedArray));
            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData(new[] { 8, 4, 7, 9, 3, 10, 5 }, 0, 6, new[] { 3, 4, 5, 7, 8, 9, 10 })]
        public void QuickSortWithLomutoPartitionShouldWorkAsExpected(int[] array, int low, int high, int[] expected)
        {
            QuickSort.SortWithLomutoPartition(array, low, high);

            Assert.True(array.SequenceEqual(expected)); 
        }

        [Theory]
        [InlineData(new[] { 8, 4, 7, 9, 3, 10, 5 }, 0, 6, new[] { 3, 4, 5, 7, 8, 9, 10 })]
        public void QuickSortWithHoarePartitionShouldWorkAsExpected(int[] array, int low, int high, int[] expected)
        {
            QuickSort.SortWithHoarePartition(array, low, high);

            Assert.True(array.SequenceEqual(expected));
        }
    }
}

