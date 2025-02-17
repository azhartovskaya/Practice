using System;

namespace Task4.Classes;
public class Worker
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime DateOfEmployment { get; set; }
    public string Grade { get; set; }

    public Worker(string name, int age, DateTime dateOfEmployment, string grade)
    {
        if (age < 0)
            throw new ArgumentException("Age cannot be negative.");

        Name = name;
        Age = age;
        DateOfEmployment = dateOfEmployment;
        Grade = grade;
    }

    public override string ToString()
    {
        return $"{Name};{Age};{DateOfEmployment.ToShortDateString()};{Grade}";
    }
}
