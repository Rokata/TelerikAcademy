using System;

namespace MatrixClass
{
    class MatrixClass
    {
        static void Main()
        {
            int[,] matrix1 = {
                                {5, 3, 1, 2},
                                {3, 8, 11, 9},
                                {1, 1, 9, 2}
                            };

            int[,] matrix2 = {
                                {3, 16, 8, 5},
                                {-1, -5, 11, 4},
                                {3, 6, 12, 12}
                             };

            Matrix m1 = new Matrix(matrix1);
            Matrix m2 = new Matrix(matrix2);

            Console.WriteLine("m1 + m2:\n" + (m1 + m2).ToString());
            Console.WriteLine("m1 - m2:\n" + (m1 - m2).ToString());

            matrix2 = new int[,] {
                                {3, 16},
                                {-1, -5},
                                {3, 6},
                                {3, 6}
                      }; // change it to such that cols of m1 = rows of m2 and thus to be able to be multuplied

            m2.Matrix_ = matrix2;

            // Demo of the overriden indexer isn't necessary beacuse it is used in the methods for +/-/*

            Console.WriteLine("m1 * m2:\n" + (m1 * m2).ToString());
        }
    }
}
