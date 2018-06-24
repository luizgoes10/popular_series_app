using System;
using Xamarin.Forms;
using PopularSeriesApp.Views;
using Xamarin.Forms.Xaml;
using PopularSeriesApp.ViewModels.Base;
using PopularSeriesApp.Services.Navigation;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace PopularSeriesApp
{
	public partial class App : Application
	{
		
		public App ()
		{
			InitializeComponent();

            BuildDependencies();

            InitNavigation();
        }

        public void BuildDependencies()
        {
            ViewModelLocator.Instance.Build();
        }

        async void InitNavigation()
        {
            var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
