using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Task6.Solution;

class Program
{
    static void Main()
    {
        var results = new ConcurrentDictionary<int, long>();

        Parallel.For(1, 11, i =>
        {
            results[i] = Factorial(i);
            Console.WriteLine($"Факториал {i} = {results[i]}");
        });

        Console.WriteLine("Все вычисления завершены.");
    }

    static long Factorial(int n)
    {
        if (n == 0) return 1;
        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}
