namespace ZeroMQ.Helpers.Interfaces
{
    public interface ISubService
    {
        bool Initialized { get; }

        ZSocket Subscribe(string topic);

        string ReceiveMessage();
    }
}