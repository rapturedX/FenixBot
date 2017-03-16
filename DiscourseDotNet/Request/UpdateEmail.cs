using Newtonsoft.Json;

namespace DiscourseDotNet.Request
{
    internal class UpdateEmail : APIRequest
    {
        internal UpdateEmail()
        {
        }

        internal UpdateEmail(string email)
        {
            Email = email;
        }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}