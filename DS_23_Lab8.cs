using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArr = { 6, 3, 5, 7, 4, 2, 1, 8 };
            Console.Write("Original array: ");
            printArr(myArr);
            selectionSort(myArr);

            Console.ReadKey();
        }

        static void selectionSort(int[] arr)
        {
            int min;
            int tur = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                //swap
                int temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;

                tur++;
                Console.Write("Tur " + tur + ": ");
                printArr(arr);
            }
        }

        static void printArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

    }
}
