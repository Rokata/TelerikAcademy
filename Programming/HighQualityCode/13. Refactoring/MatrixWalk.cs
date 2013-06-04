using System;
using System.Collections.Generic;

namespace MatrixWalk
{
    class MatrixWalk
    {
        static int ReadInput()
        {
            Console.Write("Enter a positive number: ");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number between 0 and 100.");
                input = Console.ReadLine();
            }

            return n;
        }

        static void Main()
        {
            int n = ReadInput();
            Matrix matrix = new Matrix(n);

            matrix.GenerateMatrix();
            matrix.PrintMatrix();
        }
    }
}
