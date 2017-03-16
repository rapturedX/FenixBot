using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get.Models
{
    public class Badge
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("grant_count")]
        public int GrantCount { get; set; }

        [JsonProperty("allow_title")]
        public bool AllowTitle { get; set; }

        [JsonProperty("multiple_grant")]
        public bool MultipleGrant { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("image")]
        public object Image { get; set; }

        [JsonProperty("listable")]
        public bool Listable { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("badge_grouping_id")]
        public int BadgeGroupingId { get; set; }

        [JsonProperty("system")]
        public bool System { get; set; }

        [JsonProperty("badge_type_id")]
        public int BadgeTypeId { get; set; }
    }
}