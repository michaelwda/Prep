using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prep.Tests.number_of_islands
{
    [TestClass]
    public class NumberOfIslands
    {
        private readonly Solution _solution = new Solution();
        
        [TestMethod]
        public void Example1()
        {
            var result = _solution.NumIslands(new[]
            {
                new[] {'1','1','1','1','0'},
                new[] {'1','1','0','1','0'},
                new[] {'1','1','0','0','0'},
                new[] {'0','0','0','0','0'},
            });

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Example2()
        {
            var result = _solution.NumIslands(new[]
            {
                new[] {'1','1','0','0','0'},
                new[] {'1','1','0','0','0'},
                new[] {'0','0','1','0','0'},
                new[] {'0','0','0','1','1'},
            });

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NoIslands()
        {
            var result = _solution.NumIslands(new[]
            {
                new[] {'0','0','0','0','0'},
                new[] {'0','0','0','0','0'},
                new[] {'0','0','0','0','0'},
                new[] {'0','0','0','0','0'},
            });

            Assert.AreEqual(0, result);
        }

    }
}
