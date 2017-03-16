using System.Collections.Generic;
using DiscourseDotNet.Response.Get.Models;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get
{
    public class GetTopicsModel
    {
        [JsonProperty("users")]
        public List<BasicUserInfo> Users { get; set; }

        [JsonProperty("topic_list")]
        public TopicList TopicList { get; set; }
    }
}