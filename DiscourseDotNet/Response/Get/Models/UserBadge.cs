using System;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get.Models
{
    public class UserBadge
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("granted_at")]
        public DateTime GrantedAt { get; set; }

        [JsonProperty("badge_id")]
        public int BadgeId { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("granted_by_id")]
        public int GrantedById { get; set; }

        [JsonProperty("post_id")]
        public int? PostId { get; set; }

        [JsonProperty("post_number")]
        public int? PostNumber { get; set; }

        [JsonProperty("topic_id")]
        public int? TopicId { get; set; }
    }
}