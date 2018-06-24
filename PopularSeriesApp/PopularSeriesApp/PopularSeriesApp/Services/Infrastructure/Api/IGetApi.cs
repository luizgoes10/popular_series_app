using PopularSeriesApp.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PopularSeriesApp.Services.Infrastructure.Api
{
    public interface IGetApi
    {
        [Get("/games/?fields=id,name,summary,popularity,cover,esrb,websites&order=popularity:desc")]
        Task<IEnumerable<PopularSeries>> GetPopularSeriesAsync([Header("user-key")] string authorization);
    }
}
