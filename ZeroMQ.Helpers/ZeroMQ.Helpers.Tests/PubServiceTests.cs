using System;
using NUnit.Framework;
using ZeroMQ.Helpers.Interfaces;
using ZeroMQ.Helpers.Services;
using ZeroMQ.Helpers.Wrappers;

namespace ZeroMQ.Helpers.Tests
{
    [TestFixture]
    public class PubServiceTests
    {
        private static readonly string Address = "tcp://127.0.0.1:8081";
        private ContextWrapper _context;
        private IPubService _pubService;

        [SetUp]
        public void Setup()
        {
            _context = new ContextWrapper(Address);
            _pubService = new PubService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            ((IDisposable)_pubService).Dispose();
        }

        [Test]
        public void should_create_service_when_I_want_to_publish_events()
        {
            //arrange
            _pubService = new PubService(new ContextWrapper(_context.Address));
            //act 

            //assert
            Assert.That(_pubService, Is.Not.Null);
        }

        [Test]
        public void should_create_service_with_desired_context_when_I_want_to_publish_events()
        {
            //arrange
            _pubService = new PubService(new ContextWrapper(_context.Context, _context.Address));
            //act 

            //assert
            Assert.That(_pubService, Is.Not.Null);
        }

        [Test]
        public void should_create_pub_service_with_subscription_when_I_want_to_publish_events_to_a_queue()
        {
            //arrange

            //act 

            //assert
            Assert.That(_pubService.Initialized, Is.True);
        }
    }
}
