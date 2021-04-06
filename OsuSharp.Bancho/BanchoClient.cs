namespace OsuSharp.Bancho
{
    public class BanchoClient : OsuClient
    {
        private readonly string apiKey;

        public override string RootDomain => "https://osu.ppy.sh";

        public BanchoClient(string apiKey)
        {
            this.apiKey = apiKey;
        }
    }
}
