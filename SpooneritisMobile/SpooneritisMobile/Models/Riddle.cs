using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpooneritisMobile.Models
{
    public class Riddle
    {
        [JsonProperty("answer")]
        public IEnumerable<string> Answer;

        [JsonProperty("description")]
        public string Description;
    }
}
