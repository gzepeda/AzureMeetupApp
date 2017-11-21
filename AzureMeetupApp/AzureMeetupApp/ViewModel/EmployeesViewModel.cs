using AzureMeetupApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebApiCore.Model.Data;
using AzureMeetupApp.Services;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AzureMeetupApp.ViewModel
{
	public class EmployeesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees { get; set; }
		public EmployeesViewModel()
		{
		    Task.Run(() => this.GetEmployees()).Wait();
        }

        public async Task GetEmployees()
        {
            IBackend service = new BackendDotNetCore();
            Employees = new ObservableCollection<Employee>(await service.GetEmployees());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            var changed = PropertyChanged;

            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}