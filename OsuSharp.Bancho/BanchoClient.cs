using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async override Task<Stream> GetContent(string uri)
        {
            if (uri.StartsWith(RootDomain))
            {
                try
                {
                    return await base.GetContent(uri);
                }
                catch (HttpRequestException ex)
                {
                    // i hate it. netstandart dont have StatusCode property in this exception
                    if (ex.Message == "Response status code does not indicate success: 401 (Unauthorized).")
                    {
                        throw new BanchoAuthorizationException(apiKey);
                    }
                }
            }

            return await base.GetContent(uri);
        }
    }
}
