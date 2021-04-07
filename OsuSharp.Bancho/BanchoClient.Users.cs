using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OsuSharp.Bancho
{
    public partial class BanchoClient
    {
        /// <summary>
        /// Retrieves general user information
        /// </summary>
        /// <param name="eventDays">Max number of days between now and last event date</param>
        public async Task<User> GetUser(uint userId, Ruleset mode = Ruleset.Standart, byte eventDays = 1)
        {
            var users = await Call<User[]>("api/get_user", new Dictionary<string, string>
            {
                { "u", userId.ToString() },
                { "m", ((byte)mode).ToString() },
                { "type", "id" },
                { "event_days", eventDays.ToString() }
            });

            return users[0];
        }

        /// <summary>
        /// Retrieves general user information
        /// </summary>
        /// <param name="eventDays">Max number of days between now and last event date</param>
        public async Task<User> GetUser(string username, Ruleset mode = Ruleset.Standart, byte eventDays = 1)
        {
            var users = await Call<User[]>("api/get_user", new Dictionary<string, string>
            {
                { "u", username },
                { "m", ((byte)mode).ToString() },
                { "type", "string" },
                { "event_days", eventDays.ToString() }
            });

            return users[0];
        }

        /// <summary>
        /// Retrieves user profile image
        /// </summary>
        public async Task<Stream> GetUserProfileImage(uint userId)
        {
            return await GetContent("http://s.ppy.sh/a/" + userId);
        }
    }
}
