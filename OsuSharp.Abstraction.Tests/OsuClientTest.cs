using OsuSharp.Bancho;
using System.Net.Http;
using Xunit;

namespace OsuSharp.Abstraction.Tests
{
    public class OsuClientTest
    {
        private readonly OsuClient client = new BanchoClient("xd");

        ~OsuClientTest()
        {
            // bruh.......... disgusting
            client.Dispose();
        }

        [Fact]
        public async void GetContent()
        {
            var content = await client.GetContent("https://a.ppy.sh/9723320");

            Assert.True(content.Length > 0);
        }

        [Fact]
        public void GetContent_WrongKey()
        {
            Assert.ThrowsAsync<BanchoAuthorizationException>(() =>
            {
                return client.GetContent("https://osu.ppy.sh/api/get_user?k=xd&u=D_Redpoll");
            });
        }
    }
}
