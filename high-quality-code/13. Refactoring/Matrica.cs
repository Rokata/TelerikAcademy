using System;

namespace Task3
{
    struct Coords
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class WalkInMatrica
    {
        static void ChangeDirection(ref int dx, ref int dy)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int directionIndex = 0;
            for (int i = 0; i < directionX.Length; i++)
            {
                if (directionX[i] == dx && directionY[i] == dy)
                {
                    directionIndex = i;
                    break;
                }
            }

            if (directionIndex == directionX.Length - 1)
            {
                dx = directionX[0];
                dy = directionY[0];
                return;
            }

            dx = directionX[directionIndex + 1];
            dy = directionY[directionIndex + 1];
        }

        static bool HasAvailablePositions(int[,] matrix, int x, int y)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int matrixLength = matrix.GetLength(0);

            for (int i = 0; i < directionX.Length; i++)
            {
                if (x + directionX[i] >= matrixLength || x + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (y + directionY[i] >= matrixLength || y + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }
            }

            for (int i = 0; i < directionX.Length; i++)
            {
                if (matrix[x + directionX[i], y + directionY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void FindCell(int[,] matrix, ref Coords coords)
        {
            int length = matrix.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        coords.X = i;
                        coords.Y = j;
                        return;
                    }
                }
            }
        }

        static int ReadInput()
        {
            return 6;
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void GenerateMatrix(int[,] matrix, ref int k, ref Coords currentPosition, ref Coords direction)
        {
            int n = matrix.GetLength(0);
            int i = currentPosition.X;
            int j = currentPosition.Y;
            int dx = direction.X;
            int dy = direction.Y;

            while (true)
            { //malko e kofti tova uslovie, no break-a raboti 100% : )
                matrix[i, j] = k;
                if (!HasAvailablePositions(matrix, i, j)) { break; }// prekusvame ako sme se zadunili

                if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                {
                    while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0))
                    {
                        ChangeDirection(ref dx, ref dy);
                    }
                }

                i += dx;
                j += dy;
                k++;
            }
        }

        static void Main()
        {
            int n = ReadInput();
            int[,] matrix = new int[n, n];
            Coords startCoords = new Coords(); 
            Coords startDirection = new Coords();
            startCoords.X = 0;
            startCoords.Y = 0;
            startDirection.X = 1;
            startDirection.Y = 1;

            int startValue = 1;

            GenerateMatrix(matrix, ref startValue, ref startCoords, ref startDirection);

            FindCell(matrix, ref startCoords);

            if (startCoords.X != 0 && startCoords.Y != 0)
            { // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                startDirection.X = 1;
                startDirection.Y = 1;

                GenerateMatrix(matrix, ref startValue, ref startCoords, ref startDirection);
            }

            PrintMatrix(matrix);
        }
    }
}
