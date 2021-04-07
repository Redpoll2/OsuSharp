using System.IO;
using System.Threading.Tasks;

namespace OsuSharp.Bancho
{
    public interface IBanchoClient
    {
        Task<User> GetUser(uint userId, Ruleset mode, byte eventDays);
        Task<User> GetUser(string username, Ruleset mode, byte eventDays);
        Task<Stream> GetUserProfileImage(uint userId);
    }
}
