using AzureMeetupApp.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AzureMeetupApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaDePersonasPage : ContentPage
    {
        public PersonasViewModel model;

        public ListaDePersonasPage()
        {
            InitializeComponent();

            model = new PersonasViewModel();

            BindingContext = model;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
