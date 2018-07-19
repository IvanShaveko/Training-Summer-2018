using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayExtencion
{
    /// <summary>
    /// Increasing sums
    /// </summary>
    public class IncreasingCondition: IComparer<int[]>
    { 
        /// <summary>
        /// Method which give us difference between sum
        /// </summary>
        /// <param name="lhs">
        /// The first array
        /// </param>
        /// <param name="rhs">
        /// The second array
        /// </param>
        /// <returns>
        /// Difference between sums
        /// </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs == null)
            {
                return 0;
            }

            if (lhs == null)
            {
                return 1;
            }

            if (rhs == null)
            {
                return -1;
            }

            return lhs.Sum() - rhs.Sum();
        }
    }

    /// <summary>
    /// Decreasing sums
    /// </summary>
    public class DecreasingCondition : IComparer<int[]>
    {
        /// <summary>
        /// Method which give us difference between sum
        /// </summary>
        /// <param name="lhs">
        /// The first array
        /// </param>
        /// <param name="rhs">
        /// The second array
        /// </param>
        /// <returns>
        /// Difference between sums
        /// </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs == null)
            {
                return 0;
            }

            if (lhs == null)
            {
                return -1;
            }

            if (rhs == null)
            {
                return 11;
            }

            return rhs.Sum() - lhs.Sum();
        }
    }

    /// <summary>
    /// Increasing max
    /// </summary>
    public class IncreasingMax : IComparer<int[]>
    {
        /// <summary>
        /// Method which give us difference between max elements
        /// </summary>
        /// <param name="lhs">
        /// The first array
        /// </param>
        /// <param name="rhs">
        /// The second array
        /// </param>
        /// <returns>
        /// Difference between max elements
        /// </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs == null)
            {
                return 0;
            }

            if (lhs == null)
            {
                return 1;
            }

            if (rhs == null)
            {
                return -1;
            }

            return lhs.Max() - rhs.Max();
        }
    }

    /// <summary>
    /// DecreasingMax
    /// </summary>
    public class DecreasingMax : IComparer<int[]>
    {
        /// <summary>
        /// Method which give us difference between max elements
        /// </summary>
        /// <param name="lhs">
        /// The first array
        /// </param>
        /// <param name="rhs">
        /// The second array
        /// </param>
        /// <returns>
        /// Difference between max elements
        /// </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs == null)
            {
                return 0;
            }

            if (lhs == null)
            {
                return -1;
            }

            if (rhs == null)
            {
                return 1;
            }

            return rhs.Max() - lhs.Max();
        }
    }

    /// <summary>
    /// Increasing min
    /// </summary>
    public class IncreasingMin : IComparer<int[]>
    {
        /// <summary>
        /// Method which give us difference between min elements
        /// </summary>
        /// <param name="lhs">
        /// The first array
        /// </param>
        /// <param name="rhs">
        /// The second array
        /// </param>
        /// <returns>
        /// Difference between min elements
        /// </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs == null)
            {
                return 0;
            }

            if (lhs == null)
            {
                return 1;
            }

            if (rhs == null)
            {
                return -1;
            }

            return lhs.Min() - rhs.Min();
        }
    }

    /// <summary>
    /// Decreasing min
    /// </summary>
    public class DecreasingMin : IComparer<int[]>
    {
        /// <summary>
        /// Method which give us difference between min elements
        /// </summary>
        /// <param name="lhs">
        /// The first array
        /// </param>
        /// <param name="rhs">
        /// The second array
        /// </param>
        /// <returns>
        /// Difference between min elements
        /// </returns>
        public int Compare(int[] lhs, int[] rhs)
        {
            if (lhs == null && rhs == null)
            {
                return 0;
            }

            if (lhs == null)
            {
                return -1;
            }

            if (rhs == null)
            {
                return 1;
            }

            return rhs.Min() - lhs.Min();
        }
    }
}
