using System;
using System.Collections.Generic;
using System.Text;

namespace Events_And_Delegates
{
    public  class OrderProcess
    {
        private OrderInfo orderInfo;
        public void StarProcess(OrderInfo order)
        {
            this.orderInfo = order;
            //do some stuff...
            this.orderInfo.status = new Random().Next();

            foreach (ProcessCompleted del in OrderProcessCompleted.GetInvocationList())
            {
                del.Invoke(this.orderInfo);
            }
        }

        public delegate void ProcessCompleted(OrderInfo info);
        public ProcessCompleted OrderProcessCompleted;
    }
    
    public class MobileClientApp
    {     
        public void GetStatus(OrderInfo info)
        {
            Console.WriteLine(info.status);
            Console.WriteLine("From mobile client app"); ;
        }
    }

    public class BackGroundProcessApp
    {
        public void GetStatus(OrderInfo info)
        {
            Console.WriteLine(info.status);
            Console.WriteLine("From back ground process app"); ;
        }
    }

    public class WebServiceAPP
    {
        public void GetStatus(OrderInfo info)
        {
            Console.WriteLine(info.status);
            Console.WriteLine("From web service app"); ;
        }
    }
}
