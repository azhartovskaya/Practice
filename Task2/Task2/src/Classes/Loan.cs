using System;

namespace Task2.Classes
{
    public class Loan
    {
        public Reader Reader { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime DueDate { get; private set; }

        public Loan(Reader reader, Book book)
        {
            Reader = reader;
            Book = book;
            LoanDate = DateTime.Now;
            DueDate = LoanDate.AddDays(14);
        }
    }
}
