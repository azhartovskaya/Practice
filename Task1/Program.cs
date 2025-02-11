using System;

class Program
{
    public abstract class SortingAlgorithm
    {
        public abstract SortingResult Sort(int[] array);
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
                        // Swap
                        int temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;
                    }
                }
            }

            stopwatch.Stop();
            return new SortingResult(stopwatch.ElapsedMilliseconds, sortedArray);
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
            return new SortingResult(stopwatch.ElapsedMilliseconds, sortedArray);
        }
    }

    public class QuickSort : SortingAlgorithm
    {
        public override SortingResult Sort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            QuickSortMethod(sortedArray, 0, sortedArray.Length - 1);

            stopwatch.Stop();
            return new SortingResult(stopwatch.ElapsedMilliseconds, sortedArray);
        }

        private void QuickSortMethod(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);
                QuickSortMethod(array, low, pi - 1);
                QuickSortMethod(array, pi + 1, high);
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

            MergeSortMethod(sortedArray, 0, sortedArray.Length - 1);

            stopwatch.Stop();
            return new SortingResult(stopwatch.ElapsedMilliseconds, sortedArray);
        }

        private void MergeSortMethod(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeSortMethod(array, left, middle);
                MergeSortMethod(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        private void Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(array, left, L, 0, n1);
            Array.Copy(array, middle + 1, R, 0, n2);

            int i = 0;
            int j = 0;
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

    public struct SortingResult
    {
        public long ExecutionTime { get; }
        public int[] SortedArray { get; }

        public SortingResult(long executionTime, int[] sortedArray)
        {
            ExecutionTime = executionTime;
            SortedArray = sortedArray;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество элементов для сортировки:");

        if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
        {
            Console.WriteLine("Некорректный ввод. Завершение программы.");
            return;
        }

        Random random = new Random();

        int[] dataSet = new int[size];

        for (int i = 0; i < size; i++)
        {
            dataSet[i] = random.Next(0, 10000);
        }

        CompareSortingAlgorithms(dataSet);
    }

    static void CompareSortingAlgorithms(int[] dataSet)
    {
        SortingAlgorithm[] algorithms = new SortingAlgorithm[]
        {
            new BubbleSort(),
            new InsertionSort(),
            new QuickSort(),
            new MergeSort()
        };

        foreach (var algorithm in algorithms)
        {
            var result = algorithm.Sort(dataSet);
            Console.WriteLine($"{algorithm.GetType().Name}: {result.ExecutionTime} ms");

            if (!IsSorted(result.SortedArray))
            {
                Console.WriteLine($"{algorithm.GetType().Name} не отсортировал массив корректно!");
            }
        }
    }

    static bool IsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1] > array[i]) return false;
        }

        return true;
    }
}