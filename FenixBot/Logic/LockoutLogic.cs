using System.Linq;
using System.Threading.Tasks;
using Discord;
using FenixBot.Logic.Wrappers;

namespace FenixBot.Logic
{
    public class LockoutLogic
    {
        private const string Region = "Lockout";
        private static Client _apiClient;
        private static ConfigurationModel _configuration;

        public LockoutLogic(ConfigurationModel configuration)
        {
            _configuration = configuration;
            _apiClient = new Client(_configuration.BaseAPIUrl);
        }

        public async Task Handle(MessageEventArgs e)
        {
            // will be configurable later, adding nighthold heroic
            var lockouts = await _apiClient.ApiWarcraftGuildLockoutsByRealmByGuildByRaidIdGetAsync(_configuration.Realm, _configuration.Guild, 8025);

            if (lockouts.HeroicLockouts.Any())
            {
                await e.Channel.SendMessage("**SUMMARY OF HEROIC NIGHTHOLD LOCKOUTS**");

                foreach (var lockedCharacter in lockouts.HeroicLockouts)
                {
                    var text = string.Format("*{0}*\n", lockedCharacter.Name);
                    text += string.Format("`{0}`\n", string.Join(", ", lockedCharacter.Bosses));

                    await e.Channel.SendMessage(text);
                }
            }
            else
            {
                await e.Channel.SendMessage("There are no current lockouts.");
            }
        }
    }
}
