using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get.Models
{
    public class BasicTopicInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("fancy_title")]
        public string FancyTitle { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("posts_count")]
        public int PostsCount { get; set; }
    }
}