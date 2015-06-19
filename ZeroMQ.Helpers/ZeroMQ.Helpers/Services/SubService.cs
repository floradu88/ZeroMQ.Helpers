using System;
using ZeroMQ.Helpers.Interfaces;
using ZeroMQ.Helpers.Wrappers;

namespace ZeroMQ.Helpers.Services
{
    public class SubService : ISubService, IDisposable
    {
        private readonly ZSocket _subscriber;
        private readonly IContext _context;

        public SubService(IContext context)
        {
            _context = context;
            _subscriber = new ZSocket(_context.Context, ZSocketType.SUB)
            {
                Linger = TimeSpan.Zero,
                Immediate = true
            };
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

        public bool Subscribe(string topic)
        {
            try
            {
                _subscriber.Subscribe(topic);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}