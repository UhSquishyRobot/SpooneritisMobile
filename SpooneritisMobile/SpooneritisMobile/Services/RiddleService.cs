using Newtonsoft.Json;
using SpooneritisMobile.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    class RiddleService : IRiddleService
    {
        private static readonly string _apiConnection = "http://10.0.2.2:3000/riddles";
        private readonly HttpClient _client = new HttpClient();

        public RiddleService()
        {
        }

        public Task<HttpResponseMessage> CreateRiddle(Riddle riddle)
        {
            var riddleJson = JsonEncode(riddle);

            return _client.PostAsync(_apiConnection, riddleJson);
        }

        private static StringContent JsonEncode<T>(T obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);

            return new StringContent(serialized, Encoding.UTF8, "application/json");
        }
    }
}
