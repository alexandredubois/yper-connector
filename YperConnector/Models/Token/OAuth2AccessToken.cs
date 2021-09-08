using System;

namespace YperConnector.Models.Token
{
    public class OAuth2AccessToken
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Scope { get; set; }
        public bool IsExpired { get { return ExpireDate < DateTime.UtcNow; } }
    }
}
