using System;

class CatalanNumbers
{
    static void Main()
    {
        int N = 10;
        long doubledNfact = 1, nPlusOneFact = 1, nFact = 1;

        for (int i = 1; i <= 2 * N; i++)
        {
            if (i < N + 1) nFact *= i;
            doubledNfact *= i;
        }

        nPlusOneFact = nFact * (N + 1);
        long catalan = doubledNfact / (nFact * nPlusOneFact);

        Console.WriteLine("{0}th Catalan number is {1}", N, catalan);
    }
}