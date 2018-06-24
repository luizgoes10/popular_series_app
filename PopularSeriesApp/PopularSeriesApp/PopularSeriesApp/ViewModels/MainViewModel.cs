using PopularSeriesApp.Models;
using PopularSeriesApp.Models.Parameters;
using PopularSeriesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PopularSeriesApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        readonly IPopularSeriesServices _popularSeriesServices;

        public ICommand ItemClickCommand { get; }

        public ObservableCollection<PopularSeries> Items { get; }

        public MainViewModel(IPopularSeriesServices popularSeriesService):base("Séries Populares")
        {
            _popularSeriesServices = popularSeriesService;

            ItemClickCommand = new Command<PopularSeries>(async (item) => await ItemClickCommandExecuteAsync(item));
            Items = new ObservableCollection<PopularSeries>();
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);

            var result = await GetItemsAsync();
            Items.Clear();
            AddItems(result);
        }

        async Task ItemClickCommandExecuteAsync(PopularSeries model)
        {
            await NavigationService.NavigateToAsync<DetailsViewModel>(new PopularSeriesParameters
            {
                //Id = model.Id,
                //Cover = model.Cover.ScreenshotBig,
                //Name = model.Name,
                //Popularity = model.Popularity,
                //Summary = model.Summary,
            });
        }

        async Task<IEnumerable<PopularSeries>> GetItemsAsync()
            => await _popularSeriesServices.GetPopularSeriesAsync();

        void AddItems(IEnumerable<PopularSeries> items)
            => items?.ToList()?.ForEach(item => Items.Add(item));
    }
}
