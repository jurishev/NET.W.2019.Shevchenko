using System;

namespace NET.W2019.Shevchenko12.TaskBook
{
    /// <summary>
    /// An optional static entry point for logging.
    /// To configure set the Logger static property to a logger instance.
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Gets or sets current logger instance.
        /// </summary>
        /// <value>Current logger instance.</value>
        public static IBookServiceLogger Logger { get; set; } = new CustomLogger();

        /// <summary>
        /// Makes a log on Debug level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Debug(string message)
        {
            Log.Logger.Debug(message);
        }

        /// <summary>
        /// Makes a log on Debug level.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <param name="message">The message to log.</param>
        public static void Debug(Exception ex, string message)
        {
            Log.Logger.Debug(ex, message);
        }

        /// <summary>
        /// Makes a log message on Information level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Information(string message)
        {
            Log.Logger.Information(message);
        }

        /// <summary>
        /// Makes a log message on Information level.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <param name="message">The message to log.</param>
        public static void Information(Exception ex, string message)
        {
            Log.Logger.Information(ex, message);
        }

        /// <summary>
        /// Makes a log on Warning level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Warning(string message)
        {
            Log.Logger.Warning(message);
        }

        /// <summary>
        /// Makes a log on Warning level.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <param name="message">The message to log.</param>
        public static void Warning(Exception ex, string message)
        {
            Log.Logger.Warning(ex, message);
        }

        /// <summary>
        /// Makes a log on Error level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Error(string message)
        {
            Log.Logger.Error(message);
        }

        /// <summary>
        /// Makes a log on Error level.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <param name="message">The message to log.</param>
        public static void Error(Exception ex, string message)
        {
            Log.Logger.Error(ex, message);
        }

        /// <summary>
        /// Makes a log on Fatal level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void Fatal(string message)
        {
            Log.Logger.Fatal(message);
        }

        /// <summary>
        /// Makes a log on Fatal level.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <param name="message">The message to log.</param>
        public static void Fatal(Exception ex, string message)
        {
            Log.Logger.Fatal(ex, message);
        }
    }
}
