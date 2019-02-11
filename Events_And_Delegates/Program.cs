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
            MobileClientApp mobileClientApp = new MobileClientApp();
            BackGroundProcessApp backGroundProcessApp = new BackGroundProcessApp();
            WebServiceAPP webServiceAPP = new WebServiceAPP();
            
            obj.OrderProcessStarted += new OrderProcess.ProcessStarted(mobileClientApp.GetStatus);
            obj.OrderProcessStarted += new OrderProcess.ProcessStarted(backGroundProcessApp.GetStatus);
            obj.OrderProcessStarted += new OrderProcess.ProcessStarted(webServiceAPP.GetStatus);
            obj.OrderProcessStarted += delegate (OrderInfo info)
            {
                Console.WriteLine(info.status);
                Console.WriteLine("This is anonymous method sample");
            };

            //obj.OrderProcessStarted = null;

            obj.OrderProcessCompleted += mobileClientApp.GetStatus;
            obj.OrderProcessCompleted += backGroundProcessApp.GetStatus;
            obj.OrderProcessCompleted += webServiceAPP.GetStatus;
            obj.OrderProcessCompleted += delegate (object sender, OrderInfoArgs args)
            {
                Console.WriteLine(args.orderInfo.status);
                Console.WriteLine("This is anonymous method sample");
            };
            
            obj.StarProcess(orderDetail);
            
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
