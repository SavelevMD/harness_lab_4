using System.Numerics;
using FibonacciApp;

namespace FibonacciApp.Tests;

public class FibonacciTests
{
    // ---- Acceptance criteria: correct values for known n ----
    [Theory]
    [InlineData(0, "0")]
    [InlineData(1, "1")]
    [InlineData(2, "1")]
    [InlineData(10, "55")]
    [InlineData(93, "12200160415121876738")]
    public void Fibonacci_ReturnsExpectedValueForKnownIndex(int n, string expected)
    {
        Assert.Equal(BigInteger.Parse(expected), FibonacciCalculator.Fibonacci(n));
    }

    // ---- Acceptance criterion: negative input throws ArgumentException ----
    [Fact]
    public void Fibonacci_NegativeInput_ThrowsArgumentException()
    {
        var ex = Assert.Throws<ArgumentException>(() => FibonacciCalculator.Fibonacci(-1));
        Assert.Equal("n", ex.ParamName);
    }

    [Theory]
    [InlineData(int.MinValue)]
    [InlineData(-100)]
    [InlineData(-2)]
    public void Fibonacci_AnyNegativeInput_ThrowsArgumentException(int n)
    {
        Assert.Throws<ArgumentException>(() => FibonacciCalculator.Fibonacci(n));
    }

    // ---- Acceptance criterion: arbitrary precision, no overflow for large n ----
    [Theory]
    [InlineData(46, "1836311903")]                // exceeds uint.MaxValue (4_294_967_295)
    [InlineData(92, "7540113804746346429")]       // near the ulong.MaxValue boundary
    [InlineData(100, "354224848179261915075")]    // far exceeds ulong.MaxValue
    [InlineData(200, "280571172992510140037611932413038677189525")]
    public void Fibonacci_LargeInput_DoesNotOverflow(int n, string expected)
    {
        Assert.Equal(BigInteger.Parse(expected), FibonacciCalculator.Fibonacci(n));
    }

    // ---- Edge case: sequence start ----
    [Fact]
    public void Fibonacci_FirstTwoTerms_AreZeroAndOne()
    {
        Assert.Equal(BigInteger.Zero, FibonacciCalculator.Fibonacci(0));
        Assert.Equal(BigInteger.One, FibonacciCalculator.Fibonacci(1));
    }
}
