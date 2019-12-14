using System;

namespace NET.W2019.Shevchenko13.MatrixTask
{
    /// <summary>
    /// Represents generic diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Type of the matrix values.</typeparam>
    public class DiagonalMatrix<T> : SymmetricMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="order">Height and width of the matrix.</param>
        public DiagonalMatrix(int order)
            : base(order)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// Wraps the provided array without cloning it.
        /// </summary>
        /// <param name="matrix">A predefined array that can be represented as <see cref="DiagonalMatrix{T}"/> type.</param>
        public DiagonalMatrix(T[,] matrix)
            : base(matrix)
        {
            if (!this.IsDiagonal(matrix))
            {
                throw new ArgumentException("The matrix must be diagonal.");
            }
        }

        /// <inheritdoc/>
        public override T this[int i, int j]
        {
            get => base[i, j];

            set
            {
                if (i == j)
                {
                    base[i, j] = value;
                }
                else
                {
                    base[i, j] = default;
                    base[j, i] = default;
                }
            }
        }

        private bool IsDiagonal(T[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!matrix[i, j].Equals(default(T))
                        || !matrix[j, i].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
