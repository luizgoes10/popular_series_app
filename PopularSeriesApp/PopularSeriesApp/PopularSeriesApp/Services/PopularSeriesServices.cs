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

        public Task<PopularSeriesResult> GetOnTheAirSeriesAsync(int page, string language = null)
        {
            if (language != null)
            {
                return _api.GetOnTheAirSeriesAsync(page, language, AppSettings.ApiKey);
            }
            return _api.GetOnTheAirSeriesAsync(page, AppSettings.ApiLanBr, AppSettings.ApiKey);
        }

        public Task<PopularSeriesResult> GetPopularSeriesAsync(int page, string language = null)
        {
            if (language != null)
            {
                return _api.GetPopularSeriesAsync(page, language, AppSettings.ApiKey);
            }
            return _api.GetPopularSeriesAsync(page, AppSettings.ApiLanBr, AppSettings.ApiKey);
        }

        public Task<PopularSeriesResult> GetTopRatedSeriesAsync(int page, string language = null)
        {
            if (language != null)
            {
                return _api.GetTopRatedSeriesAsync(page, language, AppSettings.ApiKey);
            }
            return _api.GetTopRatedSeriesAsync(page, AppSettings.ApiLanBr, AppSettings.ApiKey);
        }
    }
}
