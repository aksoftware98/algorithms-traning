using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Sorting
{

	/// <summary>
	/// Optimal in term of memroy writing, it is the most efficient in terms of number of memory writes.
	/// It's not stable sorting algorithms
	/// Cycle sort is an in-place comparison sort. It resembles an optimized version of selection sort.
	/// Cycle sort works by detecting cycles in the corresponding list.In each cycle, the smallest value is placed at its correct position such that the smaller elements move to the beginning of the list.
	/// The algorithm divides the input list into cycles.It then finds the appropriate position of every element within the corresponding cycle that minimizes the memory writes.A memory write is the act of copying data from one location in memory to another one.
	/// Cycle sort can be considered efficient in terms of memory writes. It produces the fewest memroy writes for any given list of elements.It is not a stable sort, meaning that it does not necessarily preserve the original order of all elements with the same key values.
	/// Using the Cycle sort can be beneficial when sorting large arrays and only a few elements in the array are misplaced. By swapping values within a cycle, it can correct a lot of those misplaced values.Cycle sort's operation counts differ from other sorting algorithms, making it favorable in certain situations.
	/// Possible optimizations could include improving the memory usage. Another way to optimize the algorithm would be to avoid some unnecessary rewrites to memory by detecting and skipping over already sorted regions of the input list.
	/// </summary>
	public static class CycleSort
	{

		public static void Sort<T>(T[] array) where T : IComparable<T>
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				var item = array[i];
				var pos = i;
				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[j].CompareTo(item) < 0)
					{
						pos++;
					}
				}
				var temp = array[pos];
				array[pos] = item;
				item = temp;
				while (pos != i)
				{
					pos = i; 
					for (int j = i + 1; j < array.Length; j++)
					{
						if (array[j].CompareTo(item) < 0)
						{
							pos++;
						}
					}
					temp = array[pos];
					array[pos] = item;
					item = temp;
				}
			}
		}

	}
}
