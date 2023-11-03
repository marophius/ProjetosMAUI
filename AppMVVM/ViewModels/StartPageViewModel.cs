using AppMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMVVM.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
    {
        private Person _person;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveCommand { get; set; }
        public Person Person { get => _person; set 
            {
                if (_person == value) return;
                _person = value;
                OnProperyChanged(nameof(Person));
            }
        }

        public ObservableCollection<Person> People { get; set; }

        public StartPageViewModel()
        {
            SaveCommand = new Command(Save);
            Person = new Person();
        }

        private void Save()
        {
            People.Add(Person);
            Person = new Person();
        }

        public void OnProperyChanged(string propname)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }
}
