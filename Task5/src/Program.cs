using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Program
{
    private static List<DeviceData> deviceDataList = new List<DeviceData>();
    private static string configFilePath = "config.json"; // Путь к конфигурации
    private static string dataDirectory = "Tas5/src"; // Путь к директории с CSV файлами

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Прочитать конфигурацию");
            Console.WriteLine("2. Вывести конфигурацию на экран");
            Console.WriteLine("3. Прочитать файл с данными");
            Console.WriteLine("4. Вывести строки данных (с N до M)");
            Console.WriteLine("0. Выход");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ReadConfiguration();
                    break;
                case "2":
                    PrintConfiguration();
                    break;
                case "3":
                    ReadDataFiles();
                    break;
                case "4":
                    PrintDataLines();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный ввод, попробуйте еще раз.");
                    break;
            }
        }
    }

    private static void ReadConfiguration()
    {
        if (File.Exists(configFilePath))
        {
            var json = File.ReadAllText(configFilePath);
            deviceDataList = JsonSerializer.Deserialize<List<DeviceData>>(json);
            Console.WriteLine("Конфигурация успешно прочитана.");
        }
        else
        {
            Console.WriteLine("Файл конфигурации не найден.");
        }
    }

    private static void PrintConfiguration()
    {
        foreach (var device in deviceDataList)
        {
            Console.WriteLine($"Устройство: {device.Name}");
            foreach (var dataItem in device.Data)
            {
                Console.WriteLine($"  Переменная: {dataItem.Variable}, Формат: {dataItem.Format}, Единица: {dataItem.Unit}");
            }
        }
    }

    private static void ReadDataFiles()
    {
        string dataDirectory = "C:\\Users\\Админ\\Desktop\\practice\\Task5\\src\\bin\\Debug\\net8.0";

        string[] csvFiles;
        try
        {
            csvFiles = Directory.GetFiles(dataDirectory, "*.csv");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при попытке получить файлы из директории: {ex.Message}");
            return;
        }

        if (csvFiles.Length == 0)
        {
            Console.WriteLine("CSV файлы не найдены в директории.");
            return;
        }

        Console.WriteLine("Выберите файл для чтения:");
        for (int i = 0; i < csvFiles.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(csvFiles[i])}");
        }

        if (int.TryParse(Console.ReadLine(), out int fileChoice) && fileChoice > 0 && fileChoice <= csvFiles.Length)
        {
            var selectedFile = csvFiles[fileChoice - 1];
            try
            {
                var lines = File.ReadAllLines(selectedFile);
                foreach (var line in lines.Skip(1)) // пропускаем заголовок
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор файла.");
        }
    }


    private static void PrintDataLines()
    {
        Console.WriteLine("Введите N и M (через пробел):");
        var input = Console.ReadLine().Split(' ');
        if (input.Length == 2 && int.TryParse(input[0], out int n) && int.TryParse(input[1], out int m))
        {
            // В данной реализации просто выводим сообщение
            Console.WriteLine($"Вывод строк с {n} до {m} (логика не реализована).");
        }
        else
        {
            Console.WriteLine("Неверный ввод N и M.");
        }
    }

    private static void InterpretData(string[] lines)
    {
        // Пример обработки данных:

        foreach (var line in lines.Skip(1)) // пропускаем заголовок
        {
            var values = line.Split(',');
            // Логика интерпретации данных на основе конфигурации
        }
    }

    private static void ExportToExcel(List<DeviceData> dataList)
    {
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Данные");

            // Заполнение заголовков
            worksheet.Cells[1, 1].Value = "Имя устройства";
            worksheet.Cells[1, 2].Value = "Переменная";
            worksheet.Cells[1, 3].Value = "Формат";
            worksheet.Cells[1, 4].Value = "Единица измерения";

            int row = 2; // Начинаем со второй строки

            // Заполнение данных
            foreach (var device in dataList)
            {
                foreach (var dataItem in device.Data)
                {
                    worksheet.Cells[row, 1].Value = device.Name;
                    worksheet.Cells[row, 2].Value = device.Data;
                    row++;
                }
            }

            var filePath = "ExportedData.xlsx";
            FileInfo fi = new FileInfo(filePath);
            package.SaveAs(fi);

            Console.WriteLine($"Данные успешно экспортированы в {filePath}");
        }
    }

}
