using System.Collections.Generic;
using DiscourseDotNet.Lib;
using Newtonsoft.Json;

namespace DiscourseDotNet.Request
{
    public class NewCategory : APIRequest
    {
        [JsonProperty("parent_category_id")]
        public int? ParentCategoryID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("text_color")]
        public string TextColor { get; set; }

        [JsonProperty("permissions")]
        public Dictionary<string, Permission> Permissions { get; set; }

        [JsonProperty("auto_close_hours")]
        public int? AutoCloseHours { get; set; }

        [JsonProperty("auto_close_based_on_last_post")]
        public bool AutoCloseBasedOnLastPost { get; set; }

        [JsonProperty("allow_badges")]
        public bool AllowBadges { get; set; }

        public NewCategory()
        {
            Permissions = new Dictionary<string, Permission> {{"everyone", Permission.CreateReplySee}};
        }

        public void AddOrUpdatePermission(string name, Permission permissionLevel)
        {
            if(Permissions == null) Permissions = new Dictionary<string, Permission>();
            Permissions[name] = permissionLevel;
        }

        public bool ShouldSerializeParentCategoryID()
        {
            return ParentCategoryID.HasValue;
        }

        public bool ShouldSerializeAutoCloseHours()
        {
            return AutoCloseHours.HasValue;
        }
    }
}