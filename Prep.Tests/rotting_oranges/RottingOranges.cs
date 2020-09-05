using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prep.Tests.rotting_oranges
{
    [TestClass]
    public class RottingOranges
    {
        private readonly Solution _solution = new Solution();
        
        [TestMethod]
        public void Example1()
        {
            var result = _solution.OrangesRotting(new[]
            {
                new[] {2, 1, 1},
                new[] {1, 1, 0},
                new[] {0, 1, 1},
            });

            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void Example2()
        {
            var result = _solution.OrangesRotting(new[]
            {
                new[] {2, 1, 1},
                new[] {0, 1, 1},
                new[] {1, 0, 1},
            });
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void Example3()
        {
            var result = _solution.OrangesRotting(new[]
            {
                new[] {0,2},
            });
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void ImpossibleArrangement()
        {
            var result = _solution.OrangesRotting(new[]
                {
                new[] {2,0,0},
                new[] {0,0,0},
                new[] {0,0,1},
            });
            Assert.AreEqual(-1, result);
        }
    }
}
