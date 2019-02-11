using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBenchApp
{
    class BinaryOperation
    {
        public List<int> ConvertToBinary(int n)
        {
            List<int> binaryValue = new List<int>();
            int q;
            
            while (n != 1)
            {
                q = n % 2;
                n = n / 2;

                if (n == 1)
                {
                    binaryValue.Add(q);
                    binaryValue.Add(n);                  
                }
                else
                    binaryValue.Add(q);
            }

            binaryValue.Reverse();

            return binaryValue;            
        }
    }
}
