using System;

class Program
{
    public static int[,] ReadMatrix()
    {
        Console.Write("Enter N: ");
        int rows = int.Parse(Console.ReadLine());

        if (rows < 3)
        {
            Console.WriteLine("Error! N must be at least 3!");
            return null;
        }

        Console.Write("Enter M: ");
        int cols = int.Parse(Console.ReadLine());

        if (cols < 3)
        {
            Console.WriteLine("Error! N must be at least 3!");
            return null;
        }

        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("matrix[{0},{1}] = ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        return matrix;
    }

    public static int FindMaxSum(int[,] matrix)
    {
        int bestSum = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] +  matrix[row, col + 2] +
                    matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                    matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (sum > bestSum)
                    bestSum = sum;
            }
        return bestSum;
    }

    static void Main()
    {
        int[,] matrix = ReadMatrix();
        if (matrix != null) Console.WriteLine("Max 3x3 sum is: {0}", FindMaxSum(matrix));
    }
}
