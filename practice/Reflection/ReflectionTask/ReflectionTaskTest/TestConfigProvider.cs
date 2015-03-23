using NetMentoring.Epam.ReflectionTask;
using NUnit.Framework;

namespace ReflectionTaskTest
{
    [TestFixture]
    public class TestConfigProvider
    {
        [Test]
        public void GetSettings_ServiceSettingsType_ShouldReturnServiceSettings_()
        {
            var configprovider = new ConfigProviderProd {ConfigFile = @"../../ConfigFiles/Prod.txt"};
            var actual = configprovider.GetSettings<ServiceSettings>();
            var expected = new ServiceSettings {Connection = "Bayram", Service = "Test"};
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void GetSettings_ParsingSettingsType_ShouldReturnParsingSettings_()
        {
            var configprovider = new ConfigProviderProd {ConfigFile = @"../../ConfigFiles/Prod.txt"};
            var actual = configprovider.GetSettings<ParsingSettings>();
            var expected = new ParsingSettings { Location = "Ukraine",Options = "None",Url = "http://localhost"};
            Assert.That(expected, Is.EqualTo(actual));
        }

    }
}
