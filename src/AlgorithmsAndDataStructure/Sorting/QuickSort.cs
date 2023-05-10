using System;
namespace Sorting
{
	/// <summary>
	/// Unstable sorting Algorithm 
	/// </summary>
	public static class QuickSort
	{

		public static void PartionNaive<T>(T[] array, int low, int height) where T : IComparable<T>
		{
			var pivot = array[height];
			var tempArray = new T[array.Length];

			int firstIndex = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].CompareTo(pivot) == -1)
				{
					tempArray[firstIndex] = array[i];
					firstIndex++; 
				}
			}

			tempArray[firstIndex] = pivot;
			firstIndex++;
			for (int i = 0; i < array.Length; i++)
			{
                if (array[i].CompareTo(pivot) == 1)
                {
                    tempArray[firstIndex] = array[i];
                    firstIndex++;
                }
            }

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = tempArray[i];
			}
		}

		/// <summary>
		/// This method do only one travese on the array and doesn't require any extra space
		/// NOTE: This method always supposed that the pivot is the last element, if it's not we need to add an extra step to swap the traget pivot with the last element and continue normally
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		/// <param name="low"></param>
		/// <param name="high"></param>
		public static void LomutoPartion<T>(T[] array, int low, int high) where T : IComparable<T>
		{
			T pivot = array[high];
			int i = low;

			for (int j = low; j < high; j++)
			{
				if (array[j].CompareTo(pivot) == -1)
				{
					var temp = array[i];
					array[i] = array[j];
					array[j] = temp;
					i++; 
				}
			}

			var tempFinal = array[i];
			array[high] = tempFinal;
			array[i] = pivot;
		}

	}
}

