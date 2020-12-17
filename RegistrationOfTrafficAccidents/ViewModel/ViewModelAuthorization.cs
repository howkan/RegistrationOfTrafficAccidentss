using RegistrationOfTrafficAccidents.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationOfTrafficAccidents.ViewModel
{
    class ViewModelAuthorization : INotifyPropertyChanged
    {
        private readonly Person person;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelAuthorization()
        {
            this.person =new Person();
        }

        public string Login
        {
            get => this.person.Login;

            set
            {
                if (this.person.Login == value) return;
                this.person.Login = value;
                this.OnPropertyChanged();
            }
        }
        public string Password
        {
            get => this.person.Password;

            set
            {
                if (this.person.Password == value) return;
                this.person.Password = value;
                this.OnPropertyChanged();
            }
        }



        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


    }
}
