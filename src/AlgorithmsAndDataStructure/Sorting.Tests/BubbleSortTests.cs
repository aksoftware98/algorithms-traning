﻿namespace Sorting.Tests;

public class BubbleSortTests
{
    [Fact]
    public void BubbleSortAlgorithmsIsWorkingAsExpected()
    {
        var array = new[] { 2, 10, 8, 7 };

        BubbleSort.Sort(array);

        Assert.True(array.SequenceEqual(new[] { 2, 7, 8 , 10}));
    }
}
