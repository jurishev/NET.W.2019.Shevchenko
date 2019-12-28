namespace UrlExporter.Console
{
    using System;
    using System.IO;
    using UrlExporter.Library;

    /// <summary>
    /// URL to XML demonstrator.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The assembly entry point.
        /// </summary>
        /// <param name="args">Command line parameters.</param>
        internal static void Main(string[] args)
        {
            if (args is null || args.Length < 2)
            {
                Console.WriteLine("Please provide input and output file names.");
                Environment.Exit(0);
            }

            var inputFileName = args[0];
            var outputFileName = args[1];

            try
            {
                var document = UrlToXml.GetXmlDocument(new UrlProvider(File.ReadAllLines(inputFileName)), out var badLines);
                document.Save(outputFileName);

                if (badLines != null)
                {
                    foreach (var item in badLines)
                    {
                        Console.WriteLine($"Wrong URL pattern: {item}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
