using System;
using System.Collections.Generic;
using System.IO;

namespace NET.W2019.Shevchenko12.TaskBook
{
    /// <summary>
    /// The storage to keep book collections.
    /// </summary>
    public class BookListStorage
    {
        private Dictionary<string, BookListService> storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListStorage"/> class.
        /// </summary>
        public BookListStorage()
        {
            Log.Information("BookListStorage instance has been created.");
        }

        /// <summary>
        /// Gets the number of collections that are currently kept in the storage.
        /// </summary>
        /// <value>The number of collections that are currently kept in the storage.</value>
        public int Count
        {
            get
            {
                return this.storage.Count;
            }
        }

        /// <summary>
        /// Gets a collection of book collections that are currently kept in the storage.
        /// </summary>
        /// <returns>A collection of book collections.</returns>
        public IEnumerable<BookListService> GetCollections()
        {
            if (this.storage is null)
            {
                Log.Warning("An attempt to get collections from empty storage.");
                yield break;
            }

            foreach (BookListService bookList in this.storage.Values)
            {
                yield return bookList;
            }
        }

        /// <summary>
        /// Adds a collection into the storage.
        /// </summary>
        /// <param name="bookList">The collection to be stored.</param>
        public void AddBookList(BookListService bookList)
        {
            if (bookList is null)
            {
                var msg = "NULL has been provided to AddBookList";
                var ex = new ArgumentException(msg);
                Log.Error(ex, msg);
                throw ex;
            }

            if (this.storage is null)
            {
                this.storage = new Dictionary<string, BookListService>();
            }
            else if (this.storage.ContainsKey(bookList.Name))
            {
                var msg = "Collection with a same name has been provided. Overwriting.";
                Log.Warning(msg);

                this.storage.Remove(bookList.Name);
            }

            this.storage.Add(bookList.Name, bookList);

            Log.Information($"Collection '{bookList.Name}' have been storaged.");

            return;
        }

        /// <summary>
        /// Removes a collection out of the storage.
        /// </summary>
        /// <param name="bookListName">The name of a collection to be removed.</param>
        public void RemoveBookList(string bookListName)
        {
            if (string.IsNullOrWhiteSpace(bookListName))
            {
                Log.Warning("Null or empty collection name has been provided to RemoveBookList");
                return;
            }

            if (this.storage is null)
            {
                Log.Warning($"An attempt to remove collection '{bookListName}' from empty storage.");
                return;
            }

            if (this.storage.ContainsKey(bookListName))
            {
                this.storage.Remove(bookListName);

                Log.Information($"Collection '{bookListName}' hase been removed from the storage.");

                return;
            }

            var msg = $"Failed to remove collection '{bookListName}' from storage.";
            var ex = new InvalidOperationException(msg);
            Log.Error(ex, msg);
            throw ex;
        }

        /// <summary>
        /// Saves all the collections that are currently kept in the storage to a file.
        /// </summary>
        /// <param name="fileName">The file name to be used during saving.</param>
        public void SaveStorage(string fileName)
        {
            if (this.storage == null)
            {
                Log.Error("An attempt to save empty storage.");
                return;
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                var msg = "No file name has been provided to save storage.";
                var ex = new ArgumentException(msg);
                Log.Error(ex, msg);
                throw ex;
            }

            using (var writer = new BinaryWriter(new FileStream(fileName, FileMode.OpenOrCreate)))
            {
                writer.Write(this.storage.Count); // Number of collections

                foreach (var bookList in this.storage.Values)
                {
                    writer.Write(bookList.Name); // A collection name
                    writer.Write(bookList.Count); // Number of books

                    foreach (var book in bookList.GetList())
                    {
                        writer.Write(book.Isbn);
                        writer.Write(book.Author);
                        writer.Write(book.Title);
                        writer.Write(book.Publisher);
                        writer.Write(book.Year);
                        writer.Write(book.PageCount);
                        writer.Write(book.Price);
                    }
                }
            }

            Log.Information($"Collections in the storage have been saved to file '{fileName}'.");
        }

        /// <summary>
        /// Loads all collections that are kept in the specified file.
        /// </summary>
        /// <param name="fileName">The file name to be used during loading.</param>
        public void LoadStorage(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                var msg = "No file name has been provided to load for storage.";
                var ex = new ArgumentException(msg);
                Log.Error(ex, msg);
                throw ex;
            }

            using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                this.storage = new Dictionary<string, BookListService>();
                int collectionsCount = reader.ReadInt32();

                while (collectionsCount-- > 0)
                {
                    var bookList = new BookListService(reader.ReadString());
                    int booksCount = reader.ReadInt32();

                    while (booksCount-- > 0)
                    {
                        string isbn = reader.ReadString();

                        var book = new Book(isbn)
                        {
                            Author = reader.ReadString(),
                            Title = reader.ReadString(),
                            Publisher = reader.ReadString(),
                            Year = reader.ReadInt32(),
                            PageCount = reader.ReadInt32(),
                            Price = reader.ReadDecimal(),
                        };

                        bookList.AddBook(book);
                    }

                    this.storage.Add(bookList.Name, bookList);
                }
            }

            Log.Information($"Collections have been loaded to the storage from file '{fileName}'.");
        }
    }
}
