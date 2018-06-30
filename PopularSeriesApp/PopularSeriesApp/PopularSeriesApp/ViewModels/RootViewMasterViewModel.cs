using PopularSeriesApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PopularSeriesApp.ViewModels
{
    public class RootViewMasterViewModel : ViewModelBase
    {
        public ObservableCollection<RootViewMenuItem> MenuItems { get; set; }

        public RootViewMasterViewModel() : base("")
        {
            MenuItems = new ObservableCollection<RootViewMenuItem>(new[]
               {
                    new RootViewMenuItem { Id = 0, Title = "Página Teste" },
                    new RootViewMenuItem { Id = 1, Title = "Page 2" },
                    new RootViewMenuItem { Id = 2, Title = "Page 3" },
                    new RootViewMenuItem { Id = 3, Title = "Page 4" },
                    new RootViewMenuItem { Id = 4, Title = "Page 5" },
                });
        }
    }
}
