using PopularSeriesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public DetailsViewModel() : base("")
        {
            Title = "Detalhes";
        }

        public override Task InitializeAsync(object navigationData)
        {
            var param = navigationData as PopularSeries;
            Name = param.name;
            Popularity = param.popularity;
            Vote_average = param.vote_average;
            Thumb = param.Thumb;
            return base.InitializeAsync(navigationData);
        }

    }
}
