using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(87.1);
            book.AddGrade(90.6);
            book.AddGrade(76.8);
            
            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(84.8, result.Average, 1);
            Assert.Equal(90.6, result.High, 1);
            Assert.Equal(76.8, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
