using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace NET.W2019.Shevchenko06
{
    /// <summary>
    /// EPAM training, winter 2019.
    /// Day 6 homework.
    /// Task 1.
    /// Yuri Shevchenko.
    /// </summary>
    public sealed class Polynomial
    {
        private readonly double[] coefficients;

        private Polynomial(double[] coeff)
        {
            this.coefficients = coeff;
            this.Degree = coeff.Length - 1;
        }

        /// <summary>
        /// Gets the degree of the polynomial.
        /// </summary>
        /// <value>
        /// The degree of the polynomial.
        /// </value>
        public int Degree { get; }

        /// <summary>
        /// Gets a coefficient of a certain degree.
        /// </summary>
        /// <param name="index">The degree of a coefficient.</param>
        /// <returns>A coefficient.</returns>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= this.coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException($"Index {index} is out of range (0 - {this.coefficients.Length - 1}).");
                }

                return this.coefficients[index];
            }
        }

        public static bool operator ==(Polynomial a, Polynomial b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            if (ReferenceEquals(a, b))
            {
                return true;
            }

            return a.GetCoefficients().SequenceEqual(b.GetCoefficients());
        }

        public static bool operator !=(Polynomial a, Polynomial b)
        {
            return !(a == b);
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            if (a is null || b is null)
            {
                return null;
            }

            return Add(a, b);
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            if (a is null || b is null)
            {
                return null;
            }

            return Subtract(a, b);
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            if (a is null || b is null)
            {
                return null;
            }

            return Multiply(a, b);
        }

        /// <summary>
        /// Adds two polynomials.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>New polynomial, the sum of the operands.</returns>
        public static Polynomial Add(Polynomial left, Polynomial right)
        {
            if (left is null || right is null)
            {
                return null;
            }

            double[] longer;
            double[] shorter;

            if (left.Degree >= right.Degree)
            {
                longer = left.GetCoefficients();
                shorter = right.GetCoefficients();
            }
            else
            {
                longer = right.GetCoefficients();
                shorter = left.GetCoefficients();
            }

            for (int i = 0; i < shorter.Length; i++)
            {
                longer[i] += shorter[i];
            }

            return new Polynomial(longer);
        }

        /// <summary>
        /// Subtracts one polynomial from another.
        /// </summary>
        /// <param name="left">Polynomial to subrtact from.</param>
        /// <param name="right">Polynomial to subtract.</param>
        /// <returns>New polynomial, the difference between the operands.</returns>
        public static Polynomial Subtract(Polynomial left, Polynomial right)
        {
            if (left is null || right is null)
            {
                return null;
            }

            double[] inverse = right.GetCoefficients();

            for (int i = 0; i < inverse.Length; i++)
            {
                inverse[i] *= -1;
            }

            return left + new Polynomial(inverse);
        }

        /// <summary>
        /// Multiplies two polynomials.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>New polynomial, the product of the operands.</returns>
        public static Polynomial Multiply(Polynomial left, Polynomial right)
        {
            if (left is null || right is null)
            {
                return null;
            }

            double[] result = new double[left.Degree + right.Degree + 1];

            for (int i = 0; i <= left.Degree; i++)
            {
                for (int j = 0; j <= right.Degree; j++)
                {
                    result[i + j] += left[i] * right[j];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Creates an instance with data parsed from a formatted string.
        /// Format: "ax^pow bx^pow cx^pow ...".
        /// </summary>
        /// <param name="format">Formatted string representation of a polynomial.</param>
        /// <returns>A polynomial instance.</returns>
        public static Polynomial Create(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                return null;
            }

            double[] coeff;

            try
            {
                coeff = TryParsePolynomial(format);
            }
            catch (ArgumentException)
            {
                return null;
            }

            return new Polynomial(coeff);
        }

        /// <summary>
        /// Calculates the actual sum of the current monomials using the given value.
        /// </summary>
        /// <param name="x">The given value.</param>
        /// <returns>The actual sum.</returns>
        public double CalculateSum(double x)
        {
            double sum = 0;

            for (int i = 0; i < this.coefficients.Length; i++)
            {
                sum += this.coefficients[i] * Math.Pow(x, i);
            }

            return sum;
        }

        /// <summary>
        /// Gets coefficients of the current polynomial.
        /// </summary>
        /// <returns>A new double darray of the polynomial's coefficients.</returns>
        public double[] GetCoefficients()
        {
            return this.coefficients.ToArray();
        }

        /// <summary>
        /// Overrides the standard Equals() method of the Object class.
        /// </summary>
        /// <param name="polynomial">A polynomial instance.</param>
        /// <returns>Whether coefficients of two given polynomials are equal.</returns>
        public override bool Equals(object polynomial)
        {
            if (polynomial is null || !(polynomial is Polynomial))
            {
                return false;
            }

            return this.GetCoefficients().SequenceEqual((polynomial as Polynomial).GetCoefficients());
        }

        /// <summary>
        /// Overrides the standard GetHashCode() method of the Object class.
        /// </summary>
        /// <returns>The hashcode of the coefficients array of the current polynomial.</returns>
        public override int GetHashCode()
        {
            return this.coefficients.GetHashCode();
        }

        /// <summary>
        /// Overrides standard ToString() method of the Object class.
        /// </summary>
        /// <returns>A string representation of the polynomial.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = this.coefficients.Length - 1; i >= 0; i--)
            {
                if (this.coefficients[i] != 0)
                {
                    if (i < this.coefficients.Length - 1)
                    {
                        sb.Append(' ');
                    }

                    if (this.coefficients[i] == -1)
                    {
                        sb.Append('-');
                    }
                    else if (this.coefficients[i] != 1)
                    {
                        sb.Append(this.coefficients[i].ToString(CultureInfo.CurrentCulture));
                    }

                    if (i > 0)
                    {
                        sb.Append('x');
                    }

                    if (i > 1)
                    {
                        sb.Append($"^{i}");
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Parses a string representation of a polynomial.
        /// </summary>
        /// <param name="format">Formatted string.</param>
        /// <returns>An array of coefficients of the polynomial.</returns>
        private static double[] TryParsePolynomial(string format)
        {
            var monomials = new List<double[]>();
            var stringMonomials = format.Split(' ');
            int maxLength = 0;

            foreach (string s in stringMonomials)
            {
                double[] m;

                try
                {
                    m = TryParseMonomial(s);
                }
                catch
                {
                    throw;
                }

                monomials.Add(m);

                if (m.Length > maxLength)
                {
                    maxLength = m.Length;
                }
            }

            double[] totalCoeffs = new double[maxLength];

            foreach (var m in monomials)
            {
                for (int i = 0; i < m.Length; i++)
                {
                    totalCoeffs[i] += m[i];
                }
            }

            return totalCoeffs;
        }

        private static double[] TryParseMonomial(string format)
        {
            if (!format.Contains("x") && !format.Contains("^"))
            {
                if (double.TryParse(format, NumberStyles.Float, CultureInfo.CurrentCulture, out double number))
                {
                    return new double[] { number };
                }
            }

            if (format.Contains("x") && !format.Contains("^"))
            {
                var coeff = new StringBuilder();

                foreach (char c in format)
                {
                    if (c != 'x')
                    {
                        coeff.Append(c);
                    }
                    else
                    {
                        break;
                    }
                }

                if (coeff.Length == 0)
                {
                    return new double[] { 0, 1 };
                }

                if (coeff.Length == 1 && coeff[0] == '-')
                {
                    return new double[] { 0, -1 };
                }

                if (double.TryParse(coeff.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out double number))
                {
                    return new double[] { 0, number };
                }
            }

            if (format.Contains("x^"))
            {
                var power = new StringBuilder();
                var coeff = new StringBuilder();

                bool parsingPower = false;

                foreach (char c in format)
                {
                    if (c == 'x')
                    {
                        continue;
                    }

                    if (c == '^')
                    {
                        parsingPower = true;
                        continue;
                    }

                    if (parsingPower)
                    {
                        power.Append(c);
                    }
                    else
                    {
                        coeff.Append(c);
                    }
                }

                if (coeff.Length == 0 || (coeff.Length == 1 && coeff[0] == '-'))
                {
                    coeff.Append('1');
                }

                if (int.TryParse(power.ToString(), out int lengthMinusOneAndPower))
                {
                    if (double.TryParse(coeff.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out double number))
                    {
                        if (lengthMinusOneAndPower < 0)
                        {
                            throw new ArgumentException($"Negative power of a monomial: {format}");
                        }

                        if (lengthMinusOneAndPower == 0)
                        {
                            return new double[] { number };
                        }

                        if (number == 0)
                        {
                            lengthMinusOneAndPower--;
                        }

                        double[] arr = new double[lengthMinusOneAndPower + 1];
                        arr[lengthMinusOneAndPower] = number;
                        return arr;
                    }
                }
            }

            throw new ArgumentException($"Failed to parse a monomial: {format}");
        }
    }
}
