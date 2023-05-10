namespace Sorting.Tests
{
    public class QuickSortTests
    {
        [Theory]
        [InlineData(new[] { 3, 2, 1, 78, 9798, 97 }, 0, 5, new[] { 3, 2, 1, 78, 97, 9798})]
        public void NaviePartioningShoudWorkAsExpected(int[] array, int low, int high, int[] expected)
        {
            QuickSort.PartionNaive(array, low, high);

            Assert.True(array.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(new[] { 10, 80, 30, 90, 40, 50, 70 }, 0, 6, new[] { 10, 30, 40, 50, 70, 90, 80})]
        public void LomutoPartioningShoudWorkAsExpected(int[] array, int low, int high, int[] expected)
        {
            QuickSort.LomutoPartion(array, low, high);

            Assert.True(array.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(new[] { 5, 3, 8, 4, 2, 7, 1, 10 }, 0, 7, new[] { 1, 3, 2, 4, 8, 7, 5, 10 })]
        public void HoarePartioningShoudWorkAsExpected(int[] array, int low, int high, int[] expected)
        {
            QuickSort.HoarePartition(array, low, high);

            Assert.True(array.SequenceEqual(expected));
        }
    }
}

