using Newtonsoft.Json;

namespace DiscourseDotNet.Request
{
    public class NewTopic : APIRequest
    {
        /// <summary>
        ///     Raw content that will be parsed by Discourse
        /// </summary>
        [JsonProperty("raw")]
        public string Content { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("category")]
        public int? CategoryID { get; set; }

        [JsonProperty("topic_id")]
        public int? TopicID { get; set; }

        [JsonProperty("is_warning")]
        public bool IsWarning { get; set; }

        [JsonProperty("archetype")]
        public string Archetype { get; set; }

        [JsonProperty("nested_post")]
        public bool NestedPost { get; set; }

        public NewTopic()
        {
            //Not sure what they are so set defaults
            IsWarning = false;
            Archetype = "regular";
            NestedPost = true;
        }

        public bool ShouldSerializeCategoryID()
        {
            return CategoryID.HasValue;
        }

        public bool ShouldSerializeTopicID()
        {
            return TopicID.HasValue;
        }
    }
}