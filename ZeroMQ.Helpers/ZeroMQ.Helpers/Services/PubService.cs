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
    }
}