namespace ZeroMQ.Helpers.Interfaces
{
    public interface IPubService
    {
        bool Initialized { get; }

        bool SendMessage(string topic, string message);
    }
}