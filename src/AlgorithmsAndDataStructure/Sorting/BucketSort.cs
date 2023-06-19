using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
	/// <summary>
	/// Uniform distribution
	/// Linear time 
	/// </summary>
	public class BucketSort
	{

		public static void Sort(int[] array, int k)
		{
			int n = array.Length;
			int max = array[0];
			int min = array[0]; 
			for (int i = 0; i < n; i++)
			{
				if (array[i] > max)
					max = array[i];
				if (array[i] < min)
					min = array[i];
			}

			List<List<int>> buckets = new(); 
			for (int i = 0; i < k; i++)
			{
				buckets.Add(new());
			}

			for (int i = 0; i < n; i++)
			{
				var bucket = k * array[i] / max;
				if (bucket == k)
					bucket--;
				buckets[bucket].Add(array[i]);
			}

			for (int i = 0; i < k; i++)
			{
				buckets[i] = buckets[i].Order().ToList(); 
			}

			int index = 0;
			for (int i = 0; i < k; i++)
			{
				for (int j = 0; j < buckets[i].Count; j++)
				{
					array[index] = buckets[i][j];
					index++; 
				}
			}

			
		}


	}
}
