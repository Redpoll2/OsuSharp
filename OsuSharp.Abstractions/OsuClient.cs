using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace OsuSharp
{
    public abstract class OsuClient : IDisposable
    {
        private readonly HttpClient client;

        public abstract string RootDomain { get; }

        public OsuClient()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Reads the HTTP content and returns the content as stream
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="HttpRequestException"/>
        public async virtual Task<Stream> GetContent(string uri)
        {
            var response = await client.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync();
        }

        /// <summary>
        /// Releases the unmanaged resources and disposes of the managed resources used by the <see cref="HttpClient"/>
        /// </summary>
        public void Dispose()
        {
            client.Dispose();
        }
    }
}
