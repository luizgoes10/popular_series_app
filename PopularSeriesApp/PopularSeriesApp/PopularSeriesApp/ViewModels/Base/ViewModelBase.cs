using PopularSeriesApp.Services.Dialog;
using PopularSeriesApp.Services.Navigation;
using PopularSeriesApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PopularSeriesApp.ViewModels
{
    public class ViewModelBase : BindableObject
    {
        protected readonly INavigationService NavigationService;
        protected readonly IDialogService DialogService;

        string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public ViewModelBase(string title)
        {
            Title = title;
            NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            DialogService = ViewModelLocator.Instance.Resolve<IDialogService>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
