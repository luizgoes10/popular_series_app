using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PopularSeriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootViewMaster : ContentPage
    {
        public ListView ListView;

        public RootViewMaster()
        {
            InitializeComponent();

            BindingContext = new RootViewMasterViewModel();
            ListView = MenuItemsListView;
        }

        class RootViewMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<RootViewMenuItem> MenuItems { get; set; }
            
            public RootViewMasterViewModel()
            {
                MenuItems = new ObservableCollection<RootViewMenuItem>(new[]
                {
                    new RootViewMenuItem { Id = 0, Title = "Page 1" },
                    new RootViewMenuItem { Id = 1, Title = "Page 2" },
                    new RootViewMenuItem { Id = 2, Title = "Page 3" },
                    new RootViewMenuItem { Id = 3, Title = "Page 4" },
                    new RootViewMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}