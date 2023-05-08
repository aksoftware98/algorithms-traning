using System;
namespace Sorting
{
	/// <summary>
	/// Bubble sort is based on the idea of swapping two items
	/// Then move to the second and thrid, thrid and fourth
	/// Keep repeating until the array is sorted
	/// It's O(n^2)
	/// </summary>
	public static class BubbleSort
	{

		/// <summary>
		/// Sort array using the Bubble sort algorithm
		/// O(n^2)
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		public static void BubbleSortArray<T>(T[] array) where T : IComparable<T>
		{
			bool isSorted = false;
			while (!isSorted)
			{
				isSorted = true; 
				for (int i = 0; i < array.Length - 1; i++)
				{
					if (array[i + 1].CompareTo(array[i]) != 1)
					{
						T temp = array[i + 1];
						array[i + 1] = array[i];
						array[i] = temp;
						isSorted = false; 
					}
				}

			}
		}

		public static void Sort<T>(T[] array) where T : IComparable<T>
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = 0; j < array.Length - i - 1; j++)
				{
					if (array[j].CompareTo(array[j + 1]) == 1)
					{
						var temp = array[j + 1];
						array[j + 1] = array[j];
						array[j] = temp;
					}
				}
			}
		}

		/// <summary>
		/// Effective Bubble Sort by checking for a swap to happen 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
        public static void BubbleSortEffective<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
				bool isSwapped = false; 
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) == 1)
                    {
                        var temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
						isSwapped = true; 
                    }
                }
				if (!isSwapped)
					break; 
            }
        }
    }
}

