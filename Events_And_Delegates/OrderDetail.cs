namespace Events_And_Delegates
{
    public class OrderInfo
    {
        public int orderid;

        public ProcessStatus status;       
    }

    public enum ProcessStatus
    {
        Started,
        Failed,
        Completed
    }
}