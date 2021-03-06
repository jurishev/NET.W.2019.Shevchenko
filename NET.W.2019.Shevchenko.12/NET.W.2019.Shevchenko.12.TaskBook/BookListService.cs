﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NET.W2019.Shevchenko12.TaskBook
{
    /// <summary>
    /// A service to operate with a set of Books.
    /// </summary>
    public class BookListService
    {
        private HashSet<Book> bookSet = new HashSet<Book>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="bookListName">A name for a list to be created.</param>
        public BookListService(string bookListName)
        {
            this.Name = bookListName;

            Log.Information($"Collection '{bookListName}' has been created.");
        }

        /// <summary>
        /// Tags to determine a search criteria.
        /// </summary>
        public enum SearchBy
        {
            /// <summary>
            /// Search by a book's ISBN.
            /// </summary>
            Isbn,

            /// <summary>
            /// Search by a book's author.
            /// </summary>
            Author,

            /// <summary>
            /// Search by a book's title.
            /// </summary>
            Title,

            /// <summary>
            /// Search by a book's publisher.
            /// </summary>
            Publisher,
        }

        /// <summary>
        /// Tags to determine a sorting criteria.
        /// </summary>
        public enum SortBy
        {
            /// <summary>
            /// Sort by a book's author.
            /// </summary>
            Author,

            /// <summary>
            /// Sort by a book's title.
            /// </summary>
            Title,

            /// <summary>
            /// Sort by a book's publish year.
            /// </summary>
            Year,

            /// <summary>
            /// Sort by a book's price.
            /// </summary>
            Price,
        }

        /// <summary>
        /// Gets the name of the current collection.
        /// </summary>
        /// <value>The name of the current collection.</value>
        public string Name { get; }

        /// <summary>
        /// Gets the number of books in the current collection.
        /// </summary>
        /// <value>Number of books in the collection.</value>
        public int Count
        {
            get
            {
                return this.bookSet.Count;
            }
        }

        /// <summary>
        /// Adds a book in the collection.
        /// </summary>
        /// <param name="book">A book to be added to the collection.</param>
        public void AddBook(Book book)
        {
            if (book is null)
            {
                var msg = "NULL has been provided to AddBook";
                var ex = new ArgumentException(msg);
                Log.Error(ex, msg);
                throw ex;
            }

            if (!this.bookSet.Add(book))
            {
                var msg = $"Book '{book.Isbn}' already exists in '{this.Name}' collection.";
                Log.Warning(msg);
            }

            Log.Information($"Book '{book.Isbn}' has been added to '{this.Name}' collection.");
        }

        /// <summary>
        /// Removes a book from the collection.
        /// </summary>
        /// <param name="book">A book to be removed from the collection.</param>
        public void RemoveBook(Book book)
        {
            if (book is null)
            {
                var msg = "NULL has been provided to AddBook";
                var ex = new ArgumentException(msg);
                Log.Error(ex, msg);
                throw ex;
            }

            if (!this.bookSet.Remove(book))
            {
                var msg = $"An attempt to remove nonexistent book '{book.Isbn}' from '{this.Name}' collection.";
                Log.Warning(msg);
            }

            Log.Information($"Book '{book.Isbn}' has been removed from {this.Name} collection.");
        }

        /// <summary>
        /// Sorts the books in the current collection by the specified tag.
        /// </summary>
        /// <param name="tag">The sorting criteria.</param>
        public void SortBooksByTag(SortBy tag)
        {
            if (!Enum.IsDefined(typeof(SortBy), tag))
            {
                Log.Warning($"Wrong tag '{tag}' has been provided to SortBooksByTag.");

                tag = SortBy.Author;
            }

            switch (tag)
            {
                case SortBy.Author:
                    this.bookSet = new HashSet<Book>(this.bookSet.OrderBy(b => b.Author.Split(' ').Last()));
                    break;

                case SortBy.Title:
                    this.bookSet = new HashSet<Book>(this.bookSet.OrderBy(b => b.Title));
                    break;

                case SortBy.Year:
                    this.bookSet = new HashSet<Book>(this.bookSet.OrderBy(b => b.Year));
                    break;

                case SortBy.Price:
                    this.bookSet = new HashSet<Book>(this.bookSet.OrderBy(b => b.Price));
                    break;

                default:
                    goto case SortBy.Author;
            }

            Log.Information($"'{this.Name}' collection has been sorted by {tag}.");
        }

        /// <summary>
        /// Finds all books that contain the given value in their properties.
        /// </summary>
        /// <param name="tag">The searching criteria.</param>
        /// <param name="keyword">The keyword to be used in the search.</param>
        /// <returns>A collection of the found books.</returns>
        public IEnumerable<Book> FindBookByTag(SearchBy tag, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                var msg = "NULL or empty keyword has been provided to FindBookByTag";
                var ex = new ArgumentException(msg);
                Log.Error(ex, msg);
                throw ex;
            }

            string subset = keyword.ToUpperInvariant();

            if (!Enum.IsDefined(typeof(SearchBy), tag))
            {
                Log.Warning($"Wrong tag '{tag}' has been provided to FindBookByTag.");

                tag = SearchBy.Isbn;
            }

            Log.Information($"Search by {tag} in '{this.Name}' collection has been processed.");

            switch (tag)
            {
                case SearchBy.Isbn:
                    return this.bookSet.Where(b => string.Equals(b.Isbn, keyword, StringComparison.OrdinalIgnoreCase));

                case SearchBy.Author:
                    return this.bookSet.Where(b => b.Author.ToUpperInvariant().Contains(subset));

                case SearchBy.Title:
                    return this.bookSet.Where(b => b.Title.ToUpperInvariant().Contains(subset));

                case SearchBy.Publisher:
                    return this.bookSet.Where(b => b.Publisher.ToUpperInvariant().Contains(subset));

                default:
                    goto case SearchBy.Isbn;
            }
        }

        /// <summary>
        /// Gets a list of all the books stored in the current collection.
        /// </summary>
        /// <returns>A collection of the stored books.</returns>
        public IEnumerable<Book> GetList()
        {
            return this.bookSet.AsEnumerable();
        }
    }
}
