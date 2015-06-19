using System;
using NUnit.Framework;
using ZeroMQ.Helpers.Interfaces;
using ZeroMQ.Helpers.Services;
using ZeroMQ.Helpers.Wrappers;

namespace ZeroMQ.Helpers.Tests
{
    [TestFixture]
    public class SubServiceTests
    {
        private static readonly string Address = "tcp://127.0.0.1:8081";
        private ContextWrapper _context;
        private ISubService _subService;

        [SetUp]
        public void Setup()
        {
            _context = new ContextWrapper(Address);
            _subService = new SubService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            ((IDisposable)_subService).Dispose();
        }

        [Test]
        public void should_create_service_when_I_want_to_receive_events()
        {
            //arrange
            _subService = new SubService(new ContextWrapper(_context.Address));
            //act 

            //assert
            Assert.That(_subService, Is.Not.Null);
        }

        [Test]
        public void should_create_service_with_desired_context_when_I_want_to_receive_events()
        {
            //arrange
            _subService = new SubService(new ContextWrapper(_context.Context, _context.Address));
            //act 

            //assert
            Assert.That(_subService, Is.Not.Null);
        }

        [Test]
        public void should_create_pub_service_with_subscription_when_I_want_to_receive_events_from_a_queue()
        {
            //arrange

            //act 

            //assert
            Assert.That(_subService.Initialized, Is.True);
        }

        [Test]
        public void should_receive_message_with_topic_when_I_use_a_sub_service()
        {
            //arrange
            string topic = "topicA";

            //act 
            bool result = _subService.Subscribe(topic);

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void should_not_receive_message_for_topic_when_I_use_a_sub_service_and_topic_is_null()
        {
            //arrange
            string topic = null;

            //act 
            bool result = _subService.Subscribe(topic);

            //assert
            Assert.That(result, Is.False);
        }
    }
}
