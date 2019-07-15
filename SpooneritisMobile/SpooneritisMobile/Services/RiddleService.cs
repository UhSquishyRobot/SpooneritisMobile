using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    public class RiddleService : BaseApiAccessor, IRiddleService
    {
        private static readonly string _apiConnection = "riddles";

        public Task<HttpResponseMessage> CreateRiddle(Riddle riddle)
        {
            return PostJson(_apiConnection, riddle);
        }

        public Task<HttpResponseMessage> GetRiddles()
        {
            return GetJson(_apiConnection);
        }
    }
}
