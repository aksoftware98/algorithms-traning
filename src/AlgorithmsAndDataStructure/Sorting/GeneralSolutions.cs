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

	}
}

