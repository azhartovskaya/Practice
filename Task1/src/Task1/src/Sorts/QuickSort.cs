using Sort;
using System;

namespace Task1.Sorts
{
    public class QuickSort : SortingAlgorithm
    {
        public override SortingResult Sort(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            PerformQuickSort(sortedArray, 0, sortedArray.Length - 1);

            stopwatch.Stop();
            return new SortingResult { TimeElapsed = stopwatch.ElapsedMilliseconds, SortedArray = sortedArray };
        }

        private void PerformQuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);

                PerformQuickSort(array, low, pi - 1);
                PerformQuickSort(array, pi + 1, high);
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
                    Swap(ref array[i], ref array[j]);
                }
            }
            Swap(ref array[i + 1], ref array[high]);
            return i + 1;
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
