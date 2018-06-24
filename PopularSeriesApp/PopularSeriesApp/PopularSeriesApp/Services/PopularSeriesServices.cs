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
        public Task<IEnumerable<PopularSeries>> GetPopularSeriesAsync()
        {
            return _api.GetPopularSeriesAsync(AppSettings.ApiKey);
        }
    }
}
