using System;
using System.Configuration;
using System.Linq;
using Discord;
using DiscourseDotNet;
using DiscourseDotNet.Extensions;
using DiscourseDotNet.Request;
using FenixBot.Helpers;
using FenixBot.Logic;
using FenixBot.Models.Attendance;
using FenixBot.Wrappers;

namespace FenixBot
{
    public sealed class Bot
    {
        private static readonly DiscordClient _client = new DiscordClient();
        private static readonly Bot _instance = new Bot();
        private static string _token;
        private static int _discourseCategoryId;
        private static AuctionLogic _auctionLogic;
        private static DiscourseApi _discourseApi;
        private static Client _apiClient;
        private static string _guild;
        private static string _realm;

        private Bot()
        {
            Console.WriteLine("FenixBot: startup");
            _token = ConfigurationManager.AppSettings["DiscordToken"];
            // ReSharper disable once InconsistentNaming
            var baseAPIUrl = ConfigurationManager.AppSettings["BaseAPIUrl"];
            _guild = ConfigurationManager.AppSettings["Guild"];
            _realm = ConfigurationManager.AppSettings["Realm"];
            var discourseKey = ConfigurationManager.AppSettings["DiscourseKey"];
            var baseDiscourseUrl = ConfigurationManager.AppSettings["DiscourseBaseAPIUrl"];
            _discourseCategoryId = Convert.ToInt32(ConfigurationManager.AppSettings["DiscourseCategoryId"]);

            // ReSharper disable once InconsistentNaming
            _apiClient = new Client(baseAPIUrl);
            var client = new DiscordClient();
            _discourseApi = DiscourseApi.GetInstance(baseDiscourseUrl, discourseKey);
            _auctionLogic = new AuctionLogic(_realm, _guild, _apiClient);
        }

        public void Init()
        {
            _client.UserJoined += async (s, e) =>
            {
                var channel = await e.User.CreatePMChannel();
                await channel.SendMessage(
                    "Thank you for joining the Ad Lucem discord server; if you are a raid team member "
                    + "please PM \"Crazzak\" to request access to our #raiding channel. "
                    + "\nPUGs: Thank you for joining our discord server, you should have been provided with "
                    + "an invite link / code that will give you temporary access to our #raiding channel. "
                    + "If for some reason you are unable to join our raiding channel, please say so in "
                    + "raid chat. "
                    + "\nIf you'd like to learn more about Ad Lucem, please visit our website at: https://adlucemguild.com");
            };

            _client.MessageReceived += async (s, e) =>
            {
                if (!e.Message.IsAuthor)
                {
                    if (e.Channel.IsPrivate)
                    {
                        var key = string.Format("attendance_{0}", e.User.Id);
                        var region = "attendance";
                        var attendanceResponses = CacheHelper.GetCache<AttendanceCacheModel>(key, region);

                        if (attendanceResponses == null)
                        {
                            await e.Channel.SendMessage(
                                string.Format("Greetings {0}, I am Ad Lucem's Raid Attendance bot. You should only message me if you want to let the officers " +
                                              "know you'll be late, leave early, or miss a scheduled raid date. Please review our attendance document at: " +
                                              "https://forum.adlucemguild.com/t/attendance-policy/23/1 for information concerning our attendance policy. ",
                                               e.User.Name) + "\n--------------------------------------------------\nWhat is your raiding toons name?");

                            CacheHelper.Cache(key, region, new AttendanceCacheModel());
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(attendanceResponses.CharacterName))
                            {
                                attendanceResponses.CharacterName = e.Message.Text;
                                await e.Channel.SendMessage("Will you be late, miss, or leave the raid early?");
                                CacheHelper.Cache(key, region, new AttendanceCacheModel());
                            }
                            else if (string.IsNullOrEmpty(attendanceResponses.AttendanceInfo))
                            {
                                attendanceResponses.AttendanceInfo = e.Message.Text;
                                CacheHelper.Cache(key, region, new AttendanceCacheModel());
                                await e.Channel.SendMessage("What raid date are you filing this attendance notice for?");
                            }
                            else if(string.IsNullOrEmpty(attendanceResponses.RaidDate)) {
                                attendanceResponses.RaidDate = e.Message.Text;
                                CacheHelper.Cache(key, region, new AttendanceCacheModel());
                                await e.Channel.SendMessage(string.Format("Character Name: {0}\n" + "Attendance Info: {1}\n" + "Date: {2}", 
                                    attendanceResponses.CharacterName, attendanceResponses.AttendanceInfo, attendanceResponses.RaidDate));
                                await e.Channel.SendMessage("Type \"Confirm\" to submit your attendance notice, type \"Delete\" to delete or restart your attendance notice.");
                            }
                            else
                            {
                                if (e.Message.Text.Equals("Delete", StringComparison.OrdinalIgnoreCase))
                                {
                                    await e.Channel.SendMessage("Your responses have been cleared.");

                                    CacheHelper.Bust(key, region);
                                }
                                else if (e.Message.Text.Equals("Confirm", StringComparison.OrdinalIgnoreCase))
                                {
                                    var response = _discourseApi.PostTopic(new NewTopic()
                                    {
                                        Content = string.Format("Info: {0}\nDate:{1}\nPST Timestamp: {2}", attendanceResponses.AttendanceInfo, attendanceResponses.RaidDate, DateTime.UtcNow.AddHours(-7)),
                                        Title = string.Format("Attendance Issue for: {0} on {1}", attendanceResponses.CharacterName, attendanceResponses.RaidDate),
                                        CategoryID = _discourseCategoryId
                                    });

                                    if (!response.Success)
                                    {
                                        await e.Channel.SendMessage("An error has occured and your response was not recorded.");
                                    }
                                    else
                                    {
                                        await e.Channel.SendMessage("Your Notice of Attendance Issue has been recorded and submitted to our team of officers, thank you.");
                                    }

                                    CacheHelper.Bust(key, region);
                                }
                                else
                                {
                                    await e.Channel.SendMessage("INVALID RESPONSE!");
                                    await e.Channel.SendMessage(string.Format("Character Name: {0}\n" + "Attendance Info: {1}\n" + "Date: {2}", 
                                        attendanceResponses.CharacterName, attendanceResponses.AttendanceInfo, attendanceResponses.RaidDate));
                                    await e.Channel.SendMessage("Type \"Confirm\" to submit your attendance notice, type \"Delete\" to delete or restart your attendance " +
                                                                "notice.");
                                }
                            }
                        }
                    }
                    else
                    {
                        var message = e.Message.Text.Split(' ');
                        var command = message[0].ToLower();

                        switch (command)
                        {
                            case "!auction":
                                var itemId = e.Message.Text.ToLower().Replace("!auction ", "");
                                var response = await _auctionLogic.GetAuctionSummary(itemId);
                                await e.Channel.SendMessage(response);
                                break;
                            case "!lockouts":
                                // will be configurable later, adding nighthold heroic
                                var lockouts = await _apiClient.ApiWarcraftGuildLockoutsByRealmByGuildByRaidIdGetAsync(_realm, _guild, 8025);

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

                                break;
                            default:
                                break;
                        }
                    }
                }
            };

            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect(_token, TokenType.Bot);
            });
        }

        public static Bot Instance()
        {
            return _instance;
        }
    }
}
