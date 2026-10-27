using System.Numerics;

namespace FibonacciApp;

/// <summary>
/// Provides an iterative implementation of the Fibonacci sequence.
/// </summary>
public static class FibonacciCalculator
{
    /// <summary>
    /// Computes the n-th Fibonacci number using the 0-based convention:
    /// F(0) = 0, F(1) = 1, F(n) = F(n-1) + F(n-2) for n >= 2.
    /// </summary>
    /// <remarks>
    /// The algorithm is iterative (non-recursive), so it runs in O(n) time
    /// and O(1) extra memory, avoiding both the exponential time and the
    /// stack overflow of a naive recursive implementation. The result is
    /// returned as <see cref="BigInteger"/> for arbitrary precision, so it
    /// never overflows for large n.
    /// </remarks>
    /// <param name="n">The 0-based index of the Fibonacci number. Must be >= 0.</param>
    /// <returns>The n-th Fibonacci number.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="n"/> is negative.
    /// </exception>
    public static BigInteger Fibonacci(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException(
                $"n must be non-negative, but was {n}.", nameof(n));
        }

        if (n == 0)
        {
            return BigInteger.Zero;
        }

        if (n == 1)
        {
            return BigInteger.One;
        }

        BigInteger previous = BigInteger.Zero; // F(0)
        BigInteger current = BigInteger.One;   // F(1)

        for (int i = 2; i <= n; i++)
        {
            BigInteger next = previous + current;
            previous = current;
            current = next;
        }

        return current;
    }
}
