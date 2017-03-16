using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get.Models
{
    public class CategoryList
    {
        [JsonProperty("can_create_category")]
        public bool CanCreateCategory { get; set; }

        [JsonProperty("can_create_topic")]
        public bool CanCreateTopic { get; set; }

        [JsonProperty("draft")]
        public object Draft { get; set; }

        [JsonProperty("draft_key")]
        public string DraftKey { get; set; }

        [JsonProperty("draft_sequence")]
        public object DraftSequence { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }
    }
}