using System;
using System.Collections.Generic;
using System.IO;

namespace NET.W2019.Shevchenko10.TaskBook
{
    /// <summary>
    /// The storage to keep book collections.
    /// </summary>
    public class BookListStorage
    {
        private Dictionary<string, BookListService> storage;

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
                throw new FieldAccessException("No collections in the storage.");
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
        /// <returns>true or false to indicate the result of the operation, and the corresponding message.</returns>
        public (bool, string) AddBookList(BookListService bookList)
        {
            if (bookList is null)
            {
                return (false, "No collection to storage.");
            }

            if (this.storage is null)
            {
                this.storage = new Dictionary<string, BookListService>();
            }
            else if (this.storage.ContainsKey(bookList.Name))
            {
                this.storage.Remove(bookList.Name);
            }

            this.storage.Add(bookList.Name, bookList);

            return (true, $"The collection {bookList.Name} has been storaged.");
        }

        /// <summary>
        /// Removes a collection out of the storage.
        /// </summary>
        /// <param name="bookListName">The name of a collection to be removed.</param>
        /// <returns>true or false to indicate the result of the operation, and the corresponding message.</returns>
        public (bool, string) RemoveBookList(string bookListName)
        {
            if (string.IsNullOrWhiteSpace(bookListName))
            {
                return (false, "No collection name has been supplied.");
            }

            if (this.storage is null)
            {
                return (false, "No storage has been created yet.");
            }

            if (this.storage.ContainsKey(bookListName))
            {
                this.storage.Remove(bookListName);
                return (true, $"The collection {bookListName} has been removed from the storage.");
            }

            return (false, $"There is no collection {bookListName} in the storage.");
        }

        /// <summary>
        /// Saves all the collections that are currently kept in the storage to a file.
        /// </summary>
        /// <param name="fileName">The file name to be used during saving.</param>
        public void SaveStorage(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("No file name has been supplied.");
            }

            if (this.storage == null)
            {
                throw new FieldAccessException("No storage has been created yet.");
            }

            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                using (BinaryWriter binWriter = new BinaryWriter(fileStream))
                {
                    binWriter.Write(this.storage.Count);

                    foreach (var bookList in this.storage.Values)
                    {
                        binWriter.Write(bookList.Name);

                        binWriter.Write(bookList.Count);

                        foreach (var book in bookList.GetList())
                        {
                            binWriter.Write(book.Isbn);
                            binWriter.Write(book.Author);
                            binWriter.Write(book.Title);
                            binWriter.Write(book.Publisher);
                            binWriter.Write(book.Year);
                            binWriter.Write(book.PageCount);
                            binWriter.Write(book.Price);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Loads all collections that are kept in the specified file.
        /// </summary>
        /// <param name="fileName">The file name to be used during loading.</param>
        public void LoadStorage(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("No file name has been supplied.");
            }

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                using (BinaryReader binReader = new BinaryReader(fileStream))
                {
                    this.storage = new Dictionary<string, BookListService>();

                    int collectionsCount = binReader.ReadInt32();

                    while (collectionsCount-- > 0)
                    {
                        string bookListName = binReader.ReadString();

                        var bookList = new BookListService(bookListName);

                        int booksCount = binReader.ReadInt32();

                        while (booksCount-- > 0)
                        {
                            string isbn = binReader.ReadString();

                            var book = new Book(isbn)
                            {
                                Author = binReader.ReadString(),
                                Title = binReader.ReadString(),
                                Publisher = binReader.ReadString(),
                                Year = binReader.ReadInt32(),
                                PageCount = binReader.ReadInt32(),
                                Price = binReader.ReadDecimal(),
                            };

                            bookList.AddBook(book);
                        }

                        this.storage.Add(bookList.Name, bookList);
                    }
                }
            }
        }
    }
}
