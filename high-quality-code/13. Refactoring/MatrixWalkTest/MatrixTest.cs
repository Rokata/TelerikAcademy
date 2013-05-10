using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixWalk;

namespace MatrixWalkTest
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void GenerateMatrix_EqualOnSize6()
        {
            var currentConsoleOut = Console.Out;

            int[,] expectedMatrix =  { 
                                       {1,  16, 17,  18,  19,  20}, 
                                       {15,  2,  27,  28,  29,  21, },
                                       {14,  31,  3,  26,  30,  22, },
                                       {13,  36,  32,  4,  25,  23 }, 
                                       {12,  35,  34,  33,  5,  24 },
                                       {11,  10,   9,   8,  7,   6 } 
                                     };
            Matrix resultMatrix = new Matrix(6);
            resultMatrix.GenerateMatrix();

            int[,] result = resultMatrix.IntMatrix;
            bool areEqual = true;

            for (int i = 0; i < expectedMatrix.Length; i++)
            {
                for (int j = 0; j < expectedMatrix.Length; j++)
                {
                    if (expectedMatrix[i, j] != result[i, j])
                    {
                        areEqual = false;
                        break;
                    }
                }
            }

            //using (var consoleOutput = new ConsoleOutput())
            //{
            //    Console.Write(result);

            //    Assert.AreEqual(result, expectedResult);
            //}

            Assert.AreEqual(true, areEqual);
        }
    }
}
