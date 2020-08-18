using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prep.Problems.Problems.AWS;


namespace Prep.Tests
{
    [TestClass]
    public class ShoppingCartFSMTests
    {
        private readonly ShoppingCartFSM _solution = new ShoppingCartFSM();
        
        [TestMethod]
        public void Example1()
        {

            var result = _solution.Solve(
                    new List<List<string>>() {
                        new List<string>(){ "apple", "apple" },
                        new List<string>(){ "banana", "anything", "banana" }
                    },
                    new List<string>() { "orange", "apple", "apple", "banana", "orange", "banana" }
                );

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Example2()
        {

            var result = _solution.Solve(
                new List<List<string>>() {
                    new List<string>(){ "apple", "apple" },
                    new List<string>(){ "banana", "anything", "banana" }
                },
                new List<string>() { "banana", "orange", "banana", "apple", "apple" }
            );

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Example3()
        {

            var result = _solution.Solve(
                new List<List<string>>() {
                    new List<string>(){ "apple", "apple" },
                    new List<string>(){ "banana", "anything", "banana" }
                },
                new List<string>() { "apple", "banana", "apple", "banana", "orange", "banana" }
            );

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Example4()
        {

            var result = _solution.Solve(
                new List<List<string>>() {
                    new List<string>(){ "apple", "apple" },
                    new List<string>(){ "apple", "apple", "banana" }
                },
                new List<string>() { "apple", "apple", "apple", "banana" }
            );

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Example5()
        {

            var result = _solution.Solve(
                new List<List<string>>() {
                    new List<string>(){ "apple", "apple" },
                    new List<string>(){ "banana", "anything", "banana" }
                },
                new List<string>() { "orange", "apple", "apple", "banana", "orange", "banana" }
            );

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Example6()
        {

            var result = _solution.Solve(
                new List<List<string>>() {
                    new List<string>(){ "apple", "apple" },
                    new List<string>(){ "banana", "anything", "banana" }
                },
                new List<string>() { "apple", "apple", "orange", "orange", "banana", "apple", "banana", "banana" }
            );

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Example7()
        {

            var result = _solution.Solve(
                new List<List<string>>() {
                    new List<string>(){ "anything", "apple" },
                    new List<string>(){ "banana", "anything", "banana" }
                },
                new List<string>() { "orange", "grapes", "apple", "orange", "orange", "banana", "apple", "banana", "banana" }
            );

            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void Example8()
        {

            var result = _solution.Solve(
                new List<List<string>>() {
                    new List<string>(){ "anything", "anything", "anything"},
                    new List<string>(){ "anything", "anything", "banana" , "anything" }
                },
                new List<string>() { "orange", "grapes", "apple", "orange", "orange", "banana", "apple", "banana", "banana" }
            );

            Assert.AreEqual(1, result);
        }

    }
}
