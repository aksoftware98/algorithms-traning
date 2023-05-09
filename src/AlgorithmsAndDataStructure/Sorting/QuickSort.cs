using System;
namespace Sorting
{
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

	}
}

