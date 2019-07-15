using System.Net.Http;
using System.Threading.Tasks;
using SpooneritisMobile.Models;

namespace SpooneritisMobile.Services
{
    public interface IRiddleService
    {
        Task<HttpResponseMessage> CreateRiddle(Riddle riddle);
        Task<HttpResponseMessage> GetRiddles();
    }
}
