using PopularSeriesApp.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PopularSeriesApp.Services.Infrastructure.Api
{
    public interface IGetApi
    {
        [Get("/popular?page=1&language=pt-BR")]
        Task<IEnumerable<PopularSeries>> GetPopularSeriesAsync([Header("api_key")] string authorization);
    }
}
