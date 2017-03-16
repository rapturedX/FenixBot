using System;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get.Models
{
    [Serializable]
    public class Poster
    {
        [JsonProperty("extras")]
        public string Extras { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}