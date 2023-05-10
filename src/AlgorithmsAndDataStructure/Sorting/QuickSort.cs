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

		public static void LomutoPartion<T>(T[] array, int low, int high) where T : IComparable<T>
		{
			T pivot = array[high];
			int index = 0;
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

