using System;

namespace NET.W2019.Shevchenko12.TaskBook
{
    /// <summary>
    /// Logging interface for the book service application.
    /// </summary>
    public interface IBookServiceLogger
    {
        /// <summary>
        /// Logs a message on Debug level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Debug(string message);

        /// <summary>
        /// Logs a message on Debug level.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <param name="message">The message to log.</param>
        void Debug(Exception ex, string message);

        /// <summary>
        /// Logs a message on Information level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Information(string message);

        /// <summary>
        /// Logs a message on Information level.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <param name="message">The message to log.</param>
        void Information(Exception ex, string message);

        /// <summary>
        /// Logs a message on Warning level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Warning(string message);

        /// <summary>
        /// Logs a message on Warning level.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <param name="message">The message to log.</param>
        void Warning(Exception ex, string message);

        /// <summary>
        /// Logs a message on Error level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Error(string message);

        /// <summary>
        /// Logs a message on Error level.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <param name="message">The message to log.</param>
        void Error(Exception ex, string message);

        /// <summary>
        /// Logs a message on Fatal level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Fatal(string message);

        /// <summary>
        /// Logs a message on Fatal level.
        /// </summary>
        /// <param name="ex">Exception instance.</param>
        /// <param name="message">The message to log.</param>
        void Fatal(Exception ex, string message);
    }
}
