namespace UrlExporter.Console
{
    using System;
    using UrlExporter.Library;

    /// <inheritdoc/>
    internal class UrlProvider : IUrlSource
    {
        private readonly string[] lines;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlProvider"/> class.
        /// </summary>
        /// <param name="lines">URl collection.</param>
        public UrlProvider(string[] lines)
        {
            if (lines is null)
            {
                throw new ArgumentNullException(nameof(lines));
            }

            if (lines.Length == 0)
            {
                throw new ArgumentException("No data.");
            }

            this.lines = lines;
        }

        /// <inheritdoc/>
        public string[] GetUrl()
        {
            return this.lines;
        }
    }
}
