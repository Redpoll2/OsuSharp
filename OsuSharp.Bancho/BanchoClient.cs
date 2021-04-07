using System;
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

        /// <summary>
        /// Reads the HTTP content and returns the content as stream
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="BanchoAuthorizationException"/>
        /// <exception cref="BanchoException"/>
        /// <exception cref="HttpRequestException"/>
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

                    throw new BanchoException(ex.Message, ex);
                }
            }

            return await base.GetContent(uri);
        }
    }
}
