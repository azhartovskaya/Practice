using System;

namespace Sort
{
    public abstract class SortingAlgorithm
    {
        public abstract SortingResult Sort(int[] array);
    }

    public struct SortingResult
    {
        public long TimeElapsed { get; set; }
        public int[] SortedArray { get; set; }
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

    public class BubbleSort : SortingAlgorithm
    {
        public override SortingResult Sort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                for (int j = 0; j < sortedArray.Length - i - 1; j++)
                {
                    if (sortedArray[j] > sortedArray[j + 1])
                    {
                        int temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;
                    }
                }
            }

            stopwatch.Stop();
            return new SortingResult { TimeElapsed = stopwatch.ElapsedMilliseconds, SortedArray = sortedArray };
        }
    }

    public class InsertionSort : SortingAlgorithm
    {
        public override SortingResult Sort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 1; i < sortedArray.Length; i++)
            {
                int key = sortedArray[i];
                int j = i - 1;

                while (j >= 0 && sortedArray[j] > key)
                {
                    sortedArray[j + 1] = sortedArray[j];
                    j--;
                }
                sortedArray[j + 1] = key;
            }

            stopwatch.Stop();
            return new SortingResult { TimeElapsed = stopwatch.ElapsedMilliseconds, SortedArray = sortedArray };
        }
    }

    public class QuickSort : SortingAlgorithm
    {
        public override SortingResult Sort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            QuickSortRecursive(sortedArray, 0, sortedArray.Length - 1);

            stopwatch.Stop();
            return new SortingResult { TimeElapsed = stopwatch.ElapsedMilliseconds, SortedArray = sortedArray };
        }
        private void QuickSortRecursive(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);
                QuickSortRecursive(array, low, pi - 1);
                QuickSortRecursive(array, pi + 1, high);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;

            return i + 1;
        }
    }

    public class MergeSort : SortingAlgorithm
    {
        public override SortingResult Sort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            MergeSortRecursive(sortedArray, 0, sortedArray.Length - 1);

            stopwatch.Stop();
            return new SortingResult { TimeElapsed = stopwatch.ElapsedMilliseconds, SortedArray = sortedArray };
        }

        private void MergeSortRecursive(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                MergeSortRecursive(array, left, mid);
                MergeSortRecursive(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        private void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(array, left, L, 0, n1);
            Array.Copy(array, mid + 1, R, 0, n2);

            int i = 0, j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                array[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = R[j];
                j++;
                k++;
            }
        }
    }
}
