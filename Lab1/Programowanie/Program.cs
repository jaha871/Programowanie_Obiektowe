using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 11, 2, 5, 6, 7, 45, 23, 1, 7 };
            Console.WriteLine(findIndex(arr, -5));
        }
        static int findIndex(int[] arr, int k)
        {
            int index = -1;
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i] && arr[i] > 10)
                {
                    min = arr[i];
                    index = i;
                }
            }
            return index;
        }
    }
}