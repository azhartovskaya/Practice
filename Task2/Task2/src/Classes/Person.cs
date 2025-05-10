using System;

namespace Task2.Classes
{
    public abstract class Person
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        protected Person(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Имя: {Name}, Дата рождения: {DateOfBirth.ToShortDateString()}");
        }
    }
}
