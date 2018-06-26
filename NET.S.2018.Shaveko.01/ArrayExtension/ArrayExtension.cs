namespace ArrayExtension
{
    using System;

    /// <summary>
    /// The Integer Array Extention
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Extention method to start merge sort
        /// </summary>
        /// <param name="array">
        /// The array
        /// </param>
        /// <returns>
        /// Return sorted array
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throw when array is null or empty
        /// </exception>
        public static int[] MergeSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 1)
            {
                return array;
            }

            return DoMergeSort(array);
        }

        /// <summary>
        /// Method of merge sort
        /// </summary>
        /// <param name="array">
        /// The array
        /// </param>
        /// <returns>
        /// The full merged array
        /// </returns>
        private static int[] DoMergeSort(int[] array)
        {
            int[] left = new int[array.Length / 2];
            int[] right = new int[array.Length - left.Length];

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = array[i];
            }

            for (int i = 0; i < right.Length; i++)
            {
                right[i] = array[left.Length + i];
            }

            if (left.Length > 1)
            {
                left = DoMergeSort(left);
            }

            if (right.Length > 1)
            {
                right = DoMergeSort(right);
            }

            return Merge(left, right);
        }

        /// <summary>
        /// Method which merges two part of array
        /// </summary>
        /// <param name="left">
        /// The left part of array
        /// </param>
        /// <param name="right">
        /// The right part of array
        /// </param>
        /// <returns>
        /// Return merged two parts of array
        /// </returns>
        private static int[] Merge(int[] left, int[] right)
        {
            int[] array = new int[left.Length + right.Length];
            int l = 0;
            int r = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (l < left.Length && r < right.Length)
                {
                    if (left[l] > right[r])
                    {
                        array[i] = right[r++];
                    }
                    else
                    {
                        array[i] = left[l++];
                    }
                }
                else if (l < left.Length)
                {
                    array[i] = left[l++];
                }
                else
                {
                    array[i] = right[r++];
                }
            }

            return array;
        }

        /// <summary>
        /// Extention method to start quick sort
        /// </summary>
        /// <param name="array">
        /// The array
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw when array is null or empty
        /// </exception>
        public static void QuickSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 1)
            {
                return;
            }

            DoQuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Method of quick sort
        /// </summary>
        /// <param name="array">
        /// The array
        /// </param>
        /// <param name="first">
        /// The first element of array
        /// </param>
        /// <param name="last">
        /// The last element of array
        /// </param>
        private static void DoQuickSort(int[] array, int first, int last)
        {
            int point = ((last - first) / 2) + first;
            int p = array[point];
            int i = first, j = last;
            while (i <= j)
            {
                while (array[i] < p && i <= last)
                {
                    i++;
                }

                while (array[j] > p && j >= first)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(array, i++, j--);
                }
            }

            if (j > first)
            {
                DoQuickSort(array, first, j);
            }

            if (i < last)
            {
                DoQuickSort(array, i, last);
            }
        }

        /// <summary>
        /// Method which swaps two elements of array 
        /// </summary>
        /// <param name="array">
        /// The array 
        /// </param>
        /// <param name="i">
        /// The first element which need swap
        /// </param>
        /// <param name="j">
        /// The second element which need return
        /// </param>
        private static void Swap(int[] array, int i, int j)
        {
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
