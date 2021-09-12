using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YperConnector;

namespace YperConnectorTests
{
    [TestClass]
    public class YperApiTests
    {
        private IConfiguration _config;

        public YperApiTests()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("UnitTestConfig.json")
                .Build();
        }

        [TestMethod]
        public void RetrieveBearerToken()
        {
            var clientId = _config.GetSection("credentials")["appId"];
            var clientSecret = _config.GetSection("credentials")["appSecret"];
            var environment = "production".Equals(_config.GetSection("credentials")["environment"]) ? Environment.Production : Environment.Sandbox;
            var apiInstance = YperApi.Initialize(environment, clientId, clientSecret);
        }
    }
}
