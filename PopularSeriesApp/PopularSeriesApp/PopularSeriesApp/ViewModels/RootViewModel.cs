﻿using PopularSeriesApp.Models;
using PopularSeriesApp.Services;
using PopularSeriesApp.Views;
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

        public ICommand ItemClickMasterCommand { get; }

        public ICommand NavigateListPageCommand { get; }

        public ICommand NavigateListBackPageCommand { get; }

        public ObservableCollection<PopularSeries> Items { get; }

        public PopularSeriesResult Result { get; set; }

        public ObservableCollection<RootViewMenuItem> MenuItems { get; set; }

        bool _isPresent;
        public bool IsPresent
        {
            get { return _isPresent; }
            set { _isPresent = value; OnPropertyChanged(); }
        }
        
        int _atualPage;
        public int AtualPage
        {
            get { return _atualPage; }
            set { _atualPage = value; OnPropertyChanged(); }
        }


        int count = 1;

        public RootViewModel(IPopularSeriesServices popularSeriesService) : base("Mais Votadas")
        {
            BarBackGroundColor = Color.FromHex("#64449f");

            _popularSeriesServices = popularSeriesService;

            ItemClickCommand = new Command<PopularSeries>(async (item) => await ItemClickCommandExecuteAsync(item));

            NavigateListPageCommand = new Command(ExecuteNavigateListCommand);

            NavigateListBackPageCommand = new Command(ExecuteNavigateListBackPageCommand);

            ItemClickMasterCommand = new Command(ExecuteNavigateMasterCommand);

            Items = new ObservableCollection<PopularSeries>();

            MenuItems = new ObservableCollection<RootViewMenuItem>(new[]
             {
                    new RootViewMenuItem { Id = 0, Title = "Mais Populares", Image = "hearts.png" },
                    new RootViewMenuItem { Id = 1, Title = "No Ar", Image = "tv.png" },
                    new RootViewMenuItem { Id = 2, Title = "Vídeos", Image = "videos.png"},
                    new RootViewMenuItem { Id = 3, Title = "Mais Votadas", Image = "mais.png" },
                    new RootViewMenuItem { Id = 4, Title = "Mudar Idioma", Image = "language.png" },
                    new RootViewMenuItem { Id = 5, Title = "Configurações", Image = "settings.png" },
                });
        }

        private async void ExecuteNavigateMasterCommand(object obj)
        {
            var opcao = obj as RootViewMenuItem;
            switch (opcao.Id)
            {
                case 0:
                    Result = await _popularSeriesServices.GetPopularSeriesAsync(1);
                    Result.NamePage = "Populares";
                    Items.Clear();
                    AddItems(Result.results);
                    Title = "Mais Populares";
                    IsPresent = false;
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Result = await _popularSeriesServices.GetTopRatedSeriesAsync(1);
                    Result.NamePage = "TopRated";
                    Items.Clear();
                    AddItems(Result.results);
                    Title = "Mais Votadas";
                    IsPresent = false;
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }

        private async void ExecuteNavigateListBackPageCommand(object obj)
        {
            if (1 < Result.page)
            {
                switch (Result.NamePage)
                {
                    case "TopRated":
                        count--;
                        Result = await _popularSeriesServices.GetTopRatedSeriesAsync(Result.page -1);
                        Items.Clear();
                        AddItems(Result.results);
                        Result.NamePage = "TopRated";
                        break;
                    case "Populares":
                        count--;
                        Result = await _popularSeriesServices.GetPopularSeriesAsync(Result.page - 1);
                        Items.Clear();
                        AddItems(Result.results);
                        Result.NamePage = "Populares";
                        break;
                }
                //count--;
                //Result = await _popularSeriesServices.GetTopRatedSeriesAsync(Result.page - 1);
                //Items.Clear();
                //AddItems(Result.results);
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
                    switch (Result.NamePage)
                    {
                        case "TopRated":
                            count++;
                            Result = await _popularSeriesServices.GetTopRatedSeriesAsync(count);
                            Items.Clear();
                            AddItems(Result.results);
                            Result.NamePage = "TopRated";
                            break;
                        case "Populares":
                            count++;
                            Result = await _popularSeriesServices.GetPopularSeriesAsync(count);
                            Items.Clear();
                            AddItems(Result.results);
                            Result.NamePage = "Populares";
                            break;
                    }
                    
                }
                else
                {
                    switch (Result.NamePage)
                    {
                        case "TopRated":
                            Result = await _popularSeriesServices.GetTopRatedSeriesAsync(Result.page + 1);
                            Items.Clear();
                            AddItems(Result.results);
                            Result.NamePage = "TopRated";
                            break;
                        case "Populares":
                            Result = await _popularSeriesServices.GetPopularSeriesAsync(Result.page + 1);
                            Items.Clear();
                            AddItems(Result.results);
                            Result.NamePage = "Populares";
                            break;
                    }
         
                }
            }
            else
            {
                await DialogService.AlertAsync("Navegação Encerrada.", "Não há mais resultados.", "OK");
            }

        }

        public override async Task InitializeAsync(object navigationData)
        {
            var param = new Params();

            if (navigationData == null)
            {
                param.NamePage = "TopRated";

                param.NumberPage = 1;
                
                Result = await GetItemsAsync(param);

                Result.NamePage = param.NamePage;
            }
            else
            {
                param = navigationData as Params;

                Result = await GetItemsAsync(param);

                Result.NamePage = param.NamePage;

                Title = param.Title;
            }

            Items.Clear();
            AddItems(Result.results);

            await base.InitializeAsync(navigationData);
        }

        async Task ItemClickCommandExecuteAsync(PopularSeries model)
        {
            model.NumberPage = Result.page;
            model.NamePage = Result.NamePage;
            model.TitlePage = Title;
            await NavigationService.NavigateToAsync<DetailsViewModel>(model);
        }

        async Task<PopularSeriesResult> GetItemsAsync(Params param)
        {
            if (param.NamePage == "TopRated")
                return await _popularSeriesServices.GetTopRatedSeriesAsync(param.NumberPage);

            else if (param.NamePage == "Populares")
                return await _popularSeriesServices.GetPopularSeriesAsync(param.NumberPage);

            else return null;
        }

        void AddItems(IEnumerable<PopularSeries> items)
            => items?.ToList()?.ForEach(i => Items.Add(i));
    }
}
