using PopularSeriesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PopularSeriesApp.Services
{
    //Autor: Willian S Rogriguez
    public interface IPopularSeriesServices
    {
        Task<PopularSeriesResult> GetPopularSeriesAsync(int page, string language = null);

        Task<PopularSeriesResult> GetTopRatedSeriesAsync(int page, string language = null);

        Task<PopularSeriesResult> GetOnTheAirSeriesAsync(int page, string language = null);
    }
}
