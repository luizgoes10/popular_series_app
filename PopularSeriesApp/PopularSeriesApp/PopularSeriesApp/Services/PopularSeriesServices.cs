using System.Collections.Generic;
using System.Threading.Tasks;
using PopularSeriesApp.Models;
using PopularSeriesApp.Services.Infrastructure.Api;

namespace PopularSeriesApp.Services
{
    //Autor: Profº Willian S Rogriguez
    public class PopularSeriesServices : IPopularSeriesServices
    {
        readonly IGetApi _api;

        public PopularSeriesServices(IGetApi api)
        {
            _api = api;
        }
        public Task<PopularSeriesResult> GetPopularSeriesAsync(int page)
        {
            return _api.GetPopularSeriesAsync(page, AppSettings.ApiLanBr, AppSettings.ApiKey);
        }
    }
}
