using System;
using System.Threading;

namespace NET.W2019.Shevchenko12.TaskClock
{
    /// <summary>
    /// Demonstrates work of event type.
    /// </summary>
    public class CountDown
    {
        private DateTime started;
        private DateTime finished;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountDown"/> class.
        /// </summary>
        /// <param name="timeToGo">Timeout in seconds from 1 to 60.</param>
        public CountDown(int timeToGo)
        {
            if (timeToGo == 0)
            {
                this.TimeToGo = 10;
                return;
            }

            if (timeToGo < 0)
            {
                timeToGo = Math.Abs(timeToGo);
            }

            if (timeToGo > 60)
            {
                this.TimeToGo = 60;
                return;
            }

            this.TimeToGo = timeToGo;
        }

        /// <summary>
        /// Fires when TimeToGo value becomes 0.
        /// </summary>
        public event EventHandler<TimeIsUpEventArgs> TimeIsUp;

        /// <summary>
        /// Gets current timeout value.
        /// </summary>
        /// <value>Time to fire the event in seconds.</value>
        public int TimeToGo { get; private set; }

        /// <summary>
        /// Starts the countdown. Reduces <see cref="CountDown"/> value by 1 each second.
        /// </summary>
        public void Start()
        {
            this.started = DateTime.Now;

            do
            {
                Console.WriteLine($"Time to go: {this.TimeToGo} seconds.");
                Thread.Sleep(1000);
            }
            while (--this.TimeToGo > 0);

            this.finished = DateTime.Now;

            this.OnTimeIsUp(new TimeIsUpEventArgs(this.started, this.finished));
        }

        /// <summary>
        /// Fires the <see cref="TimeIsUp"/> event.
        /// </summary>
        /// <param name="e">Arguments for the event.</param>
        protected virtual void OnTimeIsUp(TimeIsUpEventArgs e)
        {
            this.TimeIsUp?.Invoke(this, e);
        }
    }
}
