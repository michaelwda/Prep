using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prep.Tests.string_compression
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
