using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
	/// <summary>
	/// 
	/// Radix sort is a non-comparative integer sorting algorithm that sorts data with integer keys by 
	/// grouping the keys by individual digits that share the same significant position and combining the groups. 
	/// This method avoids generating explicit key comparisons, 
	/// which contributes to radix sort's efficiency. 
	/// The time complexity depends on the length of the keys to be sorted. 
	/// Typically, the time complexity of radix sort is O(nk), 
	/// where n is the number of keys to sort, and k is the number of digits in the longest key.
	/// ExtraSpace O(n + k)
	/// 
	/// </summary>
	public class RadixSort
	{

		public static void Sort(int[] array)
		{
			int mx = array[0];
			// Find the maximum number
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i] > mx)
				{
					mx = array[i];
				}
			}

			// Do counting sort for every digit. Note that instead
			// of passing digit number, exp is passed. exp is 10^i
			// where i is current digit number
			for (int exp = 1; mx / exp > 0; exp *= 10)
			{
				CountingSort(array, exp);
			}
		}

		public static void CountingSort(int[] array, int exb)
		{
			var count = new int[10];
			var output = new int[array.Length];

			for (int i = 0; i < 10; i++)
			{
				count[i] = 0;
			}

			for(int i = 0; i < array.Length; i++)
			{
				count[(array[i] / exb) % 10]++;
			}

			for (int i = 1; i < 10; i++)
			{
				count[i] += count[i - 1];
			}

			for (int i = array.Length - 1; i >= 0; i--)
			{
				output[count[(array[i] / exb) % 10] - 1] = array[i];
				count[(array[i] / exb) % 10]--;
			}

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = output[i];
			}
		}

	}
}
