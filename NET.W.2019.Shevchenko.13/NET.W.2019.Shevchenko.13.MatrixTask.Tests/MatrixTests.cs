using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W2019.Shevchenko13.MatrixTask.Tests
{
    [TestClass]
    public class MatrixTests
    {
        readonly int[,] notSquareArray = new int[,]
        {
            {1, 3, 5, 7, 8, 1 },
            {2, 4, 6, 8, 5, 5 },
            {9, 8, 7, 6, 3, 2 },
        };

        readonly int[,] squareArray = new int[,]
        {
            {1, 3, 5, 7 },
            {2, 4, 6, 8 },
            {9, 8, 7, 6 },
            {5, 4, 3, 2 }
        };

        readonly int[,] symmetricArray = new int[,]
        {
            {1, 3, 5, 7 },
            {3, 8, 2, 4 },
            {5, 2, 7, 6 },
            {7, 4, 6, 3 }
        };

        readonly int[,] diagonalArray = new int[,]
        {
            {1, 0, 0, 0 },
            {0, 8, 0, 0 },
            {0, 0, 7, 0 },
            {0, 0, 0, 3 }
        };

        readonly int iIndex = 1;
        readonly int jIndex = 2;
        readonly int oldValue = 6;
        readonly int newValue = 7;

        bool eventOk = false;

        public void ShowMatrix<T>(SquareMatrix<T> matrix)
        {
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        public void Matrix_IntElementChanged(object sender, ElementChangedEventArgs<int> e)
        {
            if (this.iIndex == e.I
                && this.jIndex == e.J
                && this.oldValue == e.OldValue
                && this.newValue == e.NewValue)
            {
                this.eventOk = true;
            }
        }

        [TestMethod]
        public void Matrix_CheckEvent()
        {
            var matrix = new SquareMatrix<int>(this.squareArray);
            matrix.ElementChanged += this.Matrix_IntElementChanged;
            matrix[1, 2] += 1;

            if (!this.eventOk)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Matrix_SumMatrices()
        {
            var expected = new SquareMatrix<int>(new int[,]
            {
                { 2, 6, 10, 14 },
                { 5, 12, 8, 12 },
                { 14, 10, 14, 12 },
                { 12, 8, 9, 5 }
            });

            var actual = new SquareMatrix<int>(this.squareArray)
                .AddMatrix(new SymmetricMatrix<int>(this.symmetricArray), (x, y) => x + y);

            for (int i = 0; i < actual.Order; i++)
            {
                for (int j = 0; j < actual.Order; j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void MatrixTest_AddOneSquare()
        {
            var input = new int[,]
            {
                {1, 3, 5, 7 },
                {2, 4, 6, 8 },
                {9, 8, 7, 6 },
                {5, 4, 3, 2 }
            };

            var actual = new SquareMatrix<int>(input);

            for (int i = 0; i < actual.Order; i++)
            {
                for (int j = 0; j < actual.Order; j++)
                {
                    actual[i, j] += 1;
                }
            }

            var expected = new int[,]
            {
                {2, 4, 6, 8 },
                {3, 5, 7, 9 },
                {10, 9, 8, 7 },
                {6, 5, 4, 3 }
            };

            for (int i = 0; i < actual.Order; i++)
            {
                for (int j = 0; j < actual.Order; j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void MatrixTest_AddOneSymmetric()
        {
            var input = new int[,]
            {
                {1, 3, 5, 7 },
                {3, 8, 2, 4 },
                {5, 2, 7, 6 },
                {7, 4, 6, 3 }
            };

            var actual = new SymmetricMatrix<int>(input);

            actual[0, 2] += 1;
            actual[2, 1] += 1;

            var expected = new int[,]
            {
                {1, 3, 6, 7 },
                {3, 8, 3, 4 },
                {6, 3, 7, 6 },
                {7, 4, 6, 3 }
            };

            for (int i = 0; i < actual.Order; i++)
            {
                for (int j = 0; j < actual.Order; j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void MatrixTest_AddOneDiagonal()
        {
            var input = new int[,]
            {
                {1, 0, 0, 0 },
                {0, 8, 0, 0 },
                {0, 0, 7, 0 },
                {0, 0, 0, 3 }
            };

            var actual = new DiagonalMatrix<int>(input);

            actual[0, 2] += 1;
            actual[2, 1] += 1;
            actual[2, 2] += 1;

            var expected = new int[,]
            {
                {1, 0, 0, 0 },
                {0, 8, 0, 0 },
                {0, 0, 8, 0 },
                {0, 0, 0, 3 }
            };

            for (int i = 0; i < actual.Order; i++)
            {
                for (int j = 0; j < actual.Order; j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void MatrixTest_CreateSquare()
        {
            var matrix = new SquareMatrix<int>(this.squareArray);
            this.ShowMatrix(matrix);
        }

        [TestMethod]
        public void MatrixTest_CreateSymmetric()
        {
            var matrix = new SymmetricMatrix<int>(this.symmetricArray);
            this.ShowMatrix(matrix);
        }

        [TestMethod]
        public void MatrixTest_CreateDiagonal()
        {
            var matrix = new DiagonalMatrix<int>(this.diagonalArray);
            this.ShowMatrix(matrix);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void MatrixTest_CreateSquare_Exception()
        {
            try
            {
                new SquareMatrix<int>(this.notSquareArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void MatrixTest_CreateSymmetric_Exception()
        {
            try
            {
                new SymmetricMatrix<int>(this.squareArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void MatrixTest_CreateDiagonal_Exception()
        {
            try
            {
                new DiagonalMatrix<int>(this.symmetricArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void MatrixTest_Set_Exception()
        {
            try
            {
                var m = new DiagonalMatrix<int>(this.diagonalArray);
                m[-2, 18] = 5;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void MatrixTest_Get_Exception()
        {
            try
            {
                var m = new SymmetricMatrix<int>(this.symmetricArray);
                int x = m[2, 124];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
