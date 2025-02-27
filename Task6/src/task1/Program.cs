using System;
using System.Threading;

namespace Task6.Solution;

class Program
{
    static void Main()
    {
        Thread thread1 = new Thread(() => PrintThreadInfo("Поток 1"));
        Thread thread2 = new Thread(() => PrintThreadInfo("Поток 2"));
        Thread thread3 = new Thread(() => PrintThreadInfo("Поток 3"));

        thread1.Start();
        thread2.Start();
        thread3.Start();

        // Присоединяем потоки к основному
        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("Все потоки завершены.");
    }

    static void PrintThreadInfo(string threadName)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{threadName} - итерация {i}");
            Thread.Sleep(500); // пауза 500 мс
        }
    }
}
