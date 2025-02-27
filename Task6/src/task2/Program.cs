using System;
using System.Threading;

namespace Task6.Solution;

class Program
{
    private static int counter = 0;
    private static readonly object lockObject = new object();

    static void Main()
    {
        Thread thread1 = new Thread(IncrementCounter);
        Thread thread2 = new Thread(IncrementCounter);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine($"Конечный счетчик: {counter}");
    }

    static void IncrementCounter()
    {
        for (int i = 0; i < 1000; i++)
        {
            lock (lockObject) // Синхронизация доступа к счетчику
            {
                counter++;
            }
        }
    }
}
