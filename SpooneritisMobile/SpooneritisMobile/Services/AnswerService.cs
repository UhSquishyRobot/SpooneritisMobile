using SpooneritisMobile.Helpers;
using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    public class AnswerService : BaseApiAccessor, IAnswerService
    {
        private static readonly string _apiConnection = "answers";
        private readonly ISettingsProvider _settings;

        public AnswerService(ISettingsProvider settings)
        {
            _settings = settings;
        }
        

        public Task<HttpResponseMessage> CreateAnswer(Riddle riddle)
        {
            Answer answer = new Answer
            {
                Riddle = riddle.Id,
                Solver = _settings.GetItem(SettingTypes.UserId)
            };

            return PostJson(_apiConnection, answer);
        }
    }
}
