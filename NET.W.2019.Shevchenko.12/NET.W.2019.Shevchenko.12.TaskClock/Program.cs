using System;

namespace NET.W2019.Shevchenko12.TaskClock
{
    /// <summary>
    /// Demonstrates work of the event type.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The assembly entry point.
        /// </summary>
        public static void Main()
        {
            var coutDown = new CountDown(3);
            var subscriber = new Subscriber();

            coutDown.TimeIsUp += subscriber.Reaction;
            coutDown.TimeIsUp += subscriber.OtherReaction;
            coutDown.TimeIsUp += Program.Reaction;

            coutDown.Start();

            Console.ReadKey();
        }

        /// <summary>
        /// Reacts on the <see cref="CountDown.TimeIsUp"/> event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        public static void Reaction(object sender, EventArgs e)
        {
            if (sender is null || e is null)
            {
                throw new ArgumentException("Null arguments for ProgramReaction");
            }

            Console.WriteLine();
            Console.WriteLine($"< Program Reaction > has been triggered by {sender.ToString()}");
            Console.WriteLine($"Arguments: {e.GetType().Name}");
        }
    }
}
