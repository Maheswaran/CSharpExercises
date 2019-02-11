using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MulitThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = TestMethodToCheckTaskResult();
            //task.Wait();
            Console.WriteLine("Msg from main thread");
            var ss = Console.ReadLine();
            Console.WriteLine(ss + "from main");
            Console.Read();
        }

        private static async Task TestMethodToCheckTaskResult()
        {
            await Task.Run(() => {
                Task.Delay(500000);
                Console.WriteLine("msg from different thread");
                Task.Delay(500000);                
                var testString = Console.ReadLine();
                Console.WriteLine(testString + "from task");
            });            
        }
    }    
}
