using System;
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
	}
}

