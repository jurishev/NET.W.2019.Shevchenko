using System;
using System.Globalization;

namespace NET.W2019.Shevchenko12.TaskClock
{
    /// <summary>
    /// Represents methods that subscribe for the <see cref="CountDown.TimeIsUp"/> event.
    /// </summary>
    public class Subscriber
    {
        /// <summary>
        /// Reacts on the <see cref="CountDown.TimeIsUp"/> event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        public void Reaction(object sender, TimeIsUpEventArgs e)
        {
            if (sender is null || e is null)
            {
                throw new ArgumentException("Wrong arguments.");
            }

            Console.WriteLine();
            Console.WriteLine($"< Subscriber Reaction > has been triggered by {sender.ToString()}");
            Console.WriteLine($"Countdown started: {e.CountDownStarted.ToString("hh:mm:ss", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Countdown finished: {e.CountDownFinished.ToString("hh:mm:ss", CultureInfo.InvariantCulture)}");
        }

        /// <summary>
        /// Reacts on the <see cref="CountDown.TimeIsUp"/> event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        public void OtherReaction(object sender, TimeIsUpEventArgs e)
        {
            if (sender is null || e is null)
            {
                throw new ArgumentException("Wrong EventArgs");
            }

            Console.WriteLine();
            Console.WriteLine($"< Subscriber Other Reaction > has been triggered by {sender.ToString()}");
            Console.WriteLine($"Countdown started: {e.CountDownStarted.ToString("hh:mm:ss", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Countdown finished: {e.CountDownFinished.ToString("hh:mm:ss", CultureInfo.InvariantCulture)}");
        }
    }
}
