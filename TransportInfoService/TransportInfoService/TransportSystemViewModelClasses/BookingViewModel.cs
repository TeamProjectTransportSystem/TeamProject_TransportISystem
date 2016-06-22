using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TransportInfoService.TransportSystemViewModelClasses
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        private Visibility visibilityForBookingStackPanel;
        private Visibility visibilityForLoginAndRegistrationControls;

        private string loginOfUserAlreadyLoggedIn;
        private string loginTextBox;
        private string registrationLoginTextBox;

        public string RegistrationLoginTextBox
        {
            get 
            { 
                return registrationLoginTextBox; 
            }

            set 
            { 
                registrationLoginTextBox = value;
                NotifyPropertyChanged();
            }
        }


        public Visibility VisibilityForLoginAndRegistrationControls
        {
            get 
            { 
                return visibilityForLoginAndRegistrationControls; 
            }
            
            set 
            { 
                visibilityForLoginAndRegistrationControls = value;
                NotifyPropertyChanged();
            }
        }
        public string LoginTextBox
        {
            get 
            {
                return loginTextBox; 
            }

            set 
            {
                loginTextBox = value;
                NotifyPropertyChanged();
            }
        }

        public string LoginOfUserAlreadyLoggedIn
        {
            get 
            {
                return loginOfUserAlreadyLoggedIn; 
            }

            set 
            {
                loginOfUserAlreadyLoggedIn = value;
                NotifyPropertyChanged();
            }
        }

        public Visibility VisibilityForBookingStackPanel
        {
            get 
            { 
                return visibilityForBookingStackPanel; 
            }

            set 
            { 
                visibilityForBookingStackPanel = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        public BookingViewModel()
        {
            VisibilityForBookingStackPanel = Visibility.Collapsed;
            VisibilityForLoginAndRegistrationControls = Visibility.Visible;

            LoginOfUserAlreadyLoggedIn = string.Empty;
            LoginTextBox = string.Empty;
            RegistrationLoginTextBox = string.Empty;
        }

    }
}
