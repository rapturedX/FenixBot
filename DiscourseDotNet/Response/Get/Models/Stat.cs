using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get.Models
{
    public class Stat
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("action_type")]
        public int ActionType { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}