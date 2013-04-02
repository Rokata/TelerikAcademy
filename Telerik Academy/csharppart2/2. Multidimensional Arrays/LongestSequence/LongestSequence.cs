using System;
using System.Collections.Generic;

class LongestSequence
{
    public static void CheckIfLongest(ref int current, ref int max, ref string currentSyllable, ref string maxSyllable)
    {
        if (current > max)
        {
            max = current;
            maxSyllable = currentSyllable;
        }
        current = 1;
    }

    public static Tuple<string, int> GetLongestSequence(string[,] matrix)
    {
        int longestSequence = 0, currentSequence = 1;
        string maxSyllable = string.Empty, currentSyllable = string.Empty;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++) // longest in rows 
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i, j] == matrix[i, j - 1]) currentSequence++;
                if (matrix[i, j] != matrix[i, j - 1] || j == cols - 1)
                {
                    currentSyllable = matrix[i, j - 1];
                    CheckIfLongest(ref currentSequence, ref longestSequence, ref currentSyllable, ref maxSyllable);
                }
            }

        for (int i = 0; i < cols; i++) // longest in cols
            for (int j = 1; j < rows; j++)
            {
                if (matrix[j, i] == matrix[j - 1, i]) currentSequence++;
                if (matrix[j, i] != matrix[j - 1, i] || j == rows - 1)
                {
                    currentSyllable = matrix[j - 1, i];
                    CheckIfLongest(ref currentSequence, ref longestSequence, ref currentSyllable, ref maxSyllable);
                }
            }

        for (int i = 1; i < rows; i++) // longest in main diagonal
            for (int j = 1; j < cols; j++)
            {
                int initial_i = i;
                int initial_j = j;

                while (i < rows && j < cols)
                {
                    if (matrix[i, j] == matrix[i - 1, j - 1]) currentSequence++;

                    if (matrix[i, j] != matrix[i - 1, j - 1] || i == rows - 1 || j == cols - 1)
                    {
                        currentSyllable = matrix[i - 1, j - 1];
                        CheckIfLongest(ref currentSequence, ref longestSequence, ref currentSyllable, ref maxSyllable);

                        if (i == rows - 1 || j == cols - 1) break;
                    }
                    i++;
                    j++;
                }
                i = initial_i;
                j = initial_j;
            }

        for (int i = 0; i < rows; i++) // longest in 2nd diagonal
            for (int j = 1; j < cols; j++)
            {
                int initial_i = i;
                int initial_j = j;

                while (i < rows - 1  && j >= 1)
                {
                    if (matrix[i, j] == matrix[i + 1, j - 1]) currentSequence++;

                    if (matrix[i, j] != matrix[i + 1, j - 1] || i == rows - 2 || j == 1)
                    {
                        currentSyllable = matrix[i, j];
                        CheckIfLongest(ref currentSequence, ref longestSequence, ref currentSyllable, ref maxSyllable);

                        if (i == rows - 2 || j == 0) break;
                    }
                    i++;
                    j--;
                }
                i = initial_i;
                j = initial_j;
            }
        
        return new Tuple<string, int>(maxSyllable, longestSequence); // longest of all
    }

    static void Main()
    {
        string[,] matrix = {
                             { "TA", "TA", "XA", "TA", "TA", "TA", "TA"},
                             { "ta", "LA", "ha", "NA", "lq", "TA", "na"},
                             {"ba", "ha", "TA", "SA", "TA", "na", "na"},
                             {"lq", "NA", "NA", "N/A", "NA", "NA", "NA"},
                             {"lq", "lq", "TA", "NA", "TA", "ca", "ca"},
                             {"lq", "TA", "ha", "NA", "ca", "TA", "lq"},
                             { "TA", "TA", "TA", "TA", "TA", "lq", "TA"},
                             { "lq", "TA", "ha", "NA", "lq", "ba", "na"},
                             {"lq", "ha", "TA", "lq", "na", "na", "na"},
                             {"lq", "NA", "lq", "XA", "NA", "LA", "NA"},
                             {"lq", "lq", "ha", "NA", "TA", "ca", "ca"},
                             {"xa", "lq", "ha", "NA", "ca", "TA", "ca"}
                           };

        Tuple<string, int> result = GetLongestSequence(matrix);

        Console.WriteLine("Longest sequence count: {0} ({1})", result.Item2, result.Item1);
    }
}