using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace SpooneritisMobile.Models
{
    public class Riddle
    {
        [JsonProperty("answer")]
        public IEnumerable<string> Answer;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("_id")]
        public string Id;

        [JsonProperty("author")]
        public string Author;

        public override string ToString()
        {
            return Description;
        }

        public bool Check(IEnumerable<string> answer)
        {
            return !answer.Except(Answer).Any() 
                && answer.Count() == Answer.Count();
        }
    }
}
