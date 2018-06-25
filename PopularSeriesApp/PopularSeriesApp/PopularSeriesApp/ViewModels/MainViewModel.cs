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

        public ICommand NavigateListPageCommand { get; }

        public ICommand NavigateListBackPageCommand { get; }

        public ObservableCollection<PopularSeries> Items { get; }

        public PopularSeriesResult Result { get; set; }

        int count = 1;


        public MainViewModel(IPopularSeriesServices popularSeriesService) : base("Séries Populares")
        {
            _popularSeriesServices = popularSeriesService;

            ItemClickCommand = new Command<PopularSeries>(async (item) => await ItemClickCommandExecuteAsync(item));

            NavigateListPageCommand = new Command(ExecuteNavigateListCommand);

            NavigateListBackPageCommand = new Command(ExecuteNavigateListBackPageCommand);

            Items = new ObservableCollection<PopularSeries>();
        }

      


        private async void ExecuteNavigateListBackPageCommand(object obj)
        {
            if (1 < count)
            {
                count--;
                Result = await _popularSeriesServices.GetPopularSeriesAsync(count);
                Items.Clear();
                AddItems(Result.results);
            }
            else
            {
                await DialogService.AlertAsync("Navegação Encerrada.", "Não é possível voltar.", "OK");
            }
        }

        private async void ExecuteNavigateListCommand()
        {
            if (Result.total_pages >= count)
            {
                count++;
                Result = await _popularSeriesServices.GetPopularSeriesAsync(count);
                Items.Clear();
                AddItems(Result.results);
            }
            else
            {
                await DialogService.AlertAsync("Navegação Encerrada.", "Não há mais resultados.", "OK");
            }

        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);

            Result = await GetItemsAsync();

            Items.Clear();
            AddItems(Result.results);
        }

        async Task ItemClickCommandExecuteAsync(PopularSeries model)
        {
            await NavigationService.NavigateToAsync<DetailsViewModel>(model);
        }

        async Task<PopularSeriesResult> GetItemsAsync()
            => await _popularSeriesServices.GetPopularSeriesAsync(1);

        void AddItems(IEnumerable<PopularSeries> items)
            => items?.ToList()?.ForEach(i => Items.Add(i));
    }
}
