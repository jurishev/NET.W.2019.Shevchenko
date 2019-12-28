namespace UrlExporter.Library
{
    /// <summary>
    /// URL strings provider.
    /// </summary>
    public interface IUrlSource
    {
        /// <summary>
        /// Gets URL strings.
        /// </summary>
        /// <returns>Array of URL strings.</returns>
        string[] GetUrl();
    }
}
