using PopularSeriesApp.Models;
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
    public class RootViewModel : ViewModelBase
    {
        readonly IPopularSeriesServices _popularSeriesServices;

        public ICommand ItemClickCommand { get; }

        public ICommand NavigateListPageCommand { get; }

        public ICommand NavigateListBackPageCommand { get; }

        public ObservableCollection<PopularSeries> Items { get; }

        public PopularSeriesResult Result { get; set; }

        int _atualPage;
        public int AtualPage
        {
            get { return _atualPage; }
            set { _atualPage = value; OnPropertyChanged(); }
        }


        int count = 1;

        public RootViewModel(IPopularSeriesServices popularSeriesService) : base("Séries Populares")
        {
            BarBackGroundColor = Color.FromHex("#64449f");

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

        private async void ExecuteNavigateListCommand(object obj)
        {
            AtualPage = Result.page;

            if (Result.total_pages >= count)
            {
                if (AtualPage == count)
                {
                    count++;
                    Result = await _popularSeriesServices.GetPopularSeriesAsync(count);
                    Items.Clear();
                    AddItems(Result.results);
                }
                else
                {
                    Result = await _popularSeriesServices.GetPopularSeriesAsync(Result.page + 1);
                    Items.Clear();
                    AddItems(Result.results);
                }
            }
            else
            {
                await DialogService.AlertAsync("Navegação Encerrada.", "Não há mais resultados.", "OK");
            }

        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
            int page = 0;
            if (navigationData == null)
            {
                page = 1;

                Result = await GetItemsAsync(page);
            }
            else
            {
                page = (int)navigationData;
                Result = await GetItemsAsync(page);
            }

            Items.Clear();
            AddItems(Result.results);
        }

        async Task ItemClickCommandExecuteAsync(PopularSeries model)
        {
            model.NumberPage = Result.page;
            await NavigationService.NavigateToAsync<DetailsViewModel>(model);
        }

        async Task<PopularSeriesResult> GetItemsAsync(int page)
            => await _popularSeriesServices.GetPopularSeriesAsync(page);

        void AddItems(IEnumerable<PopularSeries> items)
            => items?.ToList()?.ForEach(i => Items.Add(i));
    }
}
