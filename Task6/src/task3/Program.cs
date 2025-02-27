using System;
using System.Threading.Tasks;

namespace Task6.Solution;

class Program
{
    static async Task Main()
    {
        var task1 = Task.Run(() => PerformTask("Задача 1", 2000));
        var task2 = Task.Run(() => PerformTask("Задача 2", 1000));
        var task3 = Task.Run(() => ThrowExceptionTask());

        try
        {
            await Task.WhenAll(task1, task2, task3);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Исключение: {ex.Message}");
        }

        Console.WriteLine("Все задачи завершены.");
    }

    static async Task PerformTask(string name, int delay)
    {
        await Task.Delay(delay);
        Console.WriteLine($"{name} завершена.");
    }

    static async Task ThrowExceptionTask()
    {
        await Task.Delay(1500);
        throw new Exception("Ошибка в задаче 3");
    }
}
