using System;
namespace Sorting
{
	/// <summary>
	/// Selection sort is based on finding the minimum and put it first
	/// Finding the secnod minium and put it second and so on
	/// It's not stable
	/// Minimum wrirting
	/// O(n^2)
	/// Basic of the Heap Sort for later
	/// </summary>
	public static class SelectionSort
	{

		public static void Sort<T>(T[] array) where T : IComparable<T>
		{
			for (int i = 0; i < array.Length; i++)
			{
				var minumumIndex = i;
				for (int j = i; j < array.Length; j++)
				{
					if (array[minumumIndex].CompareTo(array[j]) == -1)
					{
						minumumIndex = j;
					}
				}
				if (minumumIndex != i)
				{
                    var temp = array[i];
                    array[i] = array[minumumIndex];
					array[minumumIndex] = temp; 
                }
			}
		}

	}
}

