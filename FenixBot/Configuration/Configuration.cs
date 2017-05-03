namespace FenixBot
{
    public static class Configuration
    {
        public static class Messages
        {
            // Guild, Recruitment URL
            public static string WelcomeMessage = "Thank you for joining the {0} discord server; if you are a raid team member. \nIf you'd like to join {0}, please apply at: {1}";

            public static class Attendance
            { 
                // Discord Name, Guild, Attendance Policy
                public static string PromptCharacter = "Greetings {0}, I am {1}'s Raid Attendance bot. You should only message me if you want to let the officers know you'll be late, leave early, or miss a scheduled raid date. Please review our attendance document at: {2} for information concerning our attendance policy. \n--------------------------------------------------\nWhat is your raiding toons name?";
                public static string PromptAttendanceMissLate = "Will you be late, miss, or leave the raid early?";
                public static string PromptDate = "What raid date are you filing this attendance notice for?";
                public static string PromptConfirm = "Type \"Confirm\" to submit your attendance notice, type \"Delete\" to delete or restart your attendance notice.";
                // WoW Character Name, AttendanceMissLate, Date
                public static string DisplaySummary = "Character Name: {0}\n" + "Attendance Info: {1}\n" + "Date: {2}";
            }
        }
    }

    public class ConfigurationModel
    {
        public string DiscordToken { get; set; }
        public string DiscourseKey { get; set; }
        public int DiscourseCategoryId { get; set; }
        // ReSharper disable once InconsistentNaming
        public string DiscourseBaseAPIUrl { get; set; }
        public string Realm { get; set; }
        public string Guild { get; set; }
        // ReSharper disable once InconsistentNaming
        public string BaseAPIUrl { get; set; }
        public string GuildWebsite { get; set; }
        public string GuildAttendancePolicy { get; set; }
        // ReSharper disable once InconsistentNaming
        public string GuildRecruitmentURL { get; set; }
    }
}
