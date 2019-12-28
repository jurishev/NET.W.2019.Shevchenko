namespace UrlExporter.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// URL to XML converter.
    /// </summary>
    public static class UrlToXml
    {
        /// <summary>
        /// Converts an URL string collection to an X-DOM document.
        /// </summary>
        /// <param name="source">URL provider.</param>
        /// <param name="wrongUrl">Array of URL strings with wrong pattern.</param>
        /// <returns>X-DOM document.</returns>
        public static XDocument GetXmlDocument(IUrlSource source, out string[] wrongUrl)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var list = new List<string>();
            var root = new XElement("urlAddresses");

            foreach (var item in source.GetUrl())
            {
                if (UrlToXml.TryParseUrl(item, out var element))
                {
                    root.Add(element);
                }
                else
                {
                    list.Add(item);
                }
            }

            if (list.Count > 0)
            {
                wrongUrl = list.ToArray();
            }
            else
            {
                wrongUrl = null;
            }

            return new XDocument(root);
        }

        /// <summary>
        /// Parses an URL string to an XML record.
        /// </summary>
        /// <param name="input">URL string to parse.</param>
        /// <param name="element">X-DOM record.</param>
        /// <returns>true if parsing went well, false if not.</returns>
        private static bool TryParseUrl(string input, out XElement element)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            element = null;

            /* Get rid of schema */

            var split = input.Split("://");

            if (split.Length < 2 || string.IsNullOrWhiteSpace(split[1]))
            {
                return false;
            }

            /* Split to path and parameters */

            split = split[1].Split('?');

            var path = split[0];
            var parameters = split.Length > 1 && !string.IsNullOrWhiteSpace(split[1])
                ? split[1] : null;

            /* Process path */

            if (path[^1] == '/')
            {
                path = path[0..^1];
            }

            split = path.Split('/');

            var host = split[0];
            var segments = split.Length > 1 ? split.Skip(1).ToArray() : null;

            /* Process parameters */

            (string, string)[] keyVals = null;

            if (parameters != null)
            {
                if (!UrlToXml.TryParseParameters(parameters, out var result))
                {
                    return false;
                }

                keyVals = result;
            }

            /* Compose element */

            element = new XElement("urlAddress",
                new XElement("host", new XAttribute("name", host)));

            if (segments != null)
            {
                var uri = new XElement("uri");

                foreach (var item in segments)
                {
                    if (string.IsNullOrWhiteSpace(item))
                    {
                        return false;
                    }

                    uri.Add(new XElement("segment", item));
                }

                element.Add(uri);
            }

            if (keyVals != null)
            {
                var pars = new XElement("parameters");

                foreach (var item in keyVals)
                {
                    pars.Add(new XElement("parameter",
                        new XAttribute("key", item.Item1), new XAttribute("value", item.Item2)));
                }

                element.Add(pars);
            }

            return true;
        }

        /// <summary>
        /// Parses URL parameters string formatted like key=value&key=value.
        /// </summary>
        /// <param name="input">String to parse.</param>
        /// <param name="result">Tuple array where Item1 is key and Item2 is value.</param>
        /// <returns>true if parsing went well, false if not.</returns>
        private static bool TryParseParameters(string input, out (string, string)[] result)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            result = null;
            var list = new List<(string, string)>();
            var split = input.Split('&');

            foreach (var item in split)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    return false;
                }

                var pair = item.Split('=');

                if (pair.Length < 2
                    || string.IsNullOrWhiteSpace(pair[0])
                    || string.IsNullOrWhiteSpace(pair[1]))
                {
                    return false;
                }

                list.Add((pair[0], pair[1]));
            }

            result = list.ToArray();
            return true;
        }
    }
}
