using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SpooneritisMobile.Models;

namespace SpooneritisMobile.Services
{
    public interface IRiddleService
    {
        Task<HttpResponseMessage> CreateRiddle(Riddle riddle);
    }
}
