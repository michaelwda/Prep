using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prep.Problems.Problems.gcd_of_string;

namespace Prep.Tests
{
    [TestClass]
    public class GcdOfString
    {
        private readonly Solution _solution = new Solution();
        
        [TestMethod]
        public void Example1()
        {
            var result = _solution.GcdOfStrings("ABABAB", "ABAB");

            Assert.AreEqual("AB", result);
        }
        

    }
}
