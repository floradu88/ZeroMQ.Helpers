using NUnit.Framework;
using ZeroMQ.Helpers.Interfaces;
using ZeroMQ.Helpers.Services;
using ZeroMQ.Helpers.Wrappers;

namespace ZeroMQ.Helpers.Tests
{
    [TestFixture]
    public class ContextWrapperTests
    {
        [Test]
        public void should_create_context()
        {
            //arrange
            const string address = "";
            IContext context = new ContextWrapper(address);
            //act 

            //assert
            Assert.That(context, Is.Not.Null);
        }

        [Test]
        public void should_create_context_with_predefined_zeromq_context()
        {
            //arrange
            const string address = "";
            ZContext zContext = new ZContext();
            IContext context = new ContextWrapper(zContext, address);
            //act 

            //assert
            Assert.That(context, Is.Not.Null);
        }
    }
}
