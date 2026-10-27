using System.Numerics;
using FibonacciApp;

// Read n from a command-line argument, or prompt the user when no argument is given.
int n;
if (args.Length > 0)
{
    if (!int.TryParse(args[0], out n))
    {
        Console.Error.WriteLine($"Invalid argument '{args[0]}': expected a non-negative integer.");
        return 1;
    }
}
else
{
    Console.Write("Enter n: ");
    string? input = Console.ReadLine();
    if (!int.TryParse(input, out n))
    {
        Console.Error.WriteLine("Invalid input: expected a non-negative integer.");
        return 1;
    }
}

try
{
    BigInteger result = FibonacciCalculator.Fibonacci(n);
    Console.WriteLine($"F({n}) = {result}");
    return 0;
}
catch (ArgumentException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 1;
}
