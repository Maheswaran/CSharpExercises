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

            try
            {
                this.orderInfo = order;                

                foreach (ProcessStarted del in OrderProcessStarted.GetInvocationList())
                {
                    del.Invoke(this.orderInfo);
                }
                //do some stuff...

                this.orderInfo.status = ProcessStatus.Started;                
            }
            catch (Exception)
            {
                orderInfo.status = ProcessStatus.Failed;
            }
            finally
            {
                this.orderInfo.status = ProcessStatus.Completed;
                if (OrderProcessCompleted != null)
                    OrderProcessCompleted(this, new OrderInfoArgs() { orderInfo = this.orderInfo });
            }
        }

        public delegate void ProcessStarted(OrderInfo info);
        public ProcessStarted OrderProcessStarted;

        //public delegate void ProcessCompleted(OrderInfo info);
        public event EventHandler<OrderInfoArgs> OrderProcessCompleted;
    }

    public class OrderInfoArgs : EventArgs
        {
            public OrderInfo orderInfo;
        }
    
    public class MobileClientApp
    {     
        public void GetStatus(OrderInfo info)
        {
            Console.WriteLine(info.status);
            Console.WriteLine("From mobile client app"); ;
        }

        public void GetStatus(object sender, OrderInfoArgs args)
        {
            Console.WriteLine(args.orderInfo.status);
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
        public void GetStatus(object sender, OrderInfoArgs args)
        {
            Console.WriteLine(args.orderInfo.status);
            Console.WriteLine("From mobile client app"); ;
        }
    }

    public class WebServiceAPP
    {
        public void GetStatus(object sender, OrderInfoArgs args)
        {
            Console.WriteLine(args.orderInfo.status);
            Console.WriteLine("From mobile client app"); ;
        }

        public void GetStatus(OrderInfo info)
        {
            Console.WriteLine(info.status);
            Console.WriteLine("From web service app"); ;
        }
    }
}
