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
    }
}

