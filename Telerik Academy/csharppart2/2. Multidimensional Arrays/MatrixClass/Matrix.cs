using System;
using System.Text;

namespace MatrixClass
{
    public class Matrix
    {
        private int[,] matrix {get; set;}

        public Matrix(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public int[,] Matrix_
        {
            get { return this.matrix; }
            set
            {
                this.matrix = value;
            }
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.matrix.GetLength(0) != m2.matrix.GetLength(0) || m1.matrix.GetLength(1) != m2.matrix.GetLength(1))
            {
                Console.WriteLine("It is not possible to add matrices of different sizes!");
                return null;
            }

            int m = m1.matrix.GetLength(0);
            int n = m1.matrix.GetLength(1);

            int[,] resultMatrix = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultMatrix[i, j] = m1[i, j] + m2[i, j];
                }
            }

            return new Matrix(resultMatrix);
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.matrix.GetLength(0) != m2.matrix.GetLength(0) || m1.matrix.GetLength(1) != m2.matrix.GetLength(1))
            {
                Console.WriteLine("It is not possible to add matrices of different sizes!");
                return null;
            }

            int m = m1.matrix.GetLength(0);
            int n = m1.matrix.GetLength(1);

            int[,] resultMatrix = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultMatrix[i, j] = m1.matrix[i, j] - m2.matrix[i, j];
                }
            }

            return new Matrix(resultMatrix);
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            int m1Rows = m1.matrix.GetLength(0);
            int m1Cols = m1.matrix.GetLength(1);
            int m2Rows = m2.matrix.GetLength(0);
            int m2Cols = m2.matrix.GetLength(1);

            if (m1Cols != m2Rows)
            {
                Console.WriteLine("Cols of matrix 1 must be equal to rows of matrix 2!");
                return new Matrix(new int[0, 0]);
            }

            int newRows = m1Rows;
            int newCols = m2Cols;

            int[,] result = new int[newRows, newCols];

            for (int i = 0; i < m1Rows; i++)
            {
                for (int j = 0; j < m2Cols; j++)
                {
                    for (int row = 0, col = 0; row < m1Cols; row++, col++)
                    {
                        result[i,j] += (m1[i, row] * m2[col, j]); 
                    }
                }
            }

            return new Matrix(result);      
        }

        public int this[int i, int j]
        {
            get
            {
                return this.matrix[i, j];
            }
            set
            {
                this.matrix[i, j] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j=0; j<this.matrix.GetLength(1); j++) {
                    result.Append(this[i, j] + "\t");
                }
                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
