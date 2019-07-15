using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    public class AnswerService : BaseApiAccessor, IAnswerService
    {
        private static readonly string _apiConnection = "answers";

        public Task<HttpResponseMessage> CreateAnswer(Riddle riddle)
        {
            Answer answer = new Answer
            {
                Riddle = riddle.Id,
                Solver = "5d291f6f80bf6f61d0380d9c"
            };

            return PostJson(_apiConnection, answer);
        }
    }
}
