using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscourseDotNet.Response.Get.Models;
using Newtonsoft.Json;

namespace DiscourseDotNet.Response.Get
{
    public class GetUserModel
    {

        [JsonProperty("user_badges")]
        public List<UserBadge> UserBadges { get; set; }

        [JsonProperty("badges")]
        public List<Badge> Badges { get; set; }

        [JsonProperty("badge_types")]
        public List<BadgeType> BadgeTypes { get; set; }

        [JsonProperty("users")]
        public List<BasicUserInfo> Users { get; set; }

        [JsonProperty("topics")]
        public List<Topic> Topics { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
