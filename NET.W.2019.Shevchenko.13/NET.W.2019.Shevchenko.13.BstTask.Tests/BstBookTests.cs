using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace NET.W2019.Shevchenko13.BstTask.Tests
{
    [TestClass]
    public class BstBookTests
    {
        Book[] GetBooks()
        {
            var book11 = new Book("B0064CPN7I")
            {
                Author = "Bradbury Ray",
                Title = "Fahrenheit 451",
                Publisher = "Simon & Schuster",
                Year = 2011,
                PageCount = 194,
                Price = 9.45M,
            };

            var book12 = new Book("B003JTHWKU")
            {
                Author = "Orwell George",
                Title = "1984",
                Publisher = "Houghton Mifflin Harcourt",
                Year = 2013,
                PageCount = 237,
                Price = 8.65M,
            };

            var book13 = new Book("0684830493")
            {
                Author = "Hemingway Ernest",
                Title = "The Old Man and the Sea",
                Publisher = "Scribner",
                Year = 1996,
                PageCount = 132,
                Price = 12.79M,
            };

            var book14 = new Book("0060929871")
            {
                Author = "Huxley Aldous",
                Title = "Brave New World",
                Publisher = "HarperPerennial",
                Year = 1998,
                PageCount = 288,
                Price = 5.98M,
            };

            var book15 = new Book("0340839937")
            {
                Author = "Herbert Frank",
                Title = "Dune",
                Publisher = "Hodder & Stoughton",
                Year = 2006,
                PageCount = 604,
                Price = 34.13M,
            };

            var book16 = new Book("0553803719")
            {
                Author = "Asimov Isaac",
                Title = "Foundation",
                Publisher = "Bantam",
                Year = 2004,
                PageCount = 244,
                Price = 3.75M,
            };

            var book21 = new Book("0451490827")
            {
                Author = "Hoang Helen",
                Title = "The Bride Test",
                Publisher = "Berkley",
                Year = 2019,
                PageCount = 296,
                Price = 7.76M,
            };

            var book22 = new Book("1250047323")
            {
                Author = "Center Katherine",
                Title = "Things You Save in a Fire",
                Publisher = "St. Martin's Press",
                Year = 2019,
                PageCount = 320,
                Price = 17.7M,
            };

            var book23 = new Book("9781250295637")
            {
                Author = "O'Leary Beth",
                Title = "The Flatshare",
                Publisher = "Flatiron Books",
                Year = 2019,
                PageCount = 325,
                Price = 13.99M,
            };

            return new Book[] { book11, book12, book13, book14, book15, book16, book21, book22, book23 };
        }

        [TestMethod]
        public void BstBook_AddsValues()
        {
            var values = this.GetBooks();

            var bst = new BinarySearchTree<Book>();

            foreach (var i in values)
            {
                bst.Insert(i);
            }
        }

        [TestMethod]
        public void BstBook_AddsValues_MyComparer()
        {
            var values = this.GetBooks();

            var bst = new BinarySearchTree<Book>((x, y) => x.Author.CompareTo(y.Author));

            foreach (var i in values)
            {
                bst.Insert(i);
            }
        }

        [TestMethod]
        public void BstBook_ContainsAllValues()
        {
            var values = this.GetBooks();

            var bst = new BinarySearchTree<Book>();

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            if (bst.Count != values.Length)
            {
                Assert.Fail();
            }

            foreach (var i in values)
            {
                if (!bst.Contains(i))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void BstBook_RemovesValuesForward()
        {
            var values = this.GetBooks();

            var bst = new BinarySearchTree<Book>();

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            foreach (var i in values)
            {
                bst.Remove(i);
            }

            if (bst.Count != 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstBook_RemovesValuesBackward()
        {
            var values = this.GetBooks();

            var bst = new BinarySearchTree<Book>();

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            for (int i = values.Length - 1; i >= 0; i--)
            {
                bst.Remove(values[i]);
            }

            if (bst.Count != 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstBook_GetsMin()
        {
            var values = this.GetBooks();

            var bst = new BinarySearchTree<Book>();

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            if (values.Min() != bst.GetMinValue())
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstBook_GetsMax()
        {
            var values = this.GetBooks();

            var bst = new BinarySearchTree<Book>();

            foreach (var i in values)
            {
                bst.Insert(i);
            }

            if (values.Max() != bst.GetMaxValue())
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void BstBook_IteratesPreorder()
        {
            var expected = this.GetBooks();

            var actual = new Book[expected.Length];

            var bst = new BinarySearchTree<Book>();

            foreach (var i in expected)
            {
                bst.Insert(i);
            }

            int index = 0;

            foreach (var i in bst.GetValuesPreorder())
            {
                actual[index++] = i;
            }

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void BstBook_IteratesInorder()
        {
            var expected = this.GetBooks();

            var actual = new Book[expected.Length];

            var bst = new BinarySearchTree<Book>();

            foreach (var i in expected)
            {
                bst.Insert(i);
            }

            int index = 0;

            foreach (var i in bst.GetValuesInorder())
            {
                actual[index++] = i;
            }

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void BstBook_IteratesPostorder()
        {
            var expected = this.GetBooks();

            var actual = new Book[expected.Length];

            var bst = new BinarySearchTree<Book>();

            foreach (var i in expected)
            {
                bst.Insert(i);
            }

            int index = 0;

            foreach (var i in bst.GetValuesPostorder())
            {
                actual[index++] = i;
            }

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
