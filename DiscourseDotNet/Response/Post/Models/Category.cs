using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Post.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("text_color")]
        public string TextColor { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("topic_count")]
        public int TopicCount { get; set; }

        [JsonProperty("post_count")]
        public int PostCount { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("description_text")]
        public object DescriptionText { get; set; }

        [JsonProperty("topic_url")]
        public string TopicUrl { get; set; }

        [JsonProperty("read_restricted")]
        public bool ReadRestricted { get; set; }

        [JsonProperty("permission")]
        public object Permission { get; set; }

        [JsonProperty("notification_level")]
        public object NotificationLevel { get; set; }

        [JsonProperty("logo_url")]
        public object LogoUrl { get; set; }

        [JsonProperty("background_url")]
        public object BackgroundUrl { get; set; }

        [JsonProperty("can_edit")]
        public bool CanEdit { get; set; }

        [JsonProperty("available_groups")]
        public List<string> AvailableGroups { get; set; }

        [JsonProperty("auto_close_hours")]
        public object AutoCloseHours { get; set; }

        [JsonProperty("auto_close_based_on_last_post")]
        public bool AutoCloseBasedOnLastPost { get; set; }

        [JsonProperty("group_permissions")]
        public List<GroupPermission> GroupPermissions { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("email_in")]
        public object EmailIn { get; set; }

        [JsonProperty("email_in_allow_strangers")]
        public bool EmailInAllowStrangers { get; set; }

        [JsonProperty("can_delete")]
        public bool CanDelete { get; set; }

        [JsonProperty("cannot_delete_reason")]
        public object CannotDeleteReason { get; set; }

        [JsonProperty("allow_badges")]
        public bool AllowBadges { get; set; }

        [JsonProperty("custom_fields")]
        public object CustomFields { get; set; }
    }
}