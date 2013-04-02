using System;
using System.Text;

namespace MatrixClass
{
    class Matrix<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private dynamic[,] matrix;

        public Matrix(dynamic[,] matrix)
        {
            this.matrix = matrix;
        }

        public dynamic[,] Matrix_
        {
            get { return this.matrix; }
            set
            {
                if (value == null) throw new ArgumentException("Invalid value!");
                this.matrix = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.matrix.GetLength(0) != m2.matrix.GetLength(0) || m1.matrix.GetLength(1) != m2.matrix.GetLength(1))
            {
                throw new FormatException("It is not possible to add matrices of different sizes!");
            }

            int m = m1.matrix.GetLength(0);
            int n = m1.matrix.GetLength(1);

            dynamic[,] resultMatrix = new dynamic[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultMatrix[i, j] = m1[i, j] + m2[i, j];
                }
            }

            return new Matrix<T>(resultMatrix);
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.matrix.GetLength(0) != m2.matrix.GetLength(0) || m1.matrix.GetLength(1) != m2.matrix.GetLength(1))
            {
                throw new FormatException("It is not possible to add matrices of different sizes!");
            }

            int m = m1.matrix.GetLength(0);
            int n = m1.matrix.GetLength(1);

            dynamic[,] resultMatrix = new dynamic[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultMatrix[i, j] = m1[i, j] - m2[i, j];
                }
            }

            return new Matrix<T>(resultMatrix);
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            int m1Rows = m1.matrix.GetLength(0);
            int m1Cols = m1.matrix.GetLength(1);
            int m2Rows = m2.matrix.GetLength(0);
            int m2Cols = m2.matrix.GetLength(1);

            if (m1Cols != m2Rows)
            {
                throw new FormatException("Cols of matrix 1 must be equal to rows of matrix 2!");
            }

            int newRows = m1Rows;
            int newCols = m2Cols;
            
            dynamic[,] result = new dynamic[newRows, newCols];

            for (int i = 0; i < m1Rows; i++)
            {
                for (int j = 0; j < m2Cols; j++)
                {
                    dynamic cellValue = 0;
                    for (int row = 0, col = 0; row < m1Cols; row++, col++)
                    {
                        cellValue += m1[i, row] * m2[col, j];
                    }
                    result[i, j] = cellValue;
                }
            }

            return new Matrix<T>(result);
        }

        
        public static bool operator true(Matrix<T> m) 
        {
            for (int i = 0; i < m.Matrix_.GetLength(0); i++)
                for (int j = 0; j < m.Matrix_.GetLength(1); j++)
                    if (m[i, j] == 0) return false;

            return true;
        }

        public static bool operator false(Matrix<T> m)
        {
            for (int i = 0; i < m.Matrix_.GetLength(0); i++)
                for (int j = 0; j < m.Matrix_.GetLength(1); j++)
                    if (m[i, j] == 0) return true;

            return false;
        }

        public dynamic this[int i, int j]
        {
            get 
            {
                if (i < 0 || j < 0 || i > matrix.GetLength(0) - 1 || j > matrix.GetLength(1) - 1)
                    throw new ArgumentException("Invalid indexes!");
                return this.matrix[i, j];            
            }
            set 
            {
                if (i < 0 || j < 0 || i > matrix.GetLength(0) - 1 || j > matrix.GetLength(1) - 1)
                    throw new ArgumentException("Invalid indexes!");
                this.matrix[i, j] = value; 
            }
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    result.Append(this[i, j] + "\t");
                }
                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
