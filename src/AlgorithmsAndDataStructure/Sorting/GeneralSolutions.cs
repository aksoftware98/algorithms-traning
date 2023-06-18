using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Sorting
{
	/// <summary>
	/// Set of problems and their solutions that are realted to sorting
	/// </summary>
	public static class GeneralSolutions
	{

		/// <summary>
		/// The other solution is to use merge sorting and count everytime we swap to elements
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public static int CountInversionsInArray(int[] array)
		{
			int inversionCount = 0;
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (array[i] == array[j])
						continue;
					if (array[i] < array[j])
						inversionCount++;
				}
			}

			return inversionCount;
		}

		public static int KthSmallestElement(int[] array, int k)
		{
			int result = -1;
			int low = 0;
			int high = array.Length - 1;
			while (low <= high)
			{
				var p = QuickSort.LomutoPartion(array, low, high);
				if (p == k - 1)
					return array[p];

				if (p > k - 1)
					high = p - 1;

				if (p < k - 1)
					low = p + 1; 
			}

			return result;
		}

		public static int FindMinimumDifferenceInArray(int[] array)
		{
			int result = -1;
			MergeSort.Sort(array, 0, array.Length - 1);

			if (array.Length <= 1)
				return result;

			for (int i = 1; i < array.Length; i++)
			{
				var diff = array[i] - array[i - 1];
				if (i == 1)
				{
					result = diff;
					continue; 
				}

				if (diff < result)
					result = diff;

			}

			return result; 
		}

		public static int ChocolateDistributionProblem(int[] array, int m)
		{
			int result = -1;
			int n = array.Length;
			if (m > n)
				return result;

			QuickSort.SortWithLomutoPartition(array, 0, n - 1);

			result = array[m - 1] - array[0];
			for (int i = 1; (i + m - 1) < n; i++)
			{
				var value = (array[i + m - 1] - array[i]);
                if (value < result)
                {
					result = value; 
                }
            }
			return result; 
		}

		public static Interval[] MergeOverlappingIntervals(Interval[] intervals)
		{
			var result = new List<Interval>();

			QuickSort.SortWithLomutoPartition(intervals, 0, intervals.Length - 1);

			int currentMinimum = intervals[0].StartValue; 
			int currentMaximum = intervals[0].EndValue;
			int overlapsCount = 0; 
			for (int i = 0; i < intervals.Length - 1; i++)
			{
				var currentStartValue = intervals[i].StartValue;
				var currentEndValue = intervals[i].EndValue;
				var nextStartValue = intervals[i + 1].StartValue;
				var nextEndValue = intervals[i + 1].EndValue;

                if (currentStartValue.CompareTo(currentMinimum) == -1)
					currentMinimum = currentStartValue; 
				if (currentEndValue.CompareTo(currentMaximum) == 1)
					currentMaximum = currentEndValue;

                if (intervals[i].EndValue.CompareTo(intervals[i + 1].StartValue) == -1)
				{
					overlapsCount++;
					result.Add(new Interval(currentMinimum, currentMaximum));
					currentMinimum = intervals[i + 1].StartValue;
					currentMaximum = intervals[i + 1].EndValue;
				}

				if (i == intervals.Length - 2)
				{
					if (nextStartValue.CompareTo(currentMinimum) == -1)
						currentMinimum = nextStartValue;
					if (nextEndValue.CompareTo(currentMaximum) == 1)
						currentMaximum = nextEndValue;
					overlapsCount++;
					result.Add(new Interval(currentMinimum, currentMaximum));
				}
			}

			return result.ToArray(); 
		}

		public static Interval[] MergeOverlapIntervalsEfficient(Interval[] intervals)
		{
			QuickSort.SortWithLomutoPartition(intervals, 0, intervals.Length - 1);
			var results = new List<Interval>();
			int index = 0;
			
			for (int i = 1; i < intervals.Length; i++)
			{
				if (intervals[index].EndValue.CompareTo(intervals[i].StartValue) == 1)
				{
					intervals[index].EndValue = Math.Max(intervals[index].EndValue, intervals[i].EndValue);
					intervals[index].StartValue = Math.Min(intervals[i].StartValue, intervals[index].StartValue);
				}
				else
				{
					index++;
					intervals[index] = intervals[i]; 
				}
			}

			for (int i = 0; i <= index; i++)
			{
				results.Add(intervals[i]);
			}

			return results.ToArray();

		}

		public class Interval : IComparable<Interval>
		{
			public Interval(int startValue, int endValue)
			{
				StartValue = startValue;
				EndValue = endValue;
			}

			public int StartValue { get; set; }

			public int EndValue { get; set; }

			public int CompareTo(Interval? other)
			{
				if (other == null)
					return 1;
				
				return StartValue.CompareTo(other.StartValue);
			}
		}
	}
}

