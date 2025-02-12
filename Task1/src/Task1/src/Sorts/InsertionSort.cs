using Sort;
using System;
namespace Task1.Sorts
{
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
}
