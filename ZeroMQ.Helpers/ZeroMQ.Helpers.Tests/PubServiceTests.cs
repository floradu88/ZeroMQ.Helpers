using NUnit.Framework;
using ZeroMQ.Helpers.Interfaces;
using ZeroMQ.Helpers.Services;
using ZeroMQ.Helpers.Wrappers;

namespace ZeroMQ.Helpers.Tests
{
    [TestFixture]
    public class PubServiceTests
    {
        [Test]
        public void should_create_service_when_I_want_to_publish_events()
        {
            //arrange
            const string address = "";
            IContext context = new ContextWrapper(address);
            IPubService pubService = new PubService(context);

            //act 

            //assert
            Assert.That(pubService, Is.Not.Null);
        }

        [Test]
        public void should_create_service_with_desired_context_when_I_want_to_publish_events()
        {
            //arrange
            const string address = "";
            IContext context = new ContextWrapper(new ZContext(), address);
            IPubService pubService = new PubService(context);

            //act 

            //assert
            Assert.That(pubService, Is.Not.Null);
        }
    }
}
