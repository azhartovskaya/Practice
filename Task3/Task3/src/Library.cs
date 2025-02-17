using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

public static class Library
{
    private static List<Book> Books = new List<Book>();
    private const string FilePath = "books.json";

    public static void ReadFile()
    {
        try
        {
            string jsonData = File.ReadAllText(FilePath);

            if (string.IsNullOrWhiteSpace(jsonData))
            {
                Console.WriteLine("‘айл пустой или содержит некорректные данные.");
                return;
            }

            Books = JsonSerializer.Deserialize<List<Book>>(jsonData) ?? new List<Book>();
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine($"ќшибка десериализации JSON: {jsonEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ќбща€ ошибка: {ex.Message}");
        }
    }

    public static void WriteFile()
    {
        var jsonData = JsonSerializer.Serialize(Books);
        File.WriteAllText(FilePath, jsonData);
    }

    public static void AddBook()
    {
        Console.Write("¬ведите автора: ");
        string author = Console.ReadLine();

        Console.Write("¬ведите название книги: ");
        string title = Console.ReadLine();

        Console.Write("¬ведите ISBN: ");
        string isbn = Console.ReadLine();

        Console.Write("¬ведите год публикации: ");
        string year = Console.ReadLine();

        Books.Add(new Book(author, title, isbn, year));
    }

    public static void RemoveBook()
    {
        PrintBooks();

        Console.Write("¬ведите ISBN книги дл€ удалени€: ");
        string isbn = Console.ReadLine();

        var bookToRemove = Books.FirstOrDefault(b => b.ISBN == isbn);

        if (bookToRemove != null)
        {
            Books.Remove(bookToRemove);
            Console.WriteLine(" нига удалена.");
        }
        else
        {
            Console.WriteLine(" нига с таким ISBN не найдена.");
        }
    }

    public static void PrintBooks()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("Ќет книг в библиотеке.");
            return;
        }

        foreach (var book in Books)
        {
            Console.WriteLine(book);
        }
    }

    public static void UpdateBook()
    {
        PrintBooks();
        Console.Write("¬ведите ISBN книги дл€ обновлени€: ");
        string isbn = Console.ReadLine();

        var bookToUpdate = Books.FirstOrDefault(b => b.ISBN == isbn);
        if (bookToUpdate != null)
        {
            Console.Write("¬ведите новое им€ автора (оставьте пустым дл€ пропуска): ");
            string newAuthor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthor)) bookToUpdate.Author = newAuthor;

            Console.Write("¬ведите новое название (оставьте пустым дл€ пропуска): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle)) bookToUpdate.Title = newTitle;

            Console.Write("¬ведите новый год публикации (оставьте пустым дл€ пропуска): ");
            string newYear = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newYear)) bookToUpdate.Year = newYear;

            Console.WriteLine("»нформаци€ о книге обновлена.");
        }
        else
        {
            Console.WriteLine(" нига не найдена.");
        }
    }

    public static void PrintBook(string isbn)
    {
        var book = Books.FirstOrDefault(b => b.ISBN == isbn);

        if (book != null)
        {
            Console.WriteLine(book);
        }
        else
        {
            Console.WriteLine(" нига с таким ISBN не найдена.");
        }
    }

}
