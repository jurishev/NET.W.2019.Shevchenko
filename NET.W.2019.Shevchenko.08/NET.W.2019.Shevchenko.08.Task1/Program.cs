using System;
using System.Collections.Generic;
using System.Globalization;

namespace NET.W2019.Shevchenko08.Task1
{
    /// <summary>
    /// The application to demonstrate the work of Book, BookListService and BookListStorage classes.
    /// </summary>
    public static class Program
    {
        private static BookListStorage storage = new BookListStorage();

        /// <summary>
        /// The assembly entry point.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Task 1 demonstration.");
            Console.WriteLine("EPAM training, winter 2019.");
            Console.WriteLine("By Yuri Shevchenko.\n");

            var list1 = new BookListService("Classics");
            Console.WriteLine($"Collection {list1.Name} with {list1.Count} books has been created.");

            var list2 = new BookListService("Romance");
            Console.WriteLine($"Collection {list2.Name} with {list2.Count} books has been created.");

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

            Console.WriteLine($"{list1.Count} books were added to {list1.Name} collection.");

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

            Console.WriteLine($"{list2.Count} books were added to {list2.Name} collection.");

            Console.WriteLine($"\nThe {list1.Name} collection sorted by author:");
            list1.SortBooksByTag(BookListService.SortBy.Author);
            ShowCollection(list1.GetList());

            Console.WriteLine($"\nThe {list1.Name} collection sorted by title:");
            list1.SortBooksByTag(BookListService.SortBy.Title);
            ShowCollection(list1.GetList());

            Console.WriteLine($"\nThe {list1.Name} collection sorted by year:");
            list1.SortBooksByTag(BookListService.SortBy.Year);
            ShowCollection(list1.GetList());

            Console.WriteLine($"\nFind books by title: 'a'");
            ShowCollection(list1.FindBookByTag(BookListService.SearchBy.Title, "a"));

            Console.WriteLine($"\nFind books by author: 'h'");
            ShowCollection(list1.FindBookByTag(BookListService.SearchBy.Author, "h"));

            Console.WriteLine();
            Console.WriteLine(storage.AddBookList(list1).Item2);
            Console.WriteLine(storage.AddBookList(list2).Item2);
            Console.WriteLine($"Storage has {storage.Count} collections.");

            try
            {
                storage.SaveStorage("storage");
                Console.WriteLine("\nStorage has been successfully saved to a file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine(storage.RemoveBookList(list1.Name).Item2);
            Console.WriteLine(storage.RemoveBookList(list2.Name).Item2);
            Console.WriteLine($"Storage has {storage.Count} collections.");

            try
            {
                storage.LoadStorage("storage");
                Console.WriteLine("\nStorage has been successfully loaded from a file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var collection in Program.storage.GetCollections())
            {
                Console.WriteLine($"\nCollection {collection.Name}:");
                collection.SortBooksByTag(BookListService.SortBy.Author);
                ShowCollectionFull(collection.GetList());
            }

            Console.WriteLine("\nThank you for your attention!");

            Console.ReadKey();
        }

        private static void ShowCollection(IEnumerable<Book> list)
        {
            foreach (var book in list)
            {
                Console.WriteLine(book.ToString());
            }
        }

        private static void ShowCollectionFull(IEnumerable<Book> list)
        {
            foreach (var book in list)
            {
                Console.WriteLine(book.ToString() + $", {book.Publisher,-28} {book.PageCount} {"p.",-4} {book.Price.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")),-10}");
            }
        }
    }
}
