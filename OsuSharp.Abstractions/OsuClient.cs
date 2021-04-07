using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
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
        public async Task<Stream> GetContent(string uri)
        {
            var response = await client.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync();
        }

        /// <summary>
        /// Calls an API method and returns response as UTF-8 string
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="DecoderFallbackException"/>
        /// <exception cref="HttpRequestException"/>
        public async virtual Task<string> Call(string methodPath, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrWhiteSpace(methodPath))
            {
                throw new ArgumentNullException(nameof(methodPath));
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var stream = await GetContent(RootDomain + '/' + methodPath + '?' + string.Join('&', parameters));

            return Encoding.UTF8.GetString((stream as MemoryStream).GetBuffer());
        }

        /// <summary>
        /// Calls an API method and returns response as specified .NET type
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="DecoderFallbackException"/>
        /// <exception cref="HttpRequestException"/>
        public async Task<TResult> Call<TResult>(string methodPath, IDictionary<string, string> parameters)
        {
            return JsonConvert.DeserializeObject<TResult>(await Call(methodPath, parameters));
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
