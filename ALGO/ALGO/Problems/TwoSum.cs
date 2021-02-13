using ALGO.Helper;
using System;
using System.Collections.Generic;

namespace ALGO.Problems
{
    // Problem: https://gyazo.com/ce3f2ca04948bdb8bda8e0bb278c6e97
    public class TwoSum : IProblem
    {
        private int[] TestArray;
        private int Target;

        public TwoSum()
        {
            TestArray = new int[] { 3, 5, -4, 8, 11, 1, -1, 6 };
            Target = 10;
        }

        public void Run()
        {
            Console.WriteLine($"Hashtable: {String.Join(",", HashtableMethod(TestArray, Target))}");
            Console.WriteLine($"Brute Force: {String.Join(", ", BruteForceMethod(TestArray, Target))}");
            Console.WriteLine($"Pointers: {String.Join(",", PointersMethod(TestArray, Target))}");
        }

        private int[] BruteForceMethod(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] + array[j] == target && i != j)
                    {
                        return new int[] { array[i], array[j] };
                    }
                }
            }

            return new int[0];
        }

        private int[] HashtableMethod(int[] array, int target)
        {
            Dictionary<int, bool> dictionary = new Dictionary<int, bool>();

            for (int i = 0; i < array.Length; i++)
            {
                int requiredNum = target - array[i];

                if (!dictionary.ContainsKey(requiredNum))
                {
                    dictionary.Add(array[i], true);
                }
                else
                {
                    return new int[] { array[i], requiredNum };
                }
            }

            return new int[0];
        }

        private int[] PointersMethod(int[] array, int target)
        {
            array = SortHelper.QuickSort(array, 0, array.Length);

            int leftPointer = 0;
            int rightPointer = array.Length - 1;

            while (leftPointer <= rightPointer)
            {
                if (array[leftPointer] + array[rightPointer] == target)
                {
                    return new int[] { array[leftPointer], array[rightPointer] };
                }
                else if (array[leftPointer] + array[rightPointer] < target)
                {
                    leftPointer++;
                }
                else
                {
                    rightPointer--;
                }
            }

            return new int[0];
        }
    }
}
