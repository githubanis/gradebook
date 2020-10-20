using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string LogMessage);
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
            
            var result = log("Hello");
            Assert.Equal(3, count);
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
         public void StringBehaveLikeValueType()
         {
             string name = "anis";
             string upper = MakeUpper(name);

             Assert.Equal("ANIS", upper);
             Assert.Equal("anis", name);
         }

        private string MakeUpper(string perameter)
        {
            return perameter.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(23, x);
        }

        private void SetInt(ref int z)
        {
            z = 23;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetbookSetName(out book1, "New Book");

            Assert.Equal("New Book", book1.Name);
            
        }

        private void GetbookSetName(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void TesPassByValue()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Book");

            Assert.Equal("New Book", book1.Name);
            
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}