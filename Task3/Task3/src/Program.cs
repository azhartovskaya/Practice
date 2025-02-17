using System;

class Program
{
    static void Main(string[] args)
    {
        Library.ReadFile();

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Чтение из файла");
            Console.WriteLine("2. Сохранить в файл");
            Console.WriteLine("3. Добавить книгу");
            Console.WriteLine("4. Отредактировать книгу");
            Console.WriteLine("5. Удалить книгу");
            Console.WriteLine("6. Вывести информацию об одной книге");
            Console.WriteLine("7. Вывести информацию о нескольких книгах");
            Console.WriteLine("8. Выход");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Library.ReadFile();
                    break;
                case "2":
                    Library.WriteFile();
                    break;
                case "3":
                    Library.AddBook();
                    break;
                case "4":
                    Library.UpdateBook();
                    break;
                case "5":
                    Library.RemoveBook();
                    break;
                case "6":
                    Console.Write("Введите ISBN книги: ");
                    string isbnToShow = Console.ReadLine();
                    Library.PrintBook(isbnToShow);
                    break;
                case "7":
                    Library.PrintBooks();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }
}
