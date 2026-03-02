using System;

public class Program<T>
{
    public static void Display(T[] inputArray)
    {
        foreach (T element in inputArray)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    public static T[] Sort(T[] inputArray)
    {
        Array.Sort(inputArray);
        return inputArray;
    }
}

class Test
{
    static void Main()
    {
        Console.WriteLine("Chon kieu du lieu:");
        Console.WriteLine("1. int");
        Console.WriteLine("2. double");
        Console.WriteLine("3. string");

        int choice = int.Parse(Console.ReadLine());

        Console.Write("Nhap so phan tu: ");
        int n = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                int[] arrInt = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Nhap phan tu {i}: ");
                    arrInt[i] = int.Parse(Console.ReadLine());
                }
                Program<int>.Display(arrInt);
                break;

            case 2:
                double[] arrDouble = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Nhap phan tu {i}: ");
                    arrDouble[i] = double.Parse(Console.ReadLine());
                }
                Program<double>.Display(arrDouble);
                break;

            case 3:
                string[] arrString = new string[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Nhap phan tu {i}: ");
                    arrString[i] = Console.ReadLine();
                }
                Program<string>.Display(arrString);
                break;

            default:
                Console.WriteLine("Lua chon khong hop le!");
                break;
        }
    }
}