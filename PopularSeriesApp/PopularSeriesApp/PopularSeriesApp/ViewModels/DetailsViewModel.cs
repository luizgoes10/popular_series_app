using PopularSeriesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PopularSeriesApp.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        decimal _popularity;
        public decimal Popularity
        {
            get { return _popularity; }
            set { _popularity = value; OnPropertyChanged(); }
        }
        decimal _vote_average;
        public decimal Vote_average
        {
            get { return _vote_average; }
            set { _vote_average = value; OnPropertyChanged(); }
        }
        string _thumb;
        public string Thumb
        {
            get { return _thumb; }
            set { _thumb = value; OnPropertyChanged(); }
        }
        string _overview;
        public string Overview
        {
            get { return _overview; }
            set { _overview = value; OnPropertyChanged(); }
        }
        int _numberPage;
        public int NumberPage
        {
            get { return _numberPage; }
            set { _numberPage = value; OnPropertyChanged(); }
        }
        public ICommand NavigateBackCommand { get; }

        public DetailsViewModel() : base("")
        {
            NavigateBackCommand = new Command(ExecuteNavigateCommandAsync);
            ButtonsBackGroundColor = Color.FromHex("#64449f");
        }

        private async void ExecuteNavigateCommandAsync(object obj)
        {
            await NavigationService.NavigateToAsync<RootViewModel>(obj);
        }

        public override Task InitializeAsync(object navigationData)
        {
            var param = navigationData as PopularSeries;
            Name = param.name;
            Popularity = param.popularity;
            Vote_average = param.vote_average;
            Overview = param.overview;
            Thumb = param.Thumb;
            NumberPage = param.NumberPage;
            return base.InitializeAsync(navigationData);
        }

    }
}
