namespace Sorting
{
    /// <summary>
    /// Merge Sort is advanced divide and conquer 
    /// Stable algorithm
    /// Best for Linked Lists
    /// </summary>
    public static class MergeSort
    {

        /// <summary>
        /// This method just merges an array that's divided already to a two sorted array 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="medium"></param>
        /// <param name="high"></param>
        public static void MergeTwoSortedArrays<T>(T[] array, int low, int medium, int high) where T : IComparable<T>
        {
            // Copy the content of the array into two arrays
            var firstArray = new T[medium - low + 1];
            var secondArray = new T[high - medium];
            for (int i = 0; i < firstArray.Length; i++)
            {
                firstArray[i] = array[low + i];
            }
            for (int i = 0; i < secondArray.Length; i++)
            {
                secondArray[i] = array[low + firstArray.Length + i];
            }
            int a = 0;
            int j = 0;
            int k = low; 
            while (a < firstArray.Length && j < secondArray.Length)
            {
                if (firstArray[a].CompareTo(secondArray[j]) != 1)
                {
                    array[k] = firstArray[a];
                    a++;
                    k++; 
                }
                else
                {
                    array[k] = secondArray[j];
                    k++;
                    j++; 
                }
            }

            while (a < firstArray.Length)
            {
                array[k] = firstArray[a];
                k++;
                a++;
            }

            while (j < secondArray.Length)
            {
                array[k] = secondArray[j];
                j++;
                k++;
            }
             
        }

        /// <summary>
        /// Merge a full array using the merge sort algorithm 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="low"></param>
        /// <param name="max"></param>
        public static void Sort<T>(T[] array, int low, int max) where T : IComparable<T>
        {
            // Check if at least 1 element
           if (max > low)
            {
                var median = low + (max - low) / 2;
                Sort(array, low, median);
                Sort(array, median + 1, max);
                MergeTwoSortedArrays(array, low, median, max);
            }
        }

    }
}

