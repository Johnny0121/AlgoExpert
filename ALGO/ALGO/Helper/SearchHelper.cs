namespace ALGO.Helper
{
    public static class SearchHelper
    {
        public static int BinarySearch(int[] array, int value)
        {
            int leftPointer = 0;
            int rightPointer = array.Length;

            while (leftPointer < rightPointer)
            {
                int midPointer = (leftPointer + rightPointer) / 2;

                if (array[midPointer] == value)
                {
                    return midPointer;
                }
                else if (array[midPointer] > value)
                {
                    rightPointer = midPointer;
                }
                else
                {
                    leftPointer = midPointer + 1;
                }
            }

            return -1;
        }

        public static int BinarySearchRecursive(int[] array, int leftPointer, int rightPointer, int value)
        {
            if (rightPointer >= leftPointer)
            {
                int mid = leftPointer + (rightPointer - leftPointer) / 2;

                if (array[mid] == value)
                {
                    return mid;
                }
                else if (array[mid] > value)
                {
                    return BinarySearchRecursive(array, leftPointer, mid - 1, value);
                }

                return BinarySearchRecursive(array, mid, rightPointer, value);
            }

            return -1;
        }
    }
}
