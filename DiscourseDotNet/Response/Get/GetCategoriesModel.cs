using System.Collections.Generic;
using DiscourseDotNet.Response.Get.Models;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get
{
    public class GetCategoriesModel
    {
        [JsonProperty("featured_users")]
        public List<FeaturedUser> FeaturedUsers { get; set; }

        [JsonProperty("category_list")]
        public CategoryList CategoryList { get; set; }
    }
}