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
        Task<PopularSeriesResult> GetPopularSeriesAsync(int page);
    }
}
