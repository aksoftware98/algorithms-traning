using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
	/// <summary>
	/// HeapSort is a comparison-based sorting algorithm that works by dividing an array 
	/// into two regions: sorted and unsorted. The sorted region will start empty and will 
	/// grow one element at a time by removing the maximum element from the input array and 
	/// putting that in the sorted region.
	/// It has a time complexity of O(nlogn) in the average and worst cases.
	/// </summary>
	public static class HeapSort
	{

		public static void MaxHeabify<T>(T[] array, int n, int i) where T : IComparable<T>
		{
			int largest = i; 
			int left = 2 * i + 1;
			int right = 2 * i + 2;
			if (left < n && array[left].CompareTo(array[largest]) == 1)
				largest = left;
			if (right < n && array[right].CompareTo(array[largest]) == 1)
				largest = right; 
			if (largest != i)
			{
				var temp = array[i];
				array[i] = array[largest];
				array[largest] = temp;
				MaxHeabify(array, n, largest); 
			}
		}

		public static void BuildMaxHeap<T>(T[] array) where T : IComparable<T>
		{
			var n = array.Length; 
			for (int i = (n - 2) / 2; i >= 0; i--)
			{
				MaxHeabify(array, n, i);
			}
		}

		public static void Sort<T>(T[] array) where T : IComparable<T>
		{
			BuildMaxHeap(array);
			for (int i = array.Length - 1; i >= 0; i--)
			{
				var temp = array[0];
				array[0] = array[i];
				array[i] = temp;
				MaxHeabify(array, i, 0);
			}
		}



	}
}
