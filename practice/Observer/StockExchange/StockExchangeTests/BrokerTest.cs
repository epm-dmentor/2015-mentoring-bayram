using NUnit.Framework;

namespace StockExchangeTests
{
    [TestFixture]
    public class BrokerTest
    {
        [Test]
        public void BrokerShouldReceiveEvent()
        {
            var expected= 10;
            var actual = 10;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
