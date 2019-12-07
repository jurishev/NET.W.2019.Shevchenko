using System;
using System.Globalization;
using System.Text;

namespace NET.W2019.Shevchenko10.TaskBook
{
    /// <summary>
    /// Implements custom format of <see cref="Book"/> data.
    /// </summary>
    public class BookFormatter : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Implementation of <see cref="IFormatProvider"/> interface.
        /// </summary>
        /// <param name="formatType">The format type.</param>
        /// <returns>The current instance.</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Implementation of <see cref="ICustomFormatter"/> interface.
        /// </summary>
        /// <param name="format">The custom format.</param>
        /// <param name="arg">The <see cref="Book"/> instance with data to be formatted.</param>
        /// <param name="formatProvider">Format provider.</param>
        /// <returns>The formatted string.</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is null || !(arg is Book) || string.IsNullOrWhiteSpace(format))
            {
                return string.Format(CultureInfo.CurrentCulture, "{0:" + format + "}", arg);
            }

            Book book = arg as Book;

            var sb = new StringBuilder();

            foreach (char letter in format)
            {
                switch (letter)
                {
                    case 'I':
                        sb.Append("ISBN: " + book.Isbn + ", ");
                        break;

                    case 'A':
                        sb.Append(book.Author + ", ");
                        break;

                    case 'T':
                        sb.Append(book.Title + ", ");
                        break;

                    case 'P':
                        sb.Append(book.Publisher + ", ");
                        break;

                    case 'Y':
                        sb.Append(book.Year + ", ");
                        break;

                    case 'p':
                        sb.Append(book.PageCount + " pages, ");
                        break;

                    case 'M':
                        sb.Append(book.Price.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")) + ", ");
                        break;

                    default:
                        continue;
                }
            }

            // Wrong format
            if (sb.Length == 0)
            {
                return string.Format(CultureInfo.CurrentCulture, "{0:" + format + "}", arg);
            }

            // Get rid of the last ", "
            if (sb.Length >= 3 && sb[sb.Length - 1] == ' ' && sb[sb.Length - 2] == ',')
            {
                sb.Length -= 2;
            }

            return sb.ToString();
        }
    }
}
