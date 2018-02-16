using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master2017Sem1_tema_ecuatie_matriciala_nr_compus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(testEcuatie(new float[,]{{ 2, -1, 4}, {3, 2, 13 } }, new float[]{ 3, 2}));
        }

        static bool testEcuatie(float [,]matrix, float []result)
        {
            EcuationSolver ecuationSolver = new EcuationSolver();
            float[] actualResult = ecuationSolver.solve(matrix);

            for (int i = 0; i < result.Length; i++)
                if (actualResult[i] != result[i])
                    return false;

            return true;
        }
    }
}
