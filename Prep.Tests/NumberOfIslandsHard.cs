using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prep.Problems.Problems.number_of_islands_hard;

namespace Prep.Tests
{
    [TestClass]
    public class NumberOfIslandsHard
    {
        private readonly Solution _solution = new Solution();
        
        [TestMethod]
        public void Example1()
        {
            var result = _solution.NumIslands2(3,3, new[]
            {
                new[] {0,0}
            });

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0]);
        }
        [TestMethod]
        public void Example2()
        {
            var result = _solution.NumIslands2(3, 3, new[]
            {
                new[] {0,0},
                new[] {0,1},
            });

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result[1]);
        }

        [TestMethod]
        public void Example3()
        {
            var result = _solution.NumIslands2(3, 3, new[]
            {
                new[] {0,0},
                new[] {0,1},
                new[] {1,2},
                new[] {2,1},
            });

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result[1]);
            Assert.AreEqual(2, result[2]);
            Assert.AreEqual(3, result[3]);
        }

    }
}
