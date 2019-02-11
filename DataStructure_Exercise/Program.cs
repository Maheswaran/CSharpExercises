using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            StackOperations obj1 = new StackOperations();
            string str = "This is test message";            
            Array.ForEach(str.Reverse().ToArray(), (x) => { obj1.stck.Push(x); });

            ArrayList lst = new ArrayList();            
        }
    }
}
