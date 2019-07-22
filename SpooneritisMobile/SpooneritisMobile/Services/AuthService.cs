using Newtonsoft.Json;
using SpooneritisMobile.Helpers;
using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    class AuthService : BaseApiAccessor, IAuthService
    {
        private static readonly string _apiConnection = "users/authenticate";

        public async Task<HttpResponseMessage> Authenticate(User user)
        {
            var response = await PostJson(_apiConnection, user);

            if (response.IsSuccessStatusCode)
            {
                var authJson = await response.Content.ReadAsStringAsync();

                AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(authJson);

                Settings.Jwt = authResponse.Token;
                Settings.UserId = authResponse.User.Id;
            }

            return response;
        }
    }
}
