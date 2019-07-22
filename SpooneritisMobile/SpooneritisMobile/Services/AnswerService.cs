using SpooneritisMobile.Helpers;
using SpooneritisMobile.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    public class AnswerService : IAnswerService
    {
        private static readonly string _apiConnection = "answers";

        private readonly ISettingsProvider _settings;
        private readonly IBaseApiAccessor _baseApiAccessor;

        public AnswerService(ISettingsProvider settings, IBaseApiAccessor baseApiAccessor)
        {
            _settings = settings;
            _baseApiAccessor = baseApiAccessor;
        }
        

        public Task<HttpResponseMessage> CreateAnswer(Riddle riddle)
        {
            Answer answer = new Answer
            {
                Riddle = riddle.Id,
                Solver = _settings.GetItem(SettingTypes.UserId)
            };

            return _baseApiAccessor.PostJson(_apiConnection, answer);
        }
    }
}
