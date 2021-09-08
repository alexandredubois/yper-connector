using System;

namespace YperConnector
{
    public class YperApi
    {
        private readonly WebClient _client;
        private readonly Authenticator _authenticator;
        private readonly Environment _environment;

        public static YperApi Initialize(Environment environment, string clientId, string clientSecret)
        {
            return new YperApi(environment, clientId, clientSecret);
        }

        private YperApi(Environment environment, string clientId, string clientSecret)
        {
            _environment = environment;
            _authenticator = new Authenticator(environment, clientId, clientSecret);
            _client = new WebClient(environment);
            _client.SetAuthorization(_authenticator.GetAccessToken().Result);
        }

    }
}
