using Sort;
using System;

namespace Task1.Sorts
{
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
                        Swap(ref sortedArray[j], ref sortedArray[j + 1]);
                    }
                }
            }

            stopwatch.Stop();
            return new SortingResult { TimeElapsed = stopwatch.ElapsedMilliseconds, SortedArray = sortedArray };
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
