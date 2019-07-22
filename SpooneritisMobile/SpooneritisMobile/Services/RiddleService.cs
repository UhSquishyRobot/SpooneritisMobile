using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    public class RiddleService : IRiddleService
    {
        private static readonly string _apiConnection = "riddles";

        private readonly IBaseApiAccessor _baseApiAccessor;

        public RiddleService(IBaseApiAccessor baseApiAccessor)
        {
            _baseApiAccessor = baseApiAccessor;
        }

        public Task<HttpResponseMessage> CreateRiddle(Riddle riddle)
        {
            return _baseApiAccessor.PostJson(_apiConnection, riddle);
        }

        public Task<HttpResponseMessage> GetRiddles()
        {
            return _baseApiAccessor.GetJson(_apiConnection);
        }
    }
}
