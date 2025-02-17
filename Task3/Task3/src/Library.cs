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
                Console.WriteLine("���� ������ ��� �������� ������������ ������.");
                return;
            }

            Books = JsonSerializer.Deserialize<List<Book>>(jsonData) ?? new List<Book>();
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine($"������ �������������� JSON: {jsonEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"����� ������: {ex.Message}");
        }
    }

    public static void WriteFile()
    {
        var jsonData = JsonSerializer.Serialize(Books);
        File.WriteAllText(FilePath, jsonData);
    }

    public static void AddBook()
    {
        Console.Write("������� ������: ");
        string author = Console.ReadLine();

        Console.Write("������� �������� �����: ");
        string title = Console.ReadLine();

        Console.Write("������� ISBN: ");
        string isbn = Console.ReadLine();

        Console.Write("������� ��� ����������: ");
        string year = Console.ReadLine();

        Books.Add(new Book(author, title, isbn, year));
    }

    public static void RemoveBook()
    {
        PrintBooks();

        Console.Write("������� ISBN ����� ��� ��������: ");
        string isbn = Console.ReadLine();

        var bookToRemove = Books.FirstOrDefault(b => b.ISBN == isbn);

        if (bookToRemove != null)
        {
            Books.Remove(bookToRemove);
            Console.WriteLine("����� �������.");
        }
        else
        {
            Console.WriteLine("����� � ����� ISBN �� �������.");
        }
    }

    public static void PrintBooks()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("��� ���� � ����������.");
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
        Console.Write("������� ISBN ����� ��� ����������: ");
        string isbn = Console.ReadLine();

        var bookToUpdate = Books.FirstOrDefault(b => b.ISBN == isbn);
        if (bookToUpdate != null)
        {
            Console.Write("������� ����� ��� ������ (�������� ������ ��� ��������): ");
            string newAuthor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthor)) bookToUpdate.Author = newAuthor;

            Console.Write("������� ����� �������� (�������� ������ ��� ��������): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle)) bookToUpdate.Title = newTitle;

            Console.Write("������� ����� ��� ���������� (�������� ������ ��� ��������): ");
            string newYear = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newYear)) bookToUpdate.Year = newYear;

            Console.WriteLine("���������� � ����� ���������.");
        }
        else
        {
            Console.WriteLine("����� �� �������.");
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
            Console.WriteLine("����� � ����� ISBN �� �������.");
        }
    }

}
