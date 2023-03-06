//Вариант 10.
//16,5,15,6,4,7,13,8,12,9,11,10,20,1,19,2,18,3,17,14

using System;

namespace Sortirovka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vstavka();
            Vibor();
            Pusiryok();
            Shell();
        }

        static void Vstavka()
        {
            int[] array = new int[20] { 16, 5, 15, 6, 4, 7, 13, 8, 12, 9, 11, 10, 20, 1, 19, 2, 18, 3, 17, 14 };
            int compares = 0;
            int swaps = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int selectedElement = array[i];
                int indexSelectedElement = i;
                for (int j = i; j > 0; j--)
                {
                    compares++;
                    if (selectedElement > array[indexSelectedElement - 1])
                        break;
                    Swap(ref array[indexSelectedElement - 1], ref array[j]);
                    swaps++;
                    indexSelectedElement = j - 1;
                }
            }
            Console.WriteLine("Результат сортировки прямыми включениями:");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine($"Число сравнений: {compares}");
            Console.WriteLine($"Число перестановок: {swaps}\r\n");
        }

        static void Vibor()
        {
            int[] array = new int[20] { 16, 5, 15, 6, 4, 7, 13, 8, 12, 9, 11, 10, 20, 1, 19, 2, 18, 3, 17, 14 };
            int compares = 0;
            int swaps = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    compares++;
                    if (array[j] < array[minIndex])
                        minIndex = j;
                }
                Swap(ref array[i], ref array[minIndex]);
                swaps++;
            }
            Console.WriteLine("Результат сортировки прямым выбором:");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine($"Число сравнений: {compares}");
            Console.WriteLine($"Число перестановок: {swaps}\r\n");
        }

        static void Pusiryok()
        {
            int[] array = new int[20] { 16, 5, 15, 6, 4, 7, 13, 8, 12, 9, 11, 10, 20, 1, 19, 2, 18, 3, 17, 14 };
            int compares = 0;
            int swaps = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    compares++;
                    if (array[j] > array[j + 1])
                    {
                        swaps++;
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
            Console.WriteLine("Результат сортировки пузырьком:");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine($"Число сравнений: {compares}");
            Console.WriteLine($"Число перестановок: {swaps}\r\n");
        }

        static void Shell()
        {
            int[] array = new int[20] { 16, 5, 15, 6, 4, 7, 13, 8, 12, 9, 11, 10, 20, 1, 19, 2, 18, 3, 17, 14 };
            int compares = 0;
            int swaps = 0;
            int d = 4;
            while (d >= 1)
            {
                for (int i = d; i < array.Length; i++)
                {
                    int j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        compares++;
                        swaps++;
                        Swap(ref array[j], ref array[j - d]);
                        j -= d;
                    }
                }
                d /= 2;
            }
            Console.WriteLine("Результат сортировки Шелла:");
            Console.WriteLine(string.Join(", ", array));
            Console.WriteLine($"Число сравнений: {compares}");
            Console.WriteLine($"Число перестановок: {swaps}\r\n");
        }

        static void Swap(ref int value1, ref int value2) => (value2, value1) = (value1, value2);
    }
}