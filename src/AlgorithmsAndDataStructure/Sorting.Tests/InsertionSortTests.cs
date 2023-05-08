using System;
namespace Sorting.Tests
{
	public class InsertionSortTests
	{
        [Fact]
        public void InsertionSortIsWorkingAsExpected()
        {
            var array = new[] { 2, 10, 8, 7 };

            InsertionSort.Sort(array);

            Assert.True(array.SequenceEqual(new[] { 2, 7, 8, 10 }));
        }
    }
}

