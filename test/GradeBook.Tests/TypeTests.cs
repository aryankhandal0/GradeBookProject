using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += DiffDelegateMethod;
            var result = log("Hello!");
            Assert.Equal(count,2);
        }
        string ReturnMessage(string message)
        {
            count += 1; 
            return message;
        }
        string DiffDelegateMethod(string message)
        {
            count += 1; 
            return message.ToLower();
        }
        [Fact]
        public void StringBehaveAsValueTypes()
        {
            string name = "Aryan";
            string upper = MakeUpperCase(name);
            Assert.Equal("ARYAN", upper);
            Assert.Equal("Aryan",name);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void test1()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42,x);
            // SetInt(x);
            // Assert.Equal(3,x);
        }

        private void SetInt(ref int z)
        {
            z = 42;

        }

        private int GetInt()
        {
            return 3;

        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange Section
            var book1 = GetBook("Book 1");
            // Act Section
            GetBookSetName(book1, "New Book 1 Name");
            // Assert Section
            Assert.Equal("Book 1",book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        [Fact]
        public void CSharpCanPassByRef()
        {
            // Arrange Section
            var book1 = GetBook("Book 1");
            // Act Section
            GetBookSetName(ref book1, "New Book 1 Name");
            // Assert Section
            Assert.Equal("New Book 1 Name",book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange Section
            var book1 = GetBook("Book 1");
            // Act Section            
            SetName(book1, "New Book 1 Name");
            // Assert Section
            Assert.Equal("New Book 1 Name",book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnDiffObjects()
        {
            // Arrange Section
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            // Act Section
            

            // Assert Section
            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
        }
        [Fact]
        public void TwoVArReferenceSameObjects()
        {
            // Arrange Section
            var book1 = GetBook("Book 1");
            
            // Act Section
            var book2 = book1;

            // Assert Section
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
            

        }
        InMemoryBook GetBook(string name){
            return new InMemoryBook(name);
        }
    }
}
