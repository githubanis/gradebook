using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    public delegate string WriteLogDelegate(string LogMessage);

    [TestClass]
    public class TypeTest
    {
        int count = 0;

        [TestMethod]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");
            Assert.AreEqual(3, count);
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

        [TestMethod]
        public void StringBehaveLikeValueType()
        {
            string name = "anis";
            string upper = MakeUpper(name);

            Assert.AreEqual("ANIS", upper);
            Assert.AreEqual("anis", name);
        }

        private string MakeUpper(string perameter)
        {
            return perameter.ToUpper();
        }

        [TestMethod]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.AreEqual(23, x);
        }

        private void SetInt(ref int z)
        {
            z = 23;
        }

        private int GetInt()
        {
            return 3;
        }

        [TestMethod]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetbookSetName(out book1, "New Book");

            Assert.AreEqual("New Book", book1.Name);

        }

        private void GetbookSetName(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [TestMethod]
        public void TesPassByValue()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Book");

            Assert.AreEqual("New Book", book1.Name);

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [TestMethod]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            Assert.AreEqual("Book 1", book1.Name);
            Assert.AreEqual("Book 2", book2.Name);
            //Assert.AreEqual(book1, book2);
        }

        [TestMethod]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.AreSame(book1, book2);
            Assert.IsTrue(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
