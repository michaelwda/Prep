using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prep.Tests.MergeIntervals
{
    [TestClass]
    public class MergeIntervals
    {
        private readonly Solution _solution = new Solution();
        
        [TestMethod]
        public void Example1()
        {
            var result = _solution.Merge(
                new []
                {
                    new []{1,3}, 
                    new []{2,6},
                    new []{8,10},
                    new []{15,18},
                });

            Assert.AreEqual(2, result);
        }
 
    }

    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, Comparison);
            var merged = new LinkedList<int[]>();

            foreach (var interval in intervals)
            {
                if (!merged.Any() || merged.Last.Value[1] < interval[0])
                {
                    merged.AddLast(interval);
                }
                else
                {
                    merged.Last.Value[1] = Math.Max(merged.Last.Value[1], interval[1]);
                }
            }

            return merged.ToArray();
        }

        private int Comparison(int[] x, int[] y)
        {
            return x[0].CompareTo(x[1]);
        }
    }

}
