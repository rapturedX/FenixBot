using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Discord;
using DiscourseDotNet;
using DiscourseDotNet.Extensions;
using DiscourseDotNet.Request;
using FenixBot.Helpers;
using FenixBot.Logic.Wrappers;
using FenixBot.Models.Attendance;

namespace FenixBot.Logic
{
    public class AttendanceLogic
    {
        private const string Region = "Attendance";
        private static Client _apiClient;
        private static DiscourseApi _discourseApiClient;
        private static ConfigurationModel _configuration;

        public AttendanceLogic(ConfigurationModel configuration)
        {
            _configuration = configuration;
            _apiClient = new Client(_configuration.BaseAPIUrl);
            _discourseApiClient = DiscourseApi.GetInstance(_configuration.DiscourseBaseAPIUrl, _configuration.DiscourseKey);
        }

        public async Task Handle(MessageEventArgs e)
        {
            var key = string.Format("attendance_{0}", e.User.Id);
            var attendanceResponses = CacheHelper.GetCache<AttendanceCacheModel>(key, Region);

            if (attendanceResponses == null)
            {
                await e.Channel.SendMessage(
                    string.Format(Configuration.Messages.Attendance.PromptCharacter, e.User.Name, _configuration.Guild, _configuration.GuildAttendancePolicy));

                CacheHelper.Cache(key, Region, new AttendanceCacheModel());
            }
            else
            {
                if (string.IsNullOrEmpty(attendanceResponses.CharacterName))
                {
                    attendanceResponses.CharacterName = e.Message.Text;
                    await e.Channel.SendMessage(Configuration.Messages.Attendance.PromptAttendanceMissLate);
                    CacheHelper.Cache(key, Region, new AttendanceCacheModel());
                }
                else if (string.IsNullOrEmpty(attendanceResponses.AttendanceInfo))
                {
                    attendanceResponses.AttendanceInfo = e.Message.Text;
                    CacheHelper.Cache(key, Region, new AttendanceCacheModel());
                    await e.Channel.SendMessage(Configuration.Messages.Attendance.PromptDate);
                }
                else if (string.IsNullOrEmpty(attendanceResponses.RaidDate))
                {
                    attendanceResponses.RaidDate = e.Message.Text;
                    CacheHelper.Cache(key, Region, new AttendanceCacheModel());
                    await e.Channel.SendMessage(string.Format(Configuration.Messages.Attendance.DisplaySummary,
                        attendanceResponses.CharacterName, attendanceResponses.AttendanceInfo, attendanceResponses.RaidDate));
                    await e.Channel.SendMessage(Configuration.Messages.Attendance.PromptConfirm);
                }
                else
                {
                    if (e.Message.Text.Equals("Delete", StringComparison.OrdinalIgnoreCase))
                    {
                        await e.Channel.SendMessage("Your responses have been cleared.");

                        CacheHelper.Bust(key, Region);
                    }
                    else if (e.Message.Text.Equals("Confirm", StringComparison.OrdinalIgnoreCase))
                    {
                        var response = _discourseApiClient.PostTopic(new NewTopic()
                        {
                            Content = string.Format(Configuration.Messages.Attendance.DisplaySummary, attendanceResponses.AttendanceInfo, attendanceResponses.RaidDate, DateTime.UtcNow.AddHours(-7)),
                            Title = string.Format("Attendance Issue for: {0} on {1}", attendanceResponses.CharacterName, attendanceResponses.RaidDate),
                            CategoryID = _configuration.DiscourseCategoryId
                        });

                        if (!response.Success)
                        {
                            await e.Channel.SendMessage("An error has occured and your response was not recorded.");
                        }
                        else
                        {
                            await e.Channel.SendMessage("Your Notice of Attendance Issue has been recorded and submitted to our team of officers, thank you.");
                        }

                        CacheHelper.Bust(key, Region);
                    }
                    else
                    {
                        await e.Channel.SendMessage("INVALID RESPONSE!");
                        await e.Channel.SendMessage(string.Format(Configuration.Messages.Attendance.DisplaySummary, attendanceResponses.CharacterName, attendanceResponses.AttendanceInfo, attendanceResponses.RaidDate));
                        await e.Channel.SendMessage(Configuration.Messages.Attendance.PromptConfirm);
                    }
                }
            }
        }
    }
}
