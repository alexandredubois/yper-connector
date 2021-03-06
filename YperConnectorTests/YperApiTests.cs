using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YperConnector;
using YperConnector.Models.Prebook.Request;

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
        public void RetrieveBearerToken_ReadValueFromConfig_NoExceptionRaised()
        {
            var apiInstance = GetYperApiInstance();
        }

        [TestMethod]
        public void Prebook_BasicRequestForTomorrow_Success()
        {
            string retailPointId = _config.GetSection("credentials")["defaultRetailPoint"];
            var apiInstance = GetYperApiInstance();
            var result = apiInstance.Booking.Prebook(GetDummyPrebookForTomorrow(retailPointId));

            var finalResult = result.Result;
            Assert.IsNotNull(finalResult);
            Assert.IsNotNull(finalResult.Data);
            Assert.IsNull(finalResult.Error);
            Assert.IsFalse(string.IsNullOrEmpty(finalResult.Data.Result.PrebookId));
        }

        [TestMethod]
        public void ValidatePrebook_BasicRequestForTomorrow_Success()
        {
            string retailPointId = _config.GetSection("credentials")["defaultRetailPoint"];
            var apiInstance = GetYperApiInstance();
            var prebookResult = apiInstance.Booking.Prebook(GetDummyPrebookForTomorrow(retailPointId));

            var prebookRequestSuccess = prebookResult.Result.Data;
            var result = apiInstance.Booking.ValidatePrebook(prebookRequestSuccess.Result.PrebookId).Result;
            Assert.IsNotNull(result);
            Assert.IsNull(result.Error);
            Assert.IsFalse(string.IsNullOrEmpty(result.Data.Result.MissionId));
        }

        private static PrebookRequest GetDummyPrebookForTomorrow(string retailPointId)
        {
            return new PrebookRequest
            {
                Order = new Order
                {
                    OrderId = Guid.NewGuid().ToString(),
                    TransportType = TransportType.bike //foot, bike, moto, car or break
                },
                DeliveryAddress = new DeliveryAddress
                {
                    FormattedAddress = "226 Cours de la Marne, 33800 BORDEAUX"
                },
                DeliveryStart = DateTime.Now.AddDays(1),
                DeliveryEnd = DateTime.Now.AddDays(1).AddHours(2),
                Receiver = new Receiver
                {
                    Email = "test@alexandredubois.com",
                    Firstname = "Alexandre",
                    Lastname = "Dubois",
                    Phone = "+33612345678",
                    Type = "user"
                },
                Sender = new Sender
                {
                    Type = "retailpoint",
                    Id = retailPointId
                },
                Comment = "This delivery contains a bottle of wine. Handle it carefully."
            };
        }

        private YperApi GetYperApiInstance()
        {
            var clientId = _config.GetSection("credentials")["appId"];
            var clientSecret = _config.GetSection("credentials")["appSecret"];
            var proId = _config.GetSection("credentials")["proId"];
            var proSecret = _config.GetSection("credentials")["proSecret"];
            var environment = "production".Equals(_config.GetSection("credentials")["environment"]) ? YperConnector.Environment.Production : YperConnector.Environment.Sandbox;
            return YperApi.Initialize(environment, clientId, clientSecret, proId, proSecret);
        }
    }
}
