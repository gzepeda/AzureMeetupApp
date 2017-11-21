using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AzureMeetupApp.ViewModel;

namespace AzureMeetupApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaDeEmployees : ContentPage
	{
	    public EmployeesViewModel model;
	    public ListaDeEmployees()
	    {
	        InitializeComponent();

	        model = new EmployeesViewModel();

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