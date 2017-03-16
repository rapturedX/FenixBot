using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Post.Models
{
    public class CreatedPost
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_template")]
        public string AvatarTemplate { get; set; }

        [JsonProperty("uploaded_avatar_id")]
        public object UploadedAvatarId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("cooked")]
        public string Cooked { get; set; }

        [JsonProperty("post_number")]
        public int PostNumber { get; set; }

        [JsonProperty("post_type")]
        public int PostType { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("like_count")]
        public int LikeCount { get; set; }

        [JsonProperty("reply_count")]
        public int ReplyCount { get; set; }

        [JsonProperty("reply_to_post_number")]
        public object ReplyToPostNumber { get; set; }

        [JsonProperty("quote_count")]
        public int QuoteCount { get; set; }

        [JsonProperty("avg_time")]
        public object AvgTime { get; set; }

        [JsonProperty("incoming_link_count")]
        public int IncomingLinkCount { get; set; }

        [JsonProperty("reads")]
        public int Reads { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("yours")]
        public bool Yours { get; set; }

        [JsonProperty("topic_id")]
        public int TopicId { get; set; }

        [JsonProperty("topic_slug")]
        public string TopicSlug { get; set; }

        [JsonProperty("display_username")]
        public string DisplayUsername { get; set; }

        [JsonProperty("primary_group_name")]
        public object PrimaryGroupName { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("can_edit")]
        public bool CanEdit { get; set; }

        [JsonProperty("can_delete")]
        public bool CanDelete { get; set; }

        [JsonProperty("can_recover")]
        public bool CanRecover { get; set; }

        [JsonProperty("user_title")]
        public object UserTitle { get; set; }

        [JsonProperty("actions_summary")]
        public List<ActionsSummary> ActionsSummary { get; set; }

        [JsonProperty("moderator")]
        public bool Moderator { get; set; }

        [JsonProperty("admin")]
        public bool Admin { get; set; }

        [JsonProperty("staff")]
        public bool Staff { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("draft_sequence")]
        public int DraftSequence { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("hidden_reason_id")]
        public object HiddenReasonId { get; set; }

        [JsonProperty("trust_level")]
        public int TrustLevel { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("user_deleted")]
        public bool UserDeleted { get; set; }

        [JsonProperty("edit_reason")]
        public object EditReason { get; set; }

        [JsonProperty("can_view_edit_history")]
        public bool CanViewEditHistory { get; set; }

        [JsonProperty("wiki")]
        public bool Wiki { get; set; }
    }
}