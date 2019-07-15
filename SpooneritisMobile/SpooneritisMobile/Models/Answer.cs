using Newtonsoft.Json;

namespace SpooneritisMobile.Services
{
    public class Answer
    {
        [JsonProperty("solver")]
        public string Solver { get; set; }

        [JsonProperty("riddle")]
        public string Riddle { get; set; }
    }
}
