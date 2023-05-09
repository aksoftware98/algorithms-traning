namespace Sorting.Tests
{
    public class GeneralSolutionsTests
    {
        [Theory]
        [InlineData(new[] { 3, 6, 5, 12, 16, 9}, 3)]
        public void InversionCountsInArrayShouldWorkAsExpected(int[] array, int expected)
        {
            var result = GeneralSolutions.CountInversionsInArray(array);

            Assert.Equal(expected, result);
        }
    }
}

