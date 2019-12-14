using System;

namespace NET.W2019.Shevchenko13.MatrixTask
{
    /// <summary>
    /// Represents generic symmetric matrix.
    /// </summary>
    /// <typeparam name="T">Type of the matrix values.</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="order">Height and width of the matrix.</param>
        public SymmetricMatrix(int order)
            : base(order)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// Wraps the provided array without cloning it.
        /// </summary>
        /// <param name="matrix">A predefined array that can be represented as <see cref="SymmetricMatrix{T}"/> type.</param>
        public SymmetricMatrix(T[,] matrix)
            : base(matrix)
        {
            if (!this.IsSymmetric(matrix))
            {
                throw new ArgumentException("The matrix must be symmetric.");
            }
        }

        /// <inheritdoc/>
        public override T this[int i, int j]
        {
            get => base[i, j];

            set
            {
                base[i, j] = value;

                if (i != j)
                {
                    base[j, i] = value;
                }
            }
        }

        private bool IsSymmetric(T[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!matrix[i, j].Equals(matrix[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
