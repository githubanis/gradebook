using System;
using GradeBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(90.0);
            book.AddGrade(80.0);
            book.AddGrade(40.0);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.AreEqual(70.0, result.Average);
            Assert.AreEqual(90.0, result.High);
            Assert.AreEqual(40.0, result.Low);
            Assert.AreEqual('C', result.Letter);
        }
    }
}
