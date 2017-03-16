using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Post.Models
{
    public class ActionsSummary
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("can_act")]
        public bool CanAct { get; set; }

        [JsonProperty("can_defer_flags")]
        public bool? CanDeferFlags { get; set; }
    }
}