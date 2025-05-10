using System;

namespace Task2.Classes
{
    public class Author : Person
    {
        public string Biography { get; private set; }

        public Author(string name, DateTime dateOfBirth, string biography) : base(name, dateOfBirth)
        {
            Biography = biography;
        }
    }
}
