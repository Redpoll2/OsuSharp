using System;
using System.Collections.Generic;
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
        /// Calls an API method and returns response as UTF-8 string
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="BanchoAuthorizationException"/>
        /// <exception cref="BanchoException"/>
        /// <exception cref="DecoderFallbackException"/>
        /// <exception cref="HttpRequestException"/>
        public async override Task<string> Call(string methodPath, IDictionary<string, string> parameters)
        {
            try
            {
                return await base.Call(methodPath, parameters);
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
    }
}
