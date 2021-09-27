using YperConnector.Abstract;
using YperConnector.Concrete;

namespace YperConnector
{
    public class YperApi
    {
        private readonly WebClient _client;
        private readonly Authenticator _authenticator;
        private static string _proId;

        private IBooking _booking;
        public IBooking Booking => _booking ?? (_booking = new Booking(_proId, _client));

        public static YperApi Initialize(Environment environment, string clientId, string clientSecret, string proId, string proSecret)
        {
            _proId = proId;
            return new YperApi(environment, clientId, clientSecret, proId, proSecret);
        }

        private YperApi(Environment environment, string clientId, string clientSecret, string proId, string proSecret)
        {
            _authenticator = new Authenticator(environment, clientId, clientSecret, proId, proSecret);
            _client = new WebClient(environment);
            _client.SetAuthorization(_authenticator.GetAccessToken().Result);
        }

    }
}
