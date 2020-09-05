using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prep.Tests.gcd_of_string
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
