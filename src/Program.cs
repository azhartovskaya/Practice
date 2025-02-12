using System;
using Task2.Classes;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Author author1 = new Author("Китами Масао", new DateTime(1959, 1, 31), "Писатель, автор книги «Самурай без меча».");

            Book book1 = new Book("Самурай без меча", author1, 2005);

            Library library = new Library();

            library.AddBook(book1);

            Reader reader1 = new Reader("Иван Иванов", new DateTime(1990, 5, 15));

            library.AddReader(reader1);

            try
            {
                var loansToReturn = new List<Loan>(reader1.Loans);

                foreach (var loan in loansToReturn)
                {
                    library.ReturnBook(loan);
                    Console.WriteLine($"Книга '{loan.Book.Title}' была возвращена {reader1.Name}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"При обработке произошла ошибка: {ex.Message}");
            }

        }
    }
}
