using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W2019.Shevchenko10.TaskBook.Tests
{
    [TestClass]
    public class TaskBook2
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
        public void TaskBook_BookFormatter_MTA()
        {
            string expected = "$3.75, Foundation, Isaac Asimov";
            string actual = string.Format(new BookFormatter(), "{0:MTA}", this.book);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TaskBook_BookFormatter_ATpI()
        {
            string expected = "Isaac Asimov, Foundation, 244 pages, ISBN: 0553803719";
            string actual = string.Format(new BookFormatter(), "{0:ATpI}", this.book);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TaskBook_BookFormatter_IMTA()
        {
            string expected = "ISBN: 0553803719, $3.75, Foundation, Isaac Asimov";
            string actual = string.Format(new BookFormatter(), "{0:IMTA}", this.book);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TaskBook_BookFormatter_pMIATY()
        {
            string expected = "244 pages, $3.75, ISBN: 0553803719, Isaac Asimov, Foundation, 2004";
            string actual = string.Format(new BookFormatter(), "{0:pMIATY}", this.book);

            Assert.AreEqual(expected, actual);
        }
    }
}
