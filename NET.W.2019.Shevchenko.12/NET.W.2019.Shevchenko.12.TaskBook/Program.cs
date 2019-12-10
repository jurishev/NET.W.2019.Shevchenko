using System;
using System.Collections.Generic;
using System.Globalization;

namespace NET.W2019.Shevchenko12.TaskBook
{
    /// <summary>
    /// Demonstrates the work of Book, BookListService and BookListStorage classes.
    /// </summary>
    public static class Program
    {
        private static BookListStorage storage = new BookListStorage();

        /// <summary>
        /// The assembly entry point.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine();
            Console.WriteLine("EPAM training, winter 2019.");
            Console.WriteLine("Day 10 Homework demonstration.");
            Console.WriteLine("By Yuri Shevchenko.\n");

            var list1 = new BookListService("Classics");
            var list2 = new BookListService("Romance");

            var book11 = new Book("B0064CPN7I")
            {
                Author = "Ray Bradbury",
                Title = "Fahrenheit 451",
                Publisher = "Simon & Schuster",
                Year = 2011,
                PageCount = 194,
                Price = 9.45M,
            };
            var book12 = new Book("B003JTHWKU")
            {
                Author = "George Orwell",
                Title = "1984",
                Publisher = "Houghton Mifflin Harcourt",
                Year = 2013,
                PageCount = 237,
                Price = 8.65M,
            };
            var book13 = new Book("0684830493")
            {
                Author = "Ernest Hemingway",
                Title = "The Old Man and the Sea",
                Publisher = "Scribner",
                Year = 1996,
                PageCount = 132,
                Price = 12.79M,
            };
            var book14 = new Book("0060929871")
            {
                Author = "Aldous Huxley",
                Title = "Brave New World",
                Publisher = "HarperPerennial",
                Year = 1998,
                PageCount = 288,
                Price = 5.98M,
            };
            var book15 = new Book("0340839937")
            {
                Author = "Frank Herbert",
                Title = "Dune",
                Publisher = "Hodder & Stoughton",
                Year = 2006,
                PageCount = 604,
                Price = 34.13M,
            };
            var book16 = new Book("0553803719")
            {
                Author = "Isaac Asimov",
                Title = "Foundation",
                Publisher = "Bantam",
                Year = 2004,
                PageCount = 244,
                Price = 3.75M,
            };
            var book21 = new Book("0451490827")
            {
                Author = "Helen Hoang",
                Title = "The Bride Test",
                Publisher = "Berkley",
                Year = 2019,
                PageCount = 296,
                Price = 7.76M,
            };
            var book22 = new Book("1250047323")
            {
                Author = "Katherine Center",
                Title = "Things You Save in a Fire",
                Publisher = "St. Martin's Press",
                Year = 2019,
                PageCount = 320,
                Price = 17.7M,
            };
            var book23 = new Book("9781250295637")
            {
                Author = "Beth O'Leary",
                Title = "The Flatshare",
                Publisher = "Flatiron Books",
                Year = 2019,
                PageCount = 325,
                Price = 13.99M,
            };

            Console.WriteLine();

            try
            {
                list1.AddBook(book11);
                list1.AddBook(book12);
                list1.AddBook(book13);
                list1.AddBook(book14);
                list1.AddBook(book15);
                list1.AddBook(book16);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine();

            try
            {
                list2.AddBook(book21);
                list2.AddBook(book22);
                list2.AddBook(book23);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine();

            list1.SortBooksByTag(BookListService.SortBy.Author);
            ShowCollection(list1.GetList());

            list1.SortBooksByTag(BookListService.SortBy.Title);
            ShowCollection(list1.GetList());

            list1.SortBooksByTag(BookListService.SortBy.Year);
            ShowCollection(list1.GetList());

            ShowCollection(list1.FindBookByTag(BookListService.SearchBy.Title, "a"));
            ShowCollection(list1.FindBookByTag(BookListService.SearchBy.Author, "h"));

            storage.AddBookList(list1);
            storage.AddBookList(list2);

            Console.WriteLine();

            try
            {
                storage.SaveStorage("storage");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            storage.RemoveBookList(list1.Name);
            storage.RemoveBookList(list2.Name);

            Console.WriteLine();

            Log.Information("Loading collectins from a file...");

            Console.WriteLine();

            try
            {
                storage.LoadStorage("storage");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            foreach (var collection in Program.storage.GetCollections())
            {
                collection.SortBooksByTag(BookListService.SortBy.Author);
                ShowCollection(collection.GetList());
            }

            Console.WriteLine("Thank you for your attention!");

            Console.ReadKey();
        }

        private static void ShowCollection(IEnumerable<Book> list)
        {
            Console.WriteLine();

            foreach (var book in list)
            {
                Console.WriteLine($"{book.Author,-20} {book.Title,-30} {book.Year,-6} {book.Price.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")),-10}");
            }

            Console.WriteLine();
        }
    }
}
