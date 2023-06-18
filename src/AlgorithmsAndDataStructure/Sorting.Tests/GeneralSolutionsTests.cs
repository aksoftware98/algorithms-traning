using static Sorting.GeneralSolutions;

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

		[Theory]
		[InlineData(new[] { 10, 4, 5, 8, 11, 6, 26 }, 5, 10)]
		public void KthSmallestElementShouldWorkAsExpected(int[] array, int k, int expected)
		{
			var result = GeneralSolutions.KthSmallestElement(array, k);

			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(new[] { 10, 3, 20, 12 }, 2)]
		public void FindMinimumDifferenceInArrayShouldWorkAsExpected(int[] array, int expected)
		{
			var result = GeneralSolutions.FindMinimumDifferenceInArray(array);

			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(new[] { 7, 3, 1, 8, 9 , 12, 56 }, 3, 2)]
		public void ChocolateDistributionProblemShouldWorkAsExpected(int[] array, int m,int expected)
		{
			var result = GeneralSolutions.ChocolateDistributionProblem(array, m);

			Assert.Equal(expected, result);
		}


		[Fact]
		public void MergeOverlappingIntervalsShouldWorkAsExpected()
		{
			var intervals = new[]
			{
				new Interval(7, 9),
				new Interval(6, 10),
				new Interval(4, 5),
				new Interval(1, 3),
				new Interval(2, 4),
			};

			var result = GeneralSolutions.MergeOverlappingIntervals(intervals);

		}

		[Fact]
		public void MergeOverlappingIntervalsShouldWorkAsExpected2()
		{
			var intervals = new[]
			{
				new Interval(1, 3),
				new Interval(2, 4),
				new Interval(5, 7),
				new Interval(6, 8),
			};

			var result = GeneralSolutions.MergeOverlapIntervalsEfficient(intervals);

		}
	}
}

