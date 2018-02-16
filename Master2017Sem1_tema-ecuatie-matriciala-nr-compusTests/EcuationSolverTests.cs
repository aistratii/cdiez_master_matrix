using Microsoft.VisualStudio.TestTools.UnitTesting;
using Master2017Sem1_tema_ecuatie_matriciala_nr_compus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master2017Sem1_tema_ecuatie_matriciala_nr_compus.Tests
{
    [TestClass()]
    public class EcuationSolverTests
    {

        EcuationSolver solver = new EcuationSolver();

        [TestMethod()]
        public void initATest()
        {
            float[,] expectedA = new float[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            float[,] actualA = solver.initA(new float[,] { { 1, 2, 3, 0 }, { 4, 5, 6, 0 }, { 7, 8, 9, 0 } });

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expectedA[i, j], actualA[i, j]);
        }

        [TestMethod()]
        public void initBTest()
        {
            float[] expectedB = new float[] { 10, 11, 12 };
            float[] actualB = solver.initB(new float[,] { { 1, 2, 3, 10 }, { 4, 5, 6, 11 }, { 7, 8, 9, 12 } });

            for (int i = 0; i < 3; i++)
                Assert.AreEqual(expectedB[i], actualB[i]);
        }

        [TestMethod()]
        public void multiplyAndGetXTest()
        {
            float[,] matrix1 = new float[,] { { 2, 1 }, { -3, 2 } };
            float[] matrix2 = new float[] { 4, 13 };
            float[] expectedMatrix = new float[] { 21, 14 };

            float[] actualMatrix = solver.multiplyAndGetX(matrix1, matrix2);

            Assert.AreEqual(expectedMatrix[0], actualMatrix[0]);
            Assert.AreEqual(expectedMatrix[1], actualMatrix[1]);
        }

        [TestMethod()]
        public void adjugateTestN2()
        {
            float[,] expectedMatrix = new float[,] { { 2, 1 }, { -3, 2 } };
            float[,] actualMatrix = solver.adjugate(new float[,] { { 2, -1 }, { 3, 2 } });

            for (int i = 0; i <= expectedMatrix.GetUpperBound(0); i++)
                for (int j = 0; j <= expectedMatrix.GetUpperBound(0); j++)
                    Assert.AreEqual(expectedMatrix[i, j], actualMatrix[i, j]);
        }

        [TestMethod()]
        public void adjugateTestN3()
        {
            float[,] expectedMatrix = new float[,] { { -8, 18, -4 }, { -5, 12, -1 }, { 4, -6, 2 } };
            float[,] actualMatrix = solver.adjugate(new float[,] { { -3, 2, -5 }, { -1, 0, -2 }, { 3, -4, 1 } });

            for (int i = 0; i <= expectedMatrix.GetUpperBound(0); i++)
                for (int j = 0; j <= expectedMatrix.GetUpperBound(0); j++)
                    Assert.AreEqual(expectedMatrix[i, j], actualMatrix[i, j]);

            for (int i = 0; i <= expectedMatrix.GetUpperBound(0); i++)
                for (int j = 0; j <= expectedMatrix.GetUpperBound(0); j++)
                    Assert.AreEqual(expectedMatrix[i, j], actualMatrix[i, j]);
        }

        [TestMethod()]
        public void minorOfTest()
        {
            float[,] inputMatrix = new float[,] { { 1, 4, 7 }, { 3, 0, 5 }, { -1, 9, 11 } };
            float expectedMinor = -13;
            float actualMinor = solver.minorOf(inputMatrix, 1, 2);

            Assert.AreEqual(expectedMinor, actualMinor);
        }

        [TestMethod()]
        public void minorOfTest2()
        {
            float[,] inputMatrix = new float[,] { { -3, 2, -5 }, { -1, 0, -2 }, { 3, -4, 1 } };
            float expectedMinor = -6;
            float actualMinor = solver.minorOf(inputMatrix, 2, 1);

            Assert.AreEqual(expectedMinor, actualMinor);
        }

        [TestMethod()]
        public void determinantTestN1()
        {
            Assert.AreEqual(5, solver.determinant(new float[,] { { 5 } }));
        }

        [TestMethod()]
        public void determinantTestN2()
        {
            Assert.AreEqual(7, solver.determinant(new float[,] { { 2, -1 }, { 3, 2 } }));
        }

        [TestMethod()]
        public void determinantTestN3()
        {
            Assert.AreEqual(18, solver.determinant(new float[,] { { -2, 2, -3 }, { -1, 1, 3 }, { 2, 0, -1 } }));
        }

        [TestMethod()]
        public void invertTest()
        {

            Assert.Fail();
            /*float invetDet = 1 / 7;
            float[,] expectedMatrix = new float[,] { { invetDet * 2, invetDet * 1 }, { invetDet * - 3, invetDet * 2 } };
            float[,] inputMatrix = new float[,] { { 2, -1 }, { 3, 2 } };

            float[,] actualMatrix = solver.invert(inputMatrix);

            for (int i = 0; i <= expectedMatrix.GetUpperBound(0); i++)
                for (int j = 0; j <= expectedMatrix.GetUpperBound(0); j++)
                    Assert.AreEqual(expectedMatrix[i, j], actualMatrix[i, j]);*/
        }

        [TestMethod()]
        public void solveTestN2_T1()
        {
            float[] expectedMatrix = { 3, 2 };

            float[] actualMatrix = solver.solve(new float[,] { { 2, -1, 4 }, { 3, 2, 13} });

            for (int i = 0; i <= expectedMatrix.GetUpperBound(0); i++)
                Assert.AreEqual(expectedMatrix[i], actualMatrix[i]); 
        }

        [TestMethod()]
        public void solveTestN2_T2()
        {
            float[] expectedMatrix = { -15, 8, 2 };

            float[] actualMatrix = solver.solve(new float[,] { { 1, 3, -2, 5 }, { 3, 5, 6, 7 }, { 2, 4, 3, 8} });

            for (int i = 0; i <= expectedMatrix.GetUpperBound(0); i++)
                Assert.AreEqual(expectedMatrix[i], actualMatrix[i]);
        }
    }
}