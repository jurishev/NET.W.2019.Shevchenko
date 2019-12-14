using System;

namespace NET.W2019.Shevchenko13.MatrixTask
{
    /// <summary>
    /// Represents generic square matrix.
    /// </summary>
    /// <typeparam name="T">Type of the matrix values.</typeparam>
    public class SquareMatrix<T>
    {
        private readonly T[,] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="order">Height and width of the matrix.</param>
        public SquareMatrix(int order)
        {
            if (order <= 0)
            {
                throw new ArgumentException("Order value of a matrix must be positive.");
            }

            this.matrix = new T[order, order];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// Wraps the provided array without cloning it.
        /// </summary>
        /// <param name="matrix">A predefined array that can be represented as <see cref="SquareMatrix{T}"/> type.</param>
        public SquareMatrix(T[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                this.matrix = matrix;
            }
            else
            {
                throw new ArgumentException("The matrix must be square.");
            }
        }

        /// <summary>
        /// Fires when an element of the matrix has been assigned with new value.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        /// <summary>
        /// Gets the order of the current matrix, i.e. its height and width.
        /// </summary>
        /// <value>The order of the current matrix, i.e. its height and width.</value>
        public int Order
        {
            get
            {
                if (this.matrix is null)
                {
                    throw new InvalidOperationException("Null value of the inner matrix field.");
                }

                return this.matrix.GetLength(0);
            }
        }

        /// <summary>
        /// Gets and sets a matrix value by the specified index.
        /// </summary>
        /// <param name="i">Vertical position of the matrix.</param>
        /// <param name="j">Horizontal position of the matrix.</param>
        /// <returns>Value that is stored at the specified index.</returns>
        public virtual T this[int i, int j]
        {
            get => this.GetValue(i, j);

            set
            {
                var e = new ElementChangedEventArgs<T>(this.GetValue(i, j), value, i, j);

                this.SetValue(value, i, j);

                this.OnElementChanged(e);
            }
        }

        /// <summary>
        /// Sums values of the current matrix with values of the provided matrix.
        /// </summary>
        /// <param name="matrix">Matrix to be added.</param>
        /// <param name="adder">Method which sums values of the matrices.</param>
        /// <returns>New matrix which is the sum of the current one and the provided one.</returns>
        public SquareMatrix<T> AddMatrix(SquareMatrix<T> matrix, Func<T, T, T> adder)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (adder is null)
            {
                throw new ArgumentNullException(nameof(adder));
            }

            int len = this.Order;

            if (matrix.Order != len)
            {
                throw new ArgumentException("Different size of matrices.");
            }

            var result = new SquareMatrix<T>(len);

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    result[i, j] = adder(this[i, j], matrix[i, j]);
                }
            }

            return result;
        }

        private void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            this.ElementChanged?.Invoke(this, e);
        }

        private T GetValue(int i, int j)
        {
            int len = this.matrix.GetLength(0);
            string msg = $"Index is out of range (0 - {len - 1}).";

            if (i < 0 || i >= len)
            {
                throw new ArgumentOutOfRangeException(nameof(i), msg);
            }

            if (j < 0 || j >= len)
            {
                throw new ArgumentOutOfRangeException(nameof(j), msg);
            }

            return this.matrix[i, j];
        }

        private void SetValue(T value, int i, int j)
        {
            int len = this.matrix.GetLength(0);
            string msg = $"Index is out of range (0 - {len - 1}).";

            if (i < 0 || i >= len)
            {
                throw new ArgumentOutOfRangeException(nameof(i), msg);
            }

            if (j < 0 || j >= len)
            {
                throw new ArgumentOutOfRangeException(nameof(j), msg);
            }

            this.matrix[i, j] = value;
        }
    }
}
