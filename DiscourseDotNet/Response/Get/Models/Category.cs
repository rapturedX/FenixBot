using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get.Models
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
        public string Description { get; set; }

        [JsonProperty("description_text")]
        public string DescriptionText { get; set; }

        [JsonProperty("topic_url")]
        public string TopicUrl { get; set; }

        [JsonProperty("read_restricted")]
        public bool ReadRestricted { get; set; }

        [JsonProperty("permission")]
        public object Permission { get; set; }

        [JsonProperty("notification_level")]
        public object NotificationLevel { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("background_url")]
        public string BackgroundUrl { get; set; }

        [JsonProperty("topics_day")]
        public int TopicsDay { get; set; }

        [JsonProperty("topics_week")]
        public int TopicsWeek { get; set; }

        [JsonProperty("topics_month")]
        public int TopicsMonth { get; set; }

        [JsonProperty("topics_year")]
        public int TopicsYear { get; set; }

        [JsonProperty("posts_day")]
        public int PostsDay { get; set; }

        [JsonProperty("posts_week")]
        public int PostsWeek { get; set; }

        [JsonProperty("posts_month")]
        public int PostsMonth { get; set; }

        [JsonProperty("posts_year")]
        public int PostsYear { get; set; }

        [JsonProperty("description_excerpt")]
        public string DescriptionExcerpt { get; set; }

        [JsonProperty("subcategory_ids")]
        public List<int> SubcategoryIds { get; set; }

        [JsonProperty("featured_user_ids")]
        public List<int> FeaturedUserIds { get; set; }

        [JsonProperty("topics")]
        public List<Topic> Topics { get; set; }

        [JsonProperty("is_uncategorized")]
        public bool? IsUncategorized { get; set; }
    }
}