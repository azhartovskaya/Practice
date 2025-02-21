using System;
using Task1.Sorts;

namespace Sort
{
    public class SortingResult
    {
        public int[] SortedArray { get; set; }
        public long TimeElapsed { get; set; }
    }

    public abstract class SortingAlgorithm
    {
        public abstract SortingResult Sort(int[] array);
    }

    class Program
    {

        

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов для сортировки:");

            if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
            {
                Console.WriteLine("Некорректный ввод. Программа завершена.");
                return;
            }

            Random random = new Random();
            int[] dataToSort = new int[size];

            for (int i = 0; i < size; i++)
            {
                dataToSort[i] = random.Next(10000); // Генерация случайных чисел от 0 до 9999
            }

            var algorithms = new SortingAlgorithm[]
            {
                new BubbleSort(),
                new InsertionSort(),
                new QuickSort(),
                new MergeSort()
            };

            foreach (var algorithm in algorithms)
            {
                var result = algorithm.Sort(dataToSort);

                Console.WriteLine($"{algorithm.GetType().Name}: {result.TimeElapsed} ms");

                // Проверка на правильность сортировки
                if (!IsSorted(result.SortedArray))
                    Console.WriteLine("Ошибка: массив не отсортирован.");
            }
        }

        static bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                    return false;
            }
            return true;
        }
    }
}
