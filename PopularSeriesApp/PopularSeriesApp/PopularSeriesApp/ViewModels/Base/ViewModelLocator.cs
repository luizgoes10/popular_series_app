using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using Autofac;
using PopularSeriesApp.Services.Navigation;
using PopularSeriesApp.Services.Dialog;
using PopularSeriesApp.Services;
using System.Net.Http;
using PopularSeriesApp.Services.Infrastructure.HttpTools;
using PopularSeriesApp.Services.Infrastructure.Api;

namespace PopularSeriesApp.ViewModels.Base
{
    //Autor: Profº Willian S Rodriguez
    public class ViewModelLocator
    {
        IContainer _container;
        ContainerBuilder _containerBuilder;

        static readonly ViewModelLocator _instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get
            {
                return _instance;
            }
        }

        public ViewModelLocator()
        {
            _containerBuilder = new ContainerBuilder();

            _containerBuilder.RegisterType<NavigationService>().As<INavigationService>();
            _containerBuilder.RegisterType<DialogService>().As<IDialogService>();
            _containerBuilder.RegisterType<PopularSeriesServices>().As<IPopularSeriesServices>();

            _containerBuilder.RegisterType<MainViewModel>();
            _containerBuilder.RegisterType<DetailsViewModel>();
            _containerBuilder.RegisterType<RootViewModel>();

            _containerBuilder.Register(api =>
            {
                var client = new HttpClient(new HttpLoggingHandler())
                {
                    BaseAddress = new Uri(AppSettings.ApiUrl),
                    Timeout = TimeSpan.FromSeconds(60)
                };

                return RestService.For<IGetApi>(client);
            }).As<IGetApi>().InstancePerDependency();
        }

        public T Resolve<T>() => _container.Resolve<T>();
        public object Resolve(Type type) => _container.Resolve(type);
        public void Register<TInterface, TImplementation>() where TImplementation : TInterface => _containerBuilder.RegisterType<TImplementation>().As<TInterface>();
        public void Register<T>() where T : class => _containerBuilder.RegisterType<T>();

        public void Build()
        {
            if (_container == null)
                _container = _containerBuilder.Build();
        }
    }
}
