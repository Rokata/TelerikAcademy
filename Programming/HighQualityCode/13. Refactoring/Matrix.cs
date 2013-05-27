using System;
using System.Text;

namespace MatrixWalk
{
    public class Matrix
    {
        private int[,] matrix;
        private int currentX;
        private int currentY;
        private int directionX;
        private int directionY;
        private int size;

        public Matrix(int size)
        {
            if (size <= 0 || size > 100)
                throw new ArgumentException("Invalid size value for the matrix.");

            this.matrix = new int[size, size];
            this.size = size;
            this.currentX = 0;
            this.currentY = 0;
            this.directionX = 1;
            this.directionY = 1;
        }

        public int[,] IntMatrix
        {
            get { return this.matrix; }
        }

        private void FindFirstFreeCell()
        {
            int length = matrix.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        this.currentX = i;
                        this.currentY = j;
                        return;
                    }
                }
            }
        }

        private void ChangeDirection()
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int directionIndex = 0;
            for (int i = 0; i < directionsX.Length; i++)
            {
                if (directionsX[i] == this.directionX && directionsY[i] == this.directionY)
                {
                    directionIndex = i;
                    break;
                }
            }

            if (directionIndex == directionsX.Length - 1)
            {
                this.directionX = directionsX[0];
                this.directionY = directionsY[0];
                return;
            }

            this.directionX = directionsX[directionIndex + 1];
            this.directionY = directionsY[directionIndex + 1];
        }

        private bool HasPositionsClockwise()
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < directionX.Length; i++)
            {
                if (this.currentX + directionX[i] >= size || this.currentX + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (this.currentY + directionY[i] >= size || this.currentY + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }
            }

            for (int i = 0; i < directionX.Length; i++)
            {
                if (matrix[currentX + directionX[i], this.currentY + directionY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void GenerateMatrix()
        {
            int value = 1;
            bool matrixFull = false;

            while (!matrixFull)
            {
                matrix[currentX, currentY] = value;

                if (!HasPositionsClockwise())
                {
                    int oldX = this.currentX;
                    int oldY = this.currentY;
                    FindFirstFreeCell();

                    if (oldX == this.currentX && oldY == this.currentY)
                    {
                        matrixFull = true;
                        break;
                    }

                    this.directionX = 1;
                    this.directionY = 1;
                    value++;
                    continue;
                }

                while (IsOutsideMatrix())
                {
                    ChangeDirection();
                }

                currentX += directionX;
                currentY += directionY;
                value++;
            }
        }

        private bool IsOutsideMatrix()
        {
            bool outsideBoundsX = (currentX + directionX >= size || currentX + directionX < 0);
            bool outsideBoundsY = (currentY + directionY >= size || currentY + directionY < 0);

            return (outsideBoundsX || outsideBoundsY || matrix[currentX + directionX, currentY + directionY] != 0);
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
