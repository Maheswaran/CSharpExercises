using System;

namespace Events_And_Delegates
{
    public class VideoEncoder
    {

        //public delegate void EncodedHandler(Object obj, EventArgs args);
        //public event EncodedHandler OnEncoded;
        //public event EventHandler OnEncoded;
        public event EventHandler<VideoEventArgs> OnEncoded;
       
        public void StartEncode()
        {
            Console.WriteLine("Encode starts..");

            if (OnEncoded != null)
                OnEncoded(this, new VideoEventArgs() { VideoTitle = "The Last Ship" });
            else
                Console.WriteLine("No subscribers attached..");
        }

        public int CheckEncodingStatus()
        {
            return 1;
        }
    }

    public delegate int EncodingStatusHandler();

    public class VideoEventArgs : EventArgs
    {
        public string VideoTitle { get; set; }
    }

    public class EmailMessage
    {
        public void Encoded(Object obj, VideoEventArgs args)
        {
            Console.WriteLine("Encoding finished for the video " + args.VideoTitle);
            Console.WriteLine("Sending mail....");
        }
    }

    public class SMSMessage
    {
        public void Encoded(Object obj, VideoEventArgs args)
        {
            Console.WriteLine("Encoding finished for the video " + args.VideoTitle);
            Console.WriteLine("Sending sms....");
        }
    }
}
