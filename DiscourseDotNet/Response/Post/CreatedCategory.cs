using DiscourseDotNet.Response.Post.Models;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Post
{
    internal class CreatedCategory
    {
        [JsonProperty("category")]
        public Category Category { get; set; }
    }
}