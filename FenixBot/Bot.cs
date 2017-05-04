using System;
using System.Configuration;
using System.Reflection;
using Discord;
using FenixBot.Helpers;
using FenixBot.Logic;

namespace FenixBot
{
    public sealed class Bot
    {
        private static DiscordClient Client = new DiscordClient();
        private static readonly Bot BotInstance = new Bot();
        private static ConfigurationModel _configuration;
        private static AttendanceLogic _attendanceLogic;
        private static AuctionLogic _auctionLogic;
        private static LockoutLogic _lockoutLogic;

        private Bot()
        {
            Console.WriteLine("FenixBot: startup");

            _configuration = new ConfigurationModel
            {
                DiscordToken = ConfigurationManager.AppSettings["DiscordToken"],
                DiscourseBaseAPIUrl = ConfigurationManager.AppSettings["DiscourseBaseAPIUrl"],
                DiscourseCategoryId = Convert.ToInt32(ConfigurationManager.AppSettings["DiscourseCategoryId"]),
                DiscourseKey = ConfigurationManager.AppSettings["DiscourseKey"],
                Realm = ConfigurationManager.AppSettings["Realm"],
                Guild = ConfigurationManager.AppSettings["Guild"],
                BaseAPIUrl = ConfigurationManager.AppSettings["BaseAPIUrl"],
                GuildWebsite = ConfigurationManager.AppSettings["GuildWebsite"],
                GuildAttendancePolicy = ConfigurationManager.AppSettings["GuildAttendancePolicy"],
                GuildRecruitmentURL = ConfigurationManager.AppSettings["GuildRecruitmentURL"]
            };

            _attendanceLogic = new AttendanceLogic(_configuration);
            _auctionLogic = new AuctionLogic(_configuration);
            _lockoutLogic = new LockoutLogic(_configuration);
        }

        public void Init()
        {
            Client.UserJoined += async (s, e) =>
            {
                var channel = await e.User.CreatePMChannel();
                await channel.SendMessage(string.Format(Configuration.Messages.WelcomeMessage, _configuration.Guild, _configuration.GuildRecruitmentURL));
            };

            Client.MessageReceived += async (s, e) =>
            {
                if (!e.Message.IsAuthor)
                {
                    if (e.Channel.IsPrivate)
                    {
                        await _attendanceLogic.Handle(e);
                    }
                    else
                    {
                        var message = e.Message.Text.Split(' ');
                        var command = message[0].ToLower();

                        switch (command)
                        {
                            case "!auction":
                                await _auctionLogic.Handle(e);
                                break;
                            case "!lockouts":
                                await _lockoutLogic.Handle(e);
                                break;
                            case "!version":
                                await e.Channel.SendMessage(VersionHelper.GetFullAssemblyVersion());
                                break;
                            default:
                                break;
                        }
                    }
                }
            };

            Client.ExecuteAndWait(async () =>
            {
                await Client.Connect(_configuration.DiscordToken, TokenType.Bot);
            });
        }

        public static Bot Instance()
        {
            return BotInstance;
        }
    }
}
