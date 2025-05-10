using System;
using System.Collections.Generic;
using System.IO;
using Task4.Classes;

class Program
{
    private static List<Worker> workers = new List<Worker>();
    private const string logFilePath = "error_log.txt";

    static void Main(string[] args)
    {
        LoadWorkers();
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить работника");
            Console.WriteLine("2. Редактировать работника");
            Console.WriteLine("3. Удалить работника");
            Console.WriteLine("4. Вывести на экран");
            Console.WriteLine("5. Сохранить в файл");
            Console.WriteLine("6. Чтение из файла");
            Console.WriteLine("0. Выход");

            var choice = Console.ReadLine();
            try
            {
                switch (choice)
                {
                    case "1":
                        AddWorker();
                        break;
                    case "2":
                        EditWorker();
                        break;
                    case "3":
                        RemoveWorker();
                        break;
                    case "4":
                        DisplayWorkers();
                        break;
                    case "5":
                        SaveWorkers();
                        break;
                    case "6":
                        LoadWorkers();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    private static void AddWorker()
    {
        try
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Введите дату приема на работу (дд.мм.гггг): ");
            DateTime dateOfEmployment = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите должность: ");
            string grade = Console.ReadLine();

            workers.Add(new Worker(name, age, dateOfEmployment, grade));
        }
        catch (FormatException)
        {
            throw new FormatException("Некорректный формат ввода.");
        }
        catch (ArgumentException ex)
        {
            throw ex; // Передаем исключение дальше
        }
    }

    private static void EditWorker()
    {
        // Реализация редактирования работника
    }

    private static void RemoveWorker()
    {
        // Реализация удаления работника
    }

    private static void DisplayWorkers()
    {
        foreach (var worker in workers)
        {
            Console.WriteLine(worker);
        }
    }

    private static void SaveWorkers()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("workers.csv"))
            {
                writer.WriteLine("Name;Age;DateOfEmployment;Grade");
                foreach (var worker in workers)
                {
                    writer.WriteLine(worker);
                }
            }
            Console.WriteLine("Данные успешно сохранены.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Ошибка: файл не найден. Пожалуйста, проверьте путь к файлу.");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Ошибка: нет доступа к файлу. Проверьте права доступа.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Ошибка ввода-вывода: " + ex.Message);
        }
    }

    private static void LoadWorkers()
    {
        try
        {
            using (StreamReader reader = new StreamReader("workers.csv"))
            {
                string header = reader.ReadLine(); // Читаем заголовок
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var parts = line.Split(';');
                    if (parts.Length == 4)
                    {
                        string name = parts[0];
                        int age = int.Parse(parts[1]);
                        DateTime dateOfEmployment = DateTime.Parse(parts[2]);
                        string grade = parts[3];

                        workers.Add(new Worker(name, age, dateOfEmployment, grade));
                    }
                }
            }
            Console.WriteLine("Данные успешно загружены.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Ошибка: файл не найден. Пожалуйста, проверьте путь к файлу.");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Ошибка: нет доступа к файлу. Проверьте права доступа.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Ошибка ввода-вывода: " + ex.Message);
        }
    }
}
