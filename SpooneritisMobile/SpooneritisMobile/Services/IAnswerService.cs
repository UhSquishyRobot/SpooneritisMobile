using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    public interface IAnswerService
    {
        Task<HttpResponseMessage> CreateAnswer(Riddle riddle);
    }
}