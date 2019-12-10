using System;

namespace NET.W2019.Shevchenko12.TaskClock
{
    /// <summary>
    /// Represents arguments of the <see cref="CountDown.TimeIsUp"/> event.
    /// </summary>
    public class TimeIsUpEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeIsUpEventArgs"/> class.
        /// </summary>
        /// <param name="started">Time of countdown's start.</param>
        /// <param name="finished">Time of countdown's finish.</param>
        public TimeIsUpEventArgs(DateTime started, DateTime finished)
        {
            this.CountDownStarted = started;
            this.CountDownFinished = finished;
        }

        /// <summary>
        /// Gets the time when countdown started.
        /// </summary>
        /// <value>The time when countdown started.</value>
        public DateTime CountDownStarted { get; }

        /// <summary>
        /// Gets the time when countdown finished.
        /// </summary>
        /// <value>The time when countdown finished.</value>
        public DateTime CountDownFinished { get; }
    }
}
