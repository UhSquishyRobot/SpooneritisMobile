using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    public interface IAuthService
    {
        Task<HttpResponseMessage> Authenticate(User user);
    }
}
