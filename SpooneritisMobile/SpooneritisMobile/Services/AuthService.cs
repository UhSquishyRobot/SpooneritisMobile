using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    class AuthService : BaseApiAccessor, IAuthService
    {
        private static readonly string _apiConnection = "users/authenticate";

        public Task<HttpResponseMessage> Authenticate(User user)
        {
            return PostJson(_apiConnection, user);
        }
    }
}
