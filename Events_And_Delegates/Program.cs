using Events_And_Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Events_And_Delegates.VideoEncoder;

namespace MulitThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //DelegateAndEventCodeSample();
            DelegateCodeSample();
            Console.Read();
        }

        public static void DelegateCodeSample()
        {
            OrderInfo orderDetail = new OrderInfo() { orderid = 5678 };
            OrderProcess obj = new OrderProcess();
            obj.OrderProcessCompleted += new OrderProcess.ProcessCompleted(new MobileClientApp().GetStatus);
            obj.OrderProcessCompleted += new OrderProcess.ProcessCompleted(new BackGroundProcessApp().GetStatus);
            obj.OrderProcessCompleted += new OrderProcess.ProcessCompleted(new WebServiceAPP().GetStatus);
            obj.StarProcess(orderDetail);            

            //OrderInfo orderDetail1 = new OrderInfo() { orderid = 5567 };
            //OrderProcess obj1 = new OrderProcess();            
            //obj1.OrderProcessCompleted += new OrderProcess.ProcessCompleted(new MobileClientApp().GetStatus);
            //obj1.StarProcess(orderDetail);
            obj.OrderProcessCompleted = null;
        }

        private static void DelegateAndEventCodeSample()
        {
            VideoEncoder encoder = new VideoEncoder();
            EmailMessage emailMessage = new EmailMessage();
            SMSMessage smsMessage = new SMSMessage();
            encoder.OnEncoded += emailMessage.Encoded;
            encoder.OnEncoded += smsMessage.Encoded;
            encoder.StartEncode();

            EncodingStatusHandler statushandler = new EncodingStatusHandler(encoder.CheckEncodingStatus);
            //statushandler.BeginInvoke()
        }
    }
}
