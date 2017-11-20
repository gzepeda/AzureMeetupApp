using AzureMeetupApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;

namespace AzureMeetupApp.ViewModel
{
	public class PersonasViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Entidad> Entidades { get; set; }
		public PersonasViewModel ()
		{
		    Entidades = new ObservableCollection<Entidad>(MockEntidad.GetEntidades());
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