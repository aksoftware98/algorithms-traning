using System;
namespace Sorting
{
	/// <summary>
	/// Unstable sorting Algorithm 
	/// QuickSort divide and conquer algorithm 
	/// O(n^2) worst case 
	/// It's in place
	/// cache friendly 
	/// Average case is N(log(N)
	/// Tail recursion 
	/// </summary>
	public static class QuickSort
	{

		public static void PartitionNaive<T>(T[] array, int low, int height) where T : IComparable<T>
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
		public static int LomutoPartion<T>(T[] array, int low, int high) where T : IComparable<T>
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

			return i; 
		}

        public static int HoarePartition<T>(T[] array, int low, int high) where T : IComparable<T>
        {
			int i = low - 1;
			int j = high + 1;
			T pivot = array[low];

			while (true)
			{
				do
				{
					i++; 
				} while (array[i].CompareTo(pivot) == -1);
				do
				{
					j--;
				} while (array[j].CompareTo(pivot) == 1);
				if (j <= i)
				{
					return j;
				}

				var temp = array[j];
				array[j] = array[i];
				array[i] = temp;
			}

        }


		public static void SortWithLomutoPartition<T>(T[] array, int low, int high) where T : IComparable<T> 
		{
			if (low < high)
			{
				int p = LomutoPartion(array, low, high);
				SortWithLomutoPartition(array, low, p - 1);
				SortWithLomutoPartition(array, p + 1, high);
			}
		}

		public static void SortWithHoarePartition<T>(T[] array, int low, int high) where T : IComparable<T>
		{
			if (low < high)
			{
				var p = HoarePartition(array, low, high);
				SortWithHoarePartition(array, low, p);
				SortWithHoarePartition(array, p + 1, high);
			}
		}


    }
}

