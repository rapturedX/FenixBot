using DiscourseDotNet.Response.Post.Models;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Post
{
    public class CreatedTopic
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("post")]
        public CreatedPost Post { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}