using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get.Models
{
    public class BadgeType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sort_order")]
        public int SortOrder { get; set; }
    }
}