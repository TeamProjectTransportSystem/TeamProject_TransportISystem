using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TransportInfoService.Commands;

namespace TransportInfoService
{
    public class ViewModel : INotifyPropertyChanged
    {

        private Command commandClickButtonSearchTrains = new Command(new Action(() => MessageBox.Show("Action method")));

        public Command CommandClickButtonSearchTrains
        {
            get { return commandClickButtonSearchTrains; }
            set { commandClickButtonSearchTrains = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public ViewModel()
        {

        }
    }
}
