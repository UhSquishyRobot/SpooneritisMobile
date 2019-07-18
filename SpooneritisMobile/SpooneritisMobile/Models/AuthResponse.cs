using Newtonsoft.Json;

namespace SpooneritisMobile.Models
{
    class AuthResponse
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
