using PopularSeriesApp.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PopularSeriesApp.Services.Infrastructure.Api
{
    public interface IGetApi
    {
        [Get("/top_rated?page={page}&language={lang}&api_key={key}")]
        Task<PopularSeriesResult> GetPopularSeriesAsync(int page, string lang, string key);
    }
}
