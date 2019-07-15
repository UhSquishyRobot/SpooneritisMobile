using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    public class UserService : BaseApiAccessor, IUserService
    {
        private static readonly string _apiConnection = "users";

        public Task<HttpResponseMessage> SignUp(User user)
        {
            return PostJson(_apiConnection, user);
        }
    }
}
