﻿using System;
using System.Linq;

namespace NET.W2019.Shevchenko08.Task1
{
    /// <summary>
    /// Represents a book to use in BookListService.
    /// </summary>
    public class Book : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">ISBN of a book.</param>
        public Book(string isbn)
        {
            this.Isbn = isbn;
        }

        /// <summary>
        /// Gets a book's ISBN.
        /// </summary>
        /// <value>A book's ISBN. Used by hashing algorithms, so must be read only.</value>
        public string Isbn { get; }

        /// <summary>
        /// Gets or sets a book's author.
        /// </summary>
        /// <value>A book's author.</value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets a book's title.
        /// </summary>
        /// <value>A book's title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a book's publisher.
        /// </summary>
        /// <value>A book's publisher.</value>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets a book's publish year.
        /// </summary>
        /// <value>A book's publish year.</value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets a book's page count.
        /// </summary>
        /// <value>A book's page count.</value>
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets a book's price.
        /// </summary>
        /// <value>A book's price.</value>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public int CompareTo(object obj)
        {
            if (!(obj is Book))
            {
                throw new ArgumentException("The object to compare to is not a Book.");
            }

            return this.CompareTo(obj as Book);
        }

        /// <summary>
        /// Compares the current instance of a book with another book.
        /// </summary>
        /// <param name="book">A book to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the books.</returns>
        public int CompareTo(Book book)
        {
            if (book is null)
            {
                return 1;
            }

            int result = string.CompareOrdinal(this.Author, book.Author);

            if (result == 0)
            {
                result = string.CompareOrdinal(this.Title, book.Title);

                if (result == 0)
                {
                    result = this.Year - book.Year;
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (!(obj is Book))
            {
                return false;
            }

            return this.Equals(obj as Book);
        }

        /// <summary>
        /// Determines whether the specified book is equal to the current book.
        /// </summary>
        /// <param name="book">The book to compare with the current book.</param>
        /// <returns>true if the specified book is equal to the current book; otherwise, false.</returns>
        public bool Equals(Book book)
        {
            if (book is null)
            {
                return false;
            }

            if (ReferenceEquals(this, book))
            {
                return true;
            }

            if (string.Equals(this.Isbn, book.Isbn, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            string upperIsbn = this.Isbn.ToUpperInvariant();
            return upperIsbn.Sum(c => c);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Author,-20} {this.Title,-28} {this.Year}";
        }
    }
}
