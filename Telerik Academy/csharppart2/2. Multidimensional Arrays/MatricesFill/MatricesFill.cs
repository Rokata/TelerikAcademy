using System;

class Program
{
    public static int[,] CreateMatrix()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine();

        int[,] matrix = new int[n, n];
        return matrix;
    }

    public static void PrintMatrix(int[,] matrix) {
        int rows = matrix.GetLength(0);
        int cols = rows;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public static void FillMatrixTypeA(int[,] matrix, int length)
    {
        for (int i = 0; i < length; i++)
        {
            matrix[i, 0] = i + 1;
            for (int j = 1; j < length; j++)
            {
                matrix[i, j] = matrix[i, j - 1] + length;
            }
        }
    }

    public static void FillMatrixTypeB(int[,] matrix, int length)
    {
        int current = 0;
        int col = 0;

        while (col < length)
        {
            for (int i = 0; i < length; i++)
            {
                matrix[i, col] = ++current;
            }

            if (++col == length) break;

            for (int i = length - 1; i >= 0; i--)
            {
                matrix[i, col] = ++current;
            }

            col++;
        }
    }

    public static void FillMatrixTypeC(int[,] matrix, int length)
    {
        int value = 0;

        for (int i = length - 1; i >= 0; i--)
        {
            for (int col = 0, row = i; row <= length - 1; col++, row++)
            {
                matrix[row, col] = ++value;
            }
        }

        for (int i = 0; i < length - 1; i++)
        {
            for (int row = 0, col = i+1; col <= length - 1; col++, row++)
            {
                matrix[row, col] = ++value;
            }
        }
    }

    public static void FillMatrixTypeD(int[,] matrix, int length)
    {
        int start = 0;
        int end = length;
        int k = 1;
        while (end - start >= 1)
        {
            for (int i = start; i < end; i++)
            {
                matrix[i, start] = k;
                ++k;
            }
            for (int i = start + 1; i < end; i++)
            {
                matrix[end - 1, i] = k;
                ++k;
            }
            for (int i = end - 2; i >= start; i--)
            {
                matrix[i, end-1] = k;
                ++k;
            }
            for (int i = end - 2; i >= start + 1; i--)
            {
                matrix[start, i] = k;
                ++k;
            }
            ++start;
            --end;
        }
    }

    static void Main()
    {
        int[,] matrix = CreateMatrix();

        Console.WriteLine("Testing type A");
        FillMatrixTypeA(matrix, matrix.GetLength(0));
        PrintMatrix(matrix);
        matrix = CreateMatrix();

        Console.WriteLine("Testing type B");
        FillMatrixTypeB(matrix, matrix.GetLength(0));
        PrintMatrix(matrix);
        matrix = CreateMatrix();

        Console.WriteLine("Testing type C");
        FillMatrixTypeC(matrix, matrix.GetLength(0));
        PrintMatrix(matrix);
        matrix = CreateMatrix();

        Console.WriteLine("Testing type D");
        FillMatrixTypeD(matrix, matrix.GetLength(0));
        PrintMatrix(matrix);
    }
}