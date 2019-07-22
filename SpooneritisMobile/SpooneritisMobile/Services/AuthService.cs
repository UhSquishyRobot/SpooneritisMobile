using Newtonsoft.Json;
using SpooneritisMobile.Helpers;
using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    class AuthService : IAuthService
    {
        private static readonly string _apiConnection = "users/authenticate";

        private readonly ISettingsProvider _settings;
        private readonly IBaseApiAccessor _baseApiAccessor;

        public AuthService(ISettingsProvider settings, IBaseApiAccessor baseApiAccessor)
        {
            _settings = settings;
            _baseApiAccessor = baseApiAccessor;
        }

        public async Task<HttpResponseMessage> Authenticate(User user)
        {
            var response = await _baseApiAccessor.PostJson(_apiConnection, user);

            if (response.IsSuccessStatusCode)
            {
                var authJson = await response.Content.ReadAsStringAsync();

                AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(authJson);

                _settings.SetItem(SettingTypes.Jwt, authResponse.Token);
                _settings.SetItem(SettingTypes.UserId, authResponse.User.Id);
            }

            return response;
        }
    }
}
