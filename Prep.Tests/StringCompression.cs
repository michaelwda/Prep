using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prep.Problems.Problems.string_compression;

namespace Prep.Tests
{
    [TestClass]
    public class StringCompression
    {
        private readonly Solution _solution = new Solution();
        
        [TestMethod]
        public void Example1()
        {
            var result = _solution.Compress(new []{'a','a'});

            Assert.AreEqual(2, result);
        }
        


    }
}
