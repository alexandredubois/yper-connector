namespace YperConnector
{
    public sealed class Environment
    {
        private const string betaUrl = "https://io.beta.yper.org";
        private const string productionUrl = "https://api.yper.io";

        public Environment(string url) => BaseUrl = url;

        public static Environment Sandbox => new Environment(betaUrl);
        public static Environment Production => new Environment(productionUrl);

        public string BaseUrl { get; }
    }
}
