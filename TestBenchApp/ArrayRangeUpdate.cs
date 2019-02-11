using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBenchApp
{
    class ArrayRangeUpdate
    {
        void initializeDiffArray(int[] A, int[] D)
        {

            int n = A.Length;

            D[0] = A[0];
            D[n] = 0;
            for (int i = 1; i < n; i++)
                D[i] = A[i] - A[i - 1];
        }

        // Does range update 
        void update(int[] D, int l, int r, int x)
        {
            D[l] += x;
            D[r + 1] -= x;
        }

        // Prints updated Array 
        int printArray(int[] A, int[] D)
        {
            for (int i = 0; i < A.Length; i++)
            {

                if (i == 0)
                    A[i] = D[i];

                // Note that A[0] or D[0] decides 
                // values of rest of the elements. 
                else
                    A[i] = D[i] + A[i - 1];

                Console.Write(A[i] + " ");
            }

            Console.WriteLine();

            return 0;
        }

        internal void Execute()
        {
            // Array to be updated 
            int[] A = { 10, 5, 20, 40 };
            int n = A.Length;
            // Create and fill difference Array 
            // We use one extra space because 
            // update(l, r, x) updates D[r+1] 
            int[] D = new int[n + 1];
            initializeDiffArray(A, D);

            // After below update(l, r, x), the 
            // elements should become 20, 15, 20, 40 
            update(D, 0, 1, 10);
            printArray(A, D);

            // After below updates, the 
            // array sho    uld become 30, 35, 70, 60 
            update(D, 1, 3, 20);
            update(D, 2, 2, 30);

            printArray(A, D);
        }
    }
}
