using System;

namespace MatrixClass
{
    class Program
    {
        static void Main()
        {
            try
            {
                dynamic[,] matrix1 = {
                                {5, 3, 1, 2},
                                {3, 8, 11, 9},
                                {1, 1, 9, 2}
                            };

                dynamic[,] matrix2 = {
                                {3, 16, 8, 5},
                                {-1, -5, 11, 4},
                                {3, 6, 12, 12}
                             };
                
                Matrix<int> m1 = new Matrix<int>(matrix1);
                Matrix<int> m2 = new Matrix<int>(matrix2);

                Console.WriteLine("m1 + m2:\n" + (m1 + m2).ToString());
                Console.WriteLine("m1 - m2:\n" + (m1 - m2).ToString());

                matrix2 = new dynamic[,] {
                                {3, 16},
                                {-1, -5},
                                {3, 6},
                                {3, 6}
            };

                m2.Matrix_ = matrix2;

                Console.WriteLine("m1 * m2:\n" + (m1 * m2).ToString());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
