using System.Collections.Generic;

namespace Task2.Classes
{
    public class Library
    {
        private List<Book> Books { get; set; }
        private List<Reader> Readers { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Readers = new List<Reader>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void AddReader(Reader reader)
        {
            Readers.Add(reader);
        }

        public void LendBook(Reader reader, Book book)
        {
            if (!book.IsAvailable)
                throw new InvalidOperationException(" нига уже вз€та напрокат.");

            var loan = new Loan(reader, book);
            reader.AddLoan(loan);
            book.Lend();
        }

        public void ReturnBook(Loan loan)
        {
            loan.Book.Return();
            loan.Reader.Loans.Remove(loan);
        }
    }
}
