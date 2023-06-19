using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{

	/// <summary>
	/// Counting Sort is a non-comparison integer sorting algorithm. It sorts an array based on the keys that are small integers.
	/// It's stable 
	/// </summary>
	public class CountingSort
	{
		public static void NaiveSort(int[] array, int k)
		{
			int[] count = new int[k];

			for (int i = 0; i < k; i++)
				count[i] = 0;

			for (int i = 0; i < array.Length; i++)
			{
				count[array[i]]++;
			}

			int index = 0; 
			for (int i = 0; i < k; i++)
			{
				for(int j = 0; j < count[i]; j++)
				{
					array[index] = i;
					index++;
				}
			}
		}

		public static void Sort(int[] array, int k)
		{
			var count = new int[k];
			for (int i = 0; i < k; i++)
			{
				count[i] = 0; 
			}
			for (int i = 0; i < array.Length; i++)
			{
				count[array[i]]++;
			}

			// Get the count of the minimum numbers that are less than or equal to the current number
			for (int i = 1; i < k; i++)
			{
				count[i] = count[i - 1] + count[i];
			}

			var output = new int[array.Length];
			for (int i = array.Length - 1; i >= 0; i--)
			{
				output[count[array[i]] - 1] = array[i];
				count[array[i]]--; 
			}

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = output[i];
			}
		}
	}
}
