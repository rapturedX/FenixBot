using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get.Models
{
    [Serializable]
    public class User : BasicUserInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_posted_at")]
        public DateTime LastPostedAt { get; set; }

        [JsonProperty("last_seen_at")]
        public DateTime LastSeenAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("can_edit")]
        public bool CanEdit { get; set; }

        [JsonProperty("can_edit_username")]
        public bool CanEditUsername { get; set; }

        [JsonProperty("can_edit_email")]
        public bool CanEditEmail { get; set; }

        [JsonProperty("can_edit_name")]
        public bool CanEditName { get; set; }

        [JsonProperty("stats")]
        public List<Stat> Stats { get; set; }

        [JsonProperty("can_send_private_messages")]
        public bool CanSendPrivateMessages { get; set; }

        [JsonProperty("can_send_private_message_to_user")]
        public bool CanSendPrivateMessageToUser { get; set; }

        [JsonProperty("trust_level")]
        public int TrustLevel { get; set; }

        [JsonProperty("moderator")]
        public bool Moderator { get; set; }

        [JsonProperty("admin")]
        public bool Admin { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("badge_count")]
        public int BadgeCount { get; set; }

        [JsonProperty("custom_fields")]
        public object CustomFields { get; set; }

        [JsonProperty("pending_count")]
        public int PendingCount { get; set; }

        [JsonProperty("invited_by")]
        public BasicUserInfo InvitedBy { get; set; }

        [JsonProperty("custom_groups")]
        public List<object> CustomGroups { get; set; }

        [JsonProperty("featured_user_badge_ids")]
        public List<int> FeaturedUserBadgeIds { get; set; }

        [JsonProperty("card_badge")]
        public object CardBadge { get; set; }
    }

}
