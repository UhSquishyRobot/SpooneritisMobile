using System.Net.Http;
using System.Threading.Tasks;
using SpooneritisMobile.Models;

namespace SpooneritisMobile.Services
{
    public interface IUserService
    {
        Task<HttpResponseMessage> SignUp(User user);
    }
}