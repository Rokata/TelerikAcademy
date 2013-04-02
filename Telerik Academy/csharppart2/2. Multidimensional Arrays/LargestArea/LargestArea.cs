using System;
using System.Collections.Generic;

class LargestArea
{
    public static void Check(int i, int j, int prev_i, int prev_j)
    {
        if (i == rows || j == cols || i == -1 || j == -1 || marked[i,j]) return;

        if (matrix[i, j] != matrix[prev_i, prev_j]) return;
        else
        {
            currentArea++;
            marked[i, j] = true; 
            Check(i, j + 1, i, j);
            Check(i, j - 1, i, j);
            Check(i + 1, j, i, j);
            Check(i - 1, j, i, j);
        }
    }

    static int[,] matrix = {
                            {1, 3, 2, 2, 2, 4},
                            {3, 3, 3, 2, 4, 4},
                            {4, 3, 1, 2, 3, 3},
                            {4, 3, 1, 3, 3, 1},
                            {4, 3, 3, 3, 1, 1}
                        };

    static int rows = matrix.GetLength(0);
    static int cols = matrix.GetLength(1);
    static bool[,] marked = new bool[rows, cols];
    static int currentArea = 0, maxArea = int.MinValue;
    
    static void Main()
    {

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                Check(i, j, i, j);
                if (currentArea > maxArea) maxArea = currentArea;
                currentArea = 0;
            }

        Console.WriteLine("Max area: " + maxArea);
    }
}