using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using YperConnector.Models;
using YperConnector.Models.Token;

namespace YperConnector
{
    public class Authenticator
    {
        private readonly WebClient _webClient;
        private readonly Environment _environment;
        private OAuth2AccessToken _oAuth2AccessToken;

        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _proId;
        private readonly string _proSecret;

        public Authenticator(Environment environment, string apiClientId, string apiClientSecret, string apiProId, string apiProSecret)
        {
            _webClient = new WebClient(environment);
            _environment = environment;
            _clientId = apiClientId;
            _clientSecret = apiClientSecret;
            _proId = apiProId;
            _proSecret = apiProSecret;
        }

        public async Task<string> GetAccessToken()
        {
            if (_oAuth2AccessToken != null && !_oAuth2AccessToken.IsExpired)
                return _oAuth2AccessToken.AccessToken;

            _oAuth2AccessToken = await GetNewAccessTokenAsync().ConfigureAwait(false);
            return _oAuth2AccessToken.AccessToken;
        }

        public async Task<OAuth2AccessToken> GetNewAccessTokenAsync()
        {
            var tokenRequest = new TokenRequest
            {
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                ProId = _proId,
                ProSecret = _proSecret,
                GrantType = "pro_secret_token"
            };

            var response = await _webClient.PostAsync("/oauth/token", tokenRequest).ConfigureAwait(false);

            TokenSuccessResponse tokenResponse;
            if (response.IsSuccessStatusCode)
                tokenResponse = await response.Content.ReadAsAsync<TokenSuccessResponse>().ConfigureAwait(false);
            else
                throw new HttpRequestException($"Access token request failed with message: {response.Content.ReadAsAsync<ErrorResponse>().Result.Message}");

            return new OAuth2AccessToken()
            {
                AccessToken = tokenResponse.Result.AccessToken,
                ExpireDate = DateTime.UtcNow.AddMinutes(tokenResponse.Result.ExpiresIn),
                Scope = tokenResponse.Result.Scopes.FirstOrDefault(),
                TokenType = tokenResponse.Result.TokenType
            };
        }
    }
}
