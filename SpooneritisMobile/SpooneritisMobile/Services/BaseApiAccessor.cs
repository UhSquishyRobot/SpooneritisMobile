using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using SpooneritisMobile.Helpers;

namespace SpooneritisMobile.Services
{
    public abstract class BaseApiAccessor
    {
        private static readonly string _baseUri = "http://10.0.2.2:3000/";
        private static readonly HttpClient _client = new HttpClient();

        public BaseApiAccessor()
        {
        }

        protected static Task<HttpResponseMessage> PostJson<T>(string url, T obj)
        {
            StringContent json = JsonEncode(obj);

            var jwt = Settings.Jwt;

            if (!string.IsNullOrEmpty(jwt))
            {
                json.Headers.Add("Authorization", "Bearer " + Settings.Jwt);
            }

            return _client.PostAsync(_baseUri + url, json);
        }

        protected static Task<HttpResponseMessage> GetJson(string url)
        {
            var jwt = Settings.Jwt;

            if (!string.IsNullOrEmpty(jwt))
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Settings.Jwt);
            }

            return _client.GetAsync(_baseUri + url);
        }

        private static StringContent JsonEncode<T>(T obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);

            return new StringContent(serialized, Encoding.UTF8, "application/json");
        }
    }
}
