namespace ALGO.Helper
{
    public static class SortHelper
    {
        public static int[] QuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(array, start, end);
                QuickSort(array, start, pivot);
                QuickSort(array, pivot + 1, end);
            }

            return array;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static int Partition(int[] array, int start, int end)
        {
            int pivotElement = array[start];
            int swapIndex = start;

            for (int i = start + 1; i < end; i++)
            {
                if (array[i] < pivotElement)
                {
                    swapIndex++;
                    Swap(array, i, swapIndex);
                }
            }

            Swap(array, start, swapIndex);
            return swapIndex;
        }
    }
}
