using Newtonsoft.Json;

namespace SpooneritisMobile.Models
{
    class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
