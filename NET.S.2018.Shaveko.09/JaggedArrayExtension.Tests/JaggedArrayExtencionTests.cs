using System;
using JaggedArrayExtencion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace JaggedArrayExtension.Tests
{
    [TestFixture]
    public class JaggedArrayExtencionTests
    {
        [Test]
        public void JaggedArrayExtencion_Sort_IncreasingSum()
        {
            int[][] sourceInts =
            {
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4},
                new[] {33, 18, 44, 15},
                new[] {15, 23, 61}
            };

            int[][] execute =
            {
                new[] {1, 2, 3, 4},
                new[] {6, 2, 3, 6, 7, 15},
                new[] {15, 23, 61},
                new[] {33, 18, 44, 15}
            };

            sourceInts.Sort(new IncreasingCondition());

            for (int i = 0; i < sourceInts.Length; i++)
            {
                CollectionAssert.AreEqual(sourceInts[i], execute[i]);
            }
        }

        [Test]
        public void JaggedArrayExtencion_Sort_DecreasingSum()
        {
            int[][] sourceInts =
            {
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4},
                new[] {33, 18, 44, 15},
                new[] {15, 23, 61}
            };

            int[][] execute =
            {
                new[] {33, 18, 44, 15},
                new[] {15, 23, 61},
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4}
            };

            sourceInts.Sort(new DecreasingCondition());

            for (int i = 0; i < sourceInts.Length; i++)
            {
                CollectionAssert.AreEqual(sourceInts[i], execute[i]);
            }
        }

        [Test]
        public void JaggedArrayExtencion_Sort_IncreasingMax()
        {
            int[][] sourceInts =
            {
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4},
                new[] {33, 18, 44, 15},
                new[] {15, 23, 61}
            };

            int[][] execute =
            {
                new[] {1, 2, 3, 4},
                new[] {6, 2, 3, 6, 7, 15},
                new[] {33, 18, 44, 15},
                new[] {15, 23, 61}
            };

            sourceInts.Sort(new IncreasingMax());

            for (int i = 0; i < sourceInts.Length; i++)
            {
                CollectionAssert.AreEqual(sourceInts[i], execute[i]);
            }
        }

        [Test]
        public void JaggedArrayExtencion_Sort_DecreasingMax()
        {
            int[][] sourceInts =
            {
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4},
                new[] {33, 18, 44, 15},
                new[] {15, 23, 61}
            };

            int[][] execute =
            {
                new[] {15, 23, 61},
                new[] {33, 18, 44, 15},
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4}
            };

            sourceInts.Sort(new DecreasingMax());

            for (int i = 0; i < sourceInts.Length; i++)
            {
                CollectionAssert.AreEqual(sourceInts[i], execute[i]);
            }
        }

        [Test]
        public void JaggedArrayExtencion_Sort_IncreasingMin()
        {
            int[][] sourceInts =
            {
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4},
                new[] {33, 18, 44, 15},
                new[] {13, 23, 61}
            };

            int[][] execute =
            {
                new[] {1, 2, 3, 4},
                new[] {6, 2, 3, 6, 7, 15},
                new[] {13, 23, 61},
                new[] {33, 18, 44, 15}
            };

            sourceInts.Sort(new IncreasingMin());

            for (int i = 0; i < sourceInts.Length; i++)
            {
                CollectionAssert.AreEqual(sourceInts[i], execute[i]);
            }
        }

        [Test]
        public void JaggedArrayExtencion_Sort_DecreasingMin()
        {
            int[][] sourceInts =
            {
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4},
                new[] {33, 18, 44, 15},
                new[] {13, 23, 61}
            };

            int[][] execute =
            {
                new[] {33, 18, 44, 15},
                new[] {13, 23, 61},
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4}
            };

            sourceInts.Sort(new DecreasingMin());

            for (int i = 0; i < sourceInts.Length; i++)
            {
                CollectionAssert.AreEqual(sourceInts[i], execute[i]);
            }
        }

        [Test]
        public void JaggedArrayExtencion_SortByDelegate_IncreasingSum()
        {
            int[][] sourceInts =
            {
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4},
                new[] {33, 18, 44, 15},
                new[] {15, 23, 61}
            };

            int[][] execute =
            {
                new[] {1, 2, 3, 4},
                new[] {6, 2, 3, 6, 7, 15},
                new[] {15, 23, 61},
                new[] {33, 18, 44, 15}
            };
        
            sourceInts.DelegateSort(new IncreasingCondition().Compare);

            for (int i = 0; i < sourceInts.Length; i++)
            {
                CollectionAssert.AreEqual(sourceInts[i], execute[i]);
            }
        }

        [Test]
        public void JaggedArrayExtencion_SortByInterface_IncreasingSum()
        {
            int[][] sourceInts =
            {
                new[] {6, 2, 3, 6, 7, 15},
                new[] {1, 2, 3, 4},
                new[] {33, 18, 44, 15},
                new[] {15, 23, 61}
            };

            int[][] execute =
            {
                new[] {1, 2, 3, 4},
                new[] {6, 2, 3, 6, 7, 15},
                new[] {15, 23, 61},
                new[] {33, 18, 44, 15}
            };

            sourceInts.SortByInterface(new IncreasingCondition());

            for (int i = 0; i < sourceInts.Length; i++)
            {
                CollectionAssert.AreEqual(sourceInts[i], execute[i]);
            }
        }
    }
}
