using System;
namespace Sorting
{


	/// <summary>
	/// Insertion Sort is very basic
	/// No extra space needed
	/// Stable 
	/// Used for small collections and basic for TimSort and IntraSort (Hybrid)
	/// </summary>
	public static class InsertionSort
	{


		public static void Sort<T>(T[] array) where T : IComparable<T>
		{
			for (int i = 1; i < array.Length; i++)
			{
				T key = array[i];
				int j = i - 1; 
				while (j >= 0 && array[j].CompareTo(key) == 1)
				{
					array[j + 1] = array[j];
					j--;
				}
				array[j + 1] = key;  
			}
		}

	}
}

