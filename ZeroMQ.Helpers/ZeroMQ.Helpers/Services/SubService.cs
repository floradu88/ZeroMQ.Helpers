using System;
using System.Threading;
using ZeroMQ.Helpers.Interfaces;
using ZeroMQ.Helpers.Wrappers;

namespace ZeroMQ.Helpers.Services
{
    public class SubService : ISubService, IDisposable
    {
        private readonly ZSocket _subscriber;
        private readonly IContext _context;
        private string _message = null;

        public SubService(IContext context)
        {
            _context = context;
            _subscriber = new ZSocket(_context.Context, ZSocketType.SUB);
            Initialized = true;
            try
            {
                _subscriber.Connect(_context.Address);
            }
            catch (Exception e)
            {
                Initialized = false;
            }
        }

        public bool Initialized { get; private set; }

        public void Dispose()
        {
            try
            {
                _subscriber.Disconnect(_context.Address);
                _subscriber.Dispose();
            }
            catch
            {
            }
        }

        public ZSocket Subscribe(string topic)
        {
            try
            {
                _subscriber.Subscribe(topic);
                return _subscriber;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string ReceiveMessage()
        {
            var serverThread = new Thread(StartAwaitReceiveMessage);
            serverThread.Start();

            serverThread.Join(_context.TimeoutInMilliseconds);
            return _message;
        }

        private void StartAwaitReceiveMessage()
        {
            using (ZMessage message = _subscriber.ReceiveMessage())
            {
                // Read envelope with address
                string address = message[0].ReadString();

                // Read message contents
                _message = message[1].ReadString();
            }
        }
    }
}