using System;

namespace YperConnector
{
    public class YperApi
    {
        private readonly WebClient _client;
        private readonly Authenticator _authenticator;
        private readonly Environment _environment;

        public static YperApi Initialize(Environment environment, string clientId, string clientSecret, string proId, string proSecret)
        {
            return new YperApi(environment, clientId, clientSecret, proId, proSecret);
        }

        private YperApi(Environment environment, string clientId, string clientSecret, string proId, string proSecret)
        {
            _environment = environment;
            _authenticator = new Authenticator(environment, clientId, clientSecret, proId, proSecret);
            _client = new WebClient(environment);
            _client.SetAuthorization(_authenticator.GetAccessToken().Result);
        }

    }
}
