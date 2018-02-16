using System;

namespace Master2017Sem1_tema_ecuatie_matriciala_nr_compus
{
    public class EcuationSolver
    {
        public EcuationSolver()
        {
        }

        public float[] solve(float[,] matrix)
        {
            float[,] A = initA(matrix);
            float[] B = initB(matrix);

            Tuple<float, float[,]> detAndAdj = invert(A);
            float[] X = multiplyAndGetX(detAndAdj.Item2, B);

            for (int i = 0; i < X.Length; i++)
                X[i] = 1f / detAndAdj.Item1 * X[i];

            return X;
        }

        public Tuple<float, float[,]> invert(float[,] A)
        {
            int n = A.GetUpperBound(0) + 1;
            float[,] invertedA = new float[n, n];
            float det = determinant(A);
            float[,] adjA = adjugate(A);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    invertedA[i, j] = /*(1 / det) * */adjA[i, j];

            return Tuple.Create(det, invertedA);
        }

        public float determinant(float[,] A)
        {
            int n = A.GetUpperBound(0) + 1;
            if (n == 1)
            {
                return A[0, 0];
            }
            else if (n == 2)
            {
                return A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
            }
            else if (n == 3)
            {
                return
                A[0, 0] * A[1, 1] * A[2, 2]
                + A[0, 1] * A[1, 2] * A[2, 0]
                + A[0, 2] * A[1, 0] * A[2, 1]
                - A[2, 0] * A[1, 1] * A[0, 2]
                - A[2, 1] * A[1, 2] * A[0, 0]
                - A[2, 2] * A[1, 0] * A[0, 1];
            }
            else 
                throw new NotImplementedException();
        }

        public float[,] adjugate(float[,] A)
        {
            int n = A.GetUpperBound(0) + 1;

            float[,] adjA = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    adjA[i, j] = /*(float)Math.Pow(-1, i + 1 + j + 1) * */minorOf(A, i, j);

            return adjA;
        }

        public float minorOf(float[,] matrix, int j, int i)
        {
            int n = matrix.GetUpperBound(0);
            float[,] newMatrix = new float[n, n];
            float[,] tempMatrix = (float[,])matrix.Clone();


            //moveData upwards
            for (int k = 0; k < n; k++)
                for (int l = 0; l <= n; l++)
                    if (k >= i)
                        tempMatrix[k, l] = tempMatrix[k + 1, l];

            //moveData to left
            for (int k = 0; k <= n; k++)
                for (int l = 0; l < n; l++)
                    if (l >= j)
                        tempMatrix[k, l] = tempMatrix[k, l + 1];

            for (int k = 0; k < n; k++)
                for (int l = 0; l < n; l++)
                    newMatrix[k, l] = tempMatrix[k, l];


            if (n == 3)
            {
                return (float)Math.Pow(-1, i + 1 + j + 1) * determinant(newMatrix);
            }

            else if (n == 2)
            {
                return (float)Math.Pow(-1, i + 1 + j + 1) * determinant(newMatrix);
            }

            else if (n == 1)
            {
                return (float)Math.Pow(-1, i + 1 + j + 1) * determinant(newMatrix);
            }
            else throw new NotImplementedException();
        }

        public float[] multiplyAndGetX (float[,] A, float[] B)
        {
            float[] X = new float[A.GetUpperBound(1) + 1];

            for (int i = 0; i <= A.GetUpperBound(1); i++)
                for (int j = 0; j <= B.GetUpperBound(0); j++)
                    X[i] += A[i, j] * B[j];

            return X;
        }

        public float[] initB(float[,] matrix)
        {
            int height = matrix.GetUpperBound(0) + 1;
            int width = matrix.GetUpperBound(1) + 1;
            float[] B = new float[height];

            for (int i = 0; i < B.Length; i++)
                B[i] = matrix[i, width -1];

            return B;
        }

        public float[,] initA(float[,] matrix)
        {
            int n = matrix.GetUpperBound(0) + 1;

            float[,] A = new float[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    A[i, j] = matrix[i, j];
            return A;
        }
    }
}