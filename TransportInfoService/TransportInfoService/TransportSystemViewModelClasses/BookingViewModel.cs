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
        }

    }
}
