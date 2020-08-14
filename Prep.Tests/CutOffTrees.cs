using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prep.Problems.Problems.cut_off_trees_for_golf_event;

namespace Prep.Tests
{
    [TestClass]
    public class CutOffTrees
    {
        private readonly Solution _solution = new Solution();
        
        [TestMethod]
        public void Example1()
        {
            var result = _solution.CutOffTree(
                new List<IList<int>>()
                {
                    new List<int>(){1,2,3},
                    new List<int>(){0,0,4},
                    new List<int>(){7,6,5},
                }
                );

            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void Example2()
        {
            var result = _solution.CutOffTree(
                new List<IList<int>>()
                {
                    new List<int>(){1,2,3},
                    new List<int>(){0,0,0},
                    new List<int>(){7,6,5},
                }
            );

            Assert.AreEqual(-1, result);
        }


    }
}
