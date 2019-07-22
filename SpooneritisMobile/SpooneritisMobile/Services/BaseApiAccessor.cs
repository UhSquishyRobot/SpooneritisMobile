using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using SpooneritisMobile.Helpers;

namespace SpooneritisMobile.Services
{
    public sealed class BaseApiAccessor : IBaseApiAccessor
    {
        private static readonly string _baseUri = "https://spooneritis.herokuapp.com/";
        private HttpClient _client;

        public BaseApiAccessor()
        {
            _client = new HttpClient();
        }

        public Task<HttpResponseMessage> PostJson<T>(string url, T obj)
        {
            StringContent json = JsonEncode(obj);

            MaybeAddAuth();

            return _client.PostAsync(_baseUri + url, json);
        }

        public Task<HttpResponseMessage> GetJson(string url)
        {
            MaybeAddAuth();

            return _client.GetAsync(_baseUri + url);
        }

        private void MaybeAddAuth()
        {
            var jwt = Settings.Jwt;

            if (!string.IsNullOrEmpty(jwt))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            }
        }

        private static StringContent JsonEncode<T>(T obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);

            return new StringContent(serialized, Encoding.UTF8, "application/json");
        }
    }
}
