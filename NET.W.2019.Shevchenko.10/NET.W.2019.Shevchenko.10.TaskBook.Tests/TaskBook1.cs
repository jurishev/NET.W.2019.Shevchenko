using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W2019.Shevchenko10.TaskBook.Tests
{
    [TestClass]
    public class TaskBook1
    {
        private Book book = new Book("0553803719")
        {
            Author = "Isaac Asimov",
            Title = "Foundation",
            Publisher = "Bantam",
            Year = 2004,
            PageCount = 244,
            Price = 3.75M,
        };

        [TestMethod]
        public void TaskBook_ViewMode_Plain()
        {
            string expected = "Isaac Asimov, Foundation";
            string actual = this.book.ToString(Book.ViewMode.Plain);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TaskBook_ViewMode_PlainPublisher()
        {
            string expected = "Isaac Asimov, Foundation, Bantam, 2004";
            string actual = this.book.ToString(Book.ViewMode.PlainPublisher);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TaskBook_ViewMode_PlainPublisherPrice()
        {
            string expected = "Isaac Asimov, Foundation, Bantam, 2004, 244 pages, $3.75";
            string actual = this.book.ToString(Book.ViewMode.PlainPublisherPrice);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TaskBook_ViewMode_Isbn()
        {
            string expected = "0553803719, Isaac Asimov, Foundation";
            string actual = this.book.ToString(Book.ViewMode.Isbn);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TaskBook_ViewMode_IsbnPublisher()
        {
            string expected = "0553803719, Isaac Asimov, Foundation, Bantam, 2004";
            string actual = this.book.ToString(Book.ViewMode.IsbnPublisher);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TaskBook_ViewMode_IsbnPublisherPrice()
        {
            string expected = "0553803719, Isaac Asimov, Foundation, Bantam, 2004, 244 pages, $3.75";
            string actual = this.book.ToString(Book.ViewMode.IsbnPublisherPrice);

            Assert.AreEqual(expected, actual);
        }
    }
}
