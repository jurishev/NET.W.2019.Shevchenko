using System;

namespace NET.W2019.Shevchenko13.MatrixTask
{
    /// <summary>
    /// Data container for <see cref="SquareMatrix{T}.ElementChanged"/> event.
    /// </summary>
    /// <typeparam name="T">Type of values of a matrix in which the event has occured.</typeparam>
    public class ElementChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementChangedEventArgs{T}"/> class.
        /// </summary>
        /// <param name="oldValue">Old value of a matrix element.</param>
        /// <param name="newValue">New value of a matrix element.</param>
        /// <param name="i">Vertical index of the matrix.</param>
        /// <param name="j">Horizontal index of the matrix.</param>
        public ElementChangedEventArgs(T oldValue, T newValue, int i, int j)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.I = i;
            this.J = j;
        }

        /// <summary>
        /// Gets old value of a matrix element.
        /// </summary>
        /// <value>Old value of a matrix element.</value>
        public T OldValue { get; }

        /// <summary>
        /// Gets new value of a matrix element.
        /// </summary>
        /// <value>New value of a matrix element.</value>
        public T NewValue { get; }

        /// <summary>
        /// Gets vertical index position.
        /// </summary>
        /// <value>Vertical index position.</value>
        public int I { get; }

        /// <summary>
        /// Gets horizontal index position.
        /// </summary>
        /// <value>Horizontal index position.</value>
        public int J { get; }
    }
}
