using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_Exercise
{
    public class QueueOperations
    {
        Queue<char> queueObject = new Queue<char>();

        internal void enqeue(char c)
        {
            queueObject.Enqueue(c);            
        }

        private char dequeue()
        {
            return queueObject.Dequeue();
        }
    }
}
