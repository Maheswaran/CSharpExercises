using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            int id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Thread id: " + id + ", Message: From mobile client app," + "Order status: " + info.status); 
        }

        public void GetStatus(object sender, OrderInfoArgs args)
        {
            Console.WriteLine("Message: From mobile client app. Order status: " + args.orderInfo.status); 
        }
    }

    public class BackGroundProcessApp
    {
        public void GetStatus(OrderInfo info)
        {
            int id = Thread.CurrentThread.ManagedThreadId;            
            Console.WriteLine("Thread id: " + id + ", Message: From back ground process app," + "Order status: " + info.status); 
        }
        public void GetStatus(object sender, OrderInfoArgs args)
        {
            Console.WriteLine("Message: From back ground process app. Order status: " + args.orderInfo.status); 
        }
    }

    public class WebServiceAPP
    {
        public void GetStatus(object sender, OrderInfoArgs args)
        {  
            Console.WriteLine("Message: From web service app. Order status: " + args.orderInfo.status);
        }

        public void GetStatus(OrderInfo info)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Thread id: " + id + ", Message: From web service app," + "Order status: " + info.status);
        }
    }
}
