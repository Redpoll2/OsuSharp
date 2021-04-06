namespace OsuSharp.Bancho
{
    public class BanchoAuthorizationException : BanchoException
    {
        public string ApiKey { get; }

        public BanchoAuthorizationException(string apiKey) : base("Could not authorize with current api key.")
        {
            ApiKey = apiKey;
        }
    }
}
