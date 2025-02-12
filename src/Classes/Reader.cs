using System;
using System.Collections.Generic;

namespace Task2.Classes
{
    public class Reader : Person
    {
        public List<Loan> Loans { get; private set; }

        public Reader(string name, DateTime dateOfBirth) : base(name, dateOfBirth)
        {
            Loans = new List<Loan>();
        }

        public void AddLoan(Loan loan)
        {
            Loans.Add(loan);
        }
    }
}
