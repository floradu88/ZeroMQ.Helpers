using System;
using ZeroMQ.Helpers.Interfaces;
using ZeroMQ.Helpers.Wrappers;

namespace ZeroMQ.Helpers.Services
{
    public class PubService : IPubService, IDisposable
    {
        private readonly ZSocket _publisher;
        private IContext _context;

        public PubService(IContext context)
        {
            _context = context;
            _publisher = new ZSocket(_context.Context, ZSocketType.PUB)
            {
                Linger = TimeSpan.Zero,
                Immediate = true
            };
            Initialized = true;
            try
            {
                _publisher.Bind(_context.Address);
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
                _publisher.Disconnect(_context.Address);
                _publisher.Dispose();
            }
            catch
            {
            }
        }


        public bool SendMessage(string topic, string message)
        {
            using (var msg = new ZMessage())
            {
                try
                {
                    msg.Add(new ZFrame(topic));
                    msg.Add(new ZFrame(message));
                    _publisher.Send(msg);
                }
                catch 
                {
                    //exception logging
                    return false;
                }
            }
            return true;
        }
    }
}