using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    public class UserService : IUserService
    {
        private static readonly string _apiConnection = "users";

        private readonly IBaseApiAccessor _baseApiAccessor;

        public UserService(IBaseApiAccessor baseApiAccessor)
        {
            _baseApiAccessor = baseApiAccessor;
        }

        public Task<HttpResponseMessage> SignUp(User user)
        {
            return _baseApiAccessor.PostJson(_apiConnection, user);
        }
    }
}
