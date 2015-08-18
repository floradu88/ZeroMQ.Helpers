namespace ZeroMQ.Helpers.Interfaces
{
    public interface IContext
    {
        ZContext Context { get; }

        string Address { get; }

        int TimeoutInMilliseconds { get; }
    }
}
