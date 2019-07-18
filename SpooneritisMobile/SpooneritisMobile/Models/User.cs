using Newtonsoft.Json;

namespace SpooneritisMobile.Models
{
    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
