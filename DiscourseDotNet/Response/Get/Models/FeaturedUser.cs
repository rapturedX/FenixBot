using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get.Models
{
    public class FeaturedUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("uploaded_avatar_id")]
        public int? UploadedAvatarId { get; set; }

        [JsonProperty("avatar_template")]
        public string AvatarTemplate { get; set; }
    }
}