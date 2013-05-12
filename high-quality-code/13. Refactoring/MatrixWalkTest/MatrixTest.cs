using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixWalk;

namespace MatrixWalkTest
{
    [TestClass]
    public class MatrixTest
    {
        private bool AreEqualMatrices(int[,] first, int[,] second)
        {
            int length = first.GetLength(0);

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                {
                    if (first[i, j] != second[i, j])
                        return false;
                }

            return true;
        }

        [TestMethod]
        public void GenerateMatrix_EqualOnSize6()
        {
            Matrix test = new Matrix(6);
            test.GenerateMatrix();

            int[,] resultMatrix = test.IntMatrix;
            int[,] expectedMatrix = { {1, 16,  17,  18,  19, 20, },
                                      {15,  2,  27,  28,  29,  21 },
                                      {14,  31,   3,  26,  30,  22},
                                      {13,  36,  32,   4, 25,  23 },
                                      {12,  35,  34,  33,   5,  24 },
                                      {11,  10,	  9,   8,   7,   6}
                                    };
            bool equal = AreEqualMatrices(resultMatrix, expectedMatrix);
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        public void GenerateMatrix_SingleElementMatrixValid()
        {
            Matrix test = new Matrix(1);
            test.GenerateMatrix();

            int[,] resultMatrix = test.IntMatrix;
            int[,] expectedMatrix = { {1} };
            bool equal = AreEqualMatrices(resultMatrix, expectedMatrix);
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid matrix size")]
        public void MatrixConstructor_ThrowsExceptionOnNegativeValue()
        {
            Matrix test = new Matrix(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid matrix size")]
        public void MatrixConstructor_ThrowsExceptionOnBigValue()
        {
            Matrix test = new Matrix(1000);
        }
    }
}
