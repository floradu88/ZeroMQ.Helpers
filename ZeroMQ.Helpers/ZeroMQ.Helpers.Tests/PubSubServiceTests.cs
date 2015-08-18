using System;
using NUnit.Framework;
using ZeroMQ.Helpers.Interfaces;
using ZeroMQ.Helpers.Services;
using ZeroMQ.Helpers.Wrappers;

namespace ZeroMQ.Helpers.Tests
{
    [TestFixture]
    public class PubSubServiceTests
    {
        private static readonly string Address = "tcp://127.0.0.1:8081";
        private ContextWrapper _context;
        private ISubService _subService;
        private IPubService _pubService;

        [SetUp]
        public void Setup()
        {
            _context = new ContextWrapper(Address);
            _subService = new SubService(_context);
            _pubService = new PubService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            ((IDisposable)_subService).Dispose();
            ((IDisposable)_pubService).Dispose();
        }

        [Test]
        public void should_be_able_to_subscribe_with_topic_when_I_use_a_pub_and_sub_service()
        {
            //arrange
            string topic = "topicA";
            string message = "messageA";

            //act 
            ZSocket result = _subService.Subscribe(topic);

            //act 
            var result2 = _pubService.SendMessage(topic, message);

            //assert
            string actualMessage = ;
            Assert.That(actualMessage, Is.EqualTo(message));
        }
    }
}
