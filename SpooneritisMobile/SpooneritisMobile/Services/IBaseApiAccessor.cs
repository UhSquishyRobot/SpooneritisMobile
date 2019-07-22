using System.Net.Http;
using System.Threading.Tasks;

namespace SpooneritisMobile.Services
{
    public interface IBaseApiAccessor
    {
        Task<HttpResponseMessage> PostJson<T>(string url, T obj);

        Task<HttpResponseMessage> GetJson(string url);
    }
}
