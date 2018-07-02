namespace ArrayExtension
{
    using System;

    /// <summary>
    /// The Integer Array Extention
    /// </summary>
    public static class ArrayExtension
    {

        ///<summary>
        /// Method to start merge sort with 3 argument
        /// </summary>      
        /// <param name="array">
        /// The array
        /// </param>
        /// <param name="low">
        /// Left border of array
        /// </param>
        /// <param name="high">
        /// Right border of array
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw when array is null
        /// </exception>
        public static void MergeSort(this int[] array, int low, int high)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0 || array.Length == 1)
            {
                return;
            }

            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(array, low, middle);
                MergeSort(array, middle + 1, high);
                Merge(array, low, middle, high);
            }
        }

        /// <summary>
        /// Method to start merge sort with one argument
        /// </summary>
        /// <param name="array">
        /// The array
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw when array is null
        /// </exception>
        public static void MergeSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0 || array.Length == 1)
            {
                return;
            }

            MergeSort(array, 0, array.Length - 1);
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
        /// Method which merged two part of array
        /// </summary>
        /// <param name="array">
        /// The array
        /// </param>
        /// <param name="low">
        /// Left border of array
        /// </param>
        /// <param name="middle">
        /// Middle position
        /// </param>
        /// <param name="high">
        /// Right border of array
        /// </param>
        private static void Merge(int[] array, int low, int middle, int high)
        {

            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (array[left] < array[right])
                {
                    tmp[tmpIndex] = array[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = array[right];
                    right = right + 1;
                }

                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = array[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = array[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                array[low + i] = tmp[i];
            }
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
                    Swap(ref array[i++], ref array[j--]);
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
        /// <param name="i">
        /// The first element which need swap
        /// </param>
        /// <param name="j">
        /// The second element which need return
        /// </param>
        private static void Swap(ref int i,ref int j)
        {
            int tmp = i;
            i = j;
            j = tmp;
        }
    }
}
