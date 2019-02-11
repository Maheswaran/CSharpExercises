using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_Exercise
{
    internal class StackOperations
    {
       public Stack<char> stck = new Stack<char>();

        internal StackOperations()
        { }

        internal void push(char c)
        {
            stck.Push(c);
        }

        internal char pop(char c)
        {
            return stck.Pop();
        }
    }
}
