namespace ZeroMQ.Helpers.Interfaces
{
    public interface ISubService
    {
        bool Initialized { get; }

        bool Subscribe(string topic);
    }
}