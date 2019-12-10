using System;
using Serilog;

namespace NET.W2019.Shevchenko12.TaskBook
{
    /// <inheritdoc/>
    public class CustomLogger : IBookServiceLogger
    {
        private readonly Serilog.Core.Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLogger"/> class.
        /// </summary>
        public CustomLogger()
        {
            this.logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        /// <inheritdoc/>
        public void Debug(string message)
        {
            this.logger.Debug(message);
        }

        /// <inheritdoc/>
        public void Debug(Exception ex, string message)
        {
            this.logger.Debug(ex, message);
        }

        /// <inheritdoc/>
        public void Information(string message)
        {
            this.logger.Information(message);
        }

        /// <inheritdoc/>
        public void Information(Exception ex, string message)
        {
            this.logger.Information(ex, message);
        }

        /// <inheritdoc/>
        public void Warning(string message)
        {
            this.logger.Warning(message);
        }

        /// <inheritdoc/>
        public void Warning(Exception ex, string message)
        {
            this.logger.Warning(ex, message);
        }

        /// <inheritdoc/>
        public void Error(string message)
        {
            this.logger.Error(message);
        }

        /// <inheritdoc/>
        public void Error(Exception ex, string message)
        {
            this.logger.Error(ex, message);
        }

        /// <inheritdoc/>
        public void Fatal(string message)
        {
            this.logger.Fatal(message);
        }

        /// <inheritdoc/>
        public void Fatal(Exception ex, string message)
        {
            this.logger.Fatal(ex, message);
        }
    }
}
