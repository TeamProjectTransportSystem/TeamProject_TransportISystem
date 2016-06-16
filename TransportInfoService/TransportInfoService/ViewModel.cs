using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TransportInfoService.Commands;
using TransportInfoService.Resources;

namespace TransportInfoService
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Model LogisOfTransportSystem;

        private Visibility visibilityForFoundTrainsDataGrid;
        private Visibility visibilityForSearchTrainsButton;
        private Visibility visibilityForCalendarControl;

        private Command commandClickButtonSearchTrains = new Command(new Action(() => MessageBox.Show("Action method")));

        public Command CommandClickButtonSearchTrains
        {
            get { return commandClickButtonSearchTrains; }
            set { commandClickButtonSearchTrains = value; }
        }

        public Visibility VisibilityForSearchTrainsButton
        {
            get
            {
                return visibilityForSearchTrainsButton;
            }

            set
            {
                visibilityForSearchTrainsButton = value;
            }
        }

        public Visibility VisibilityForCalendarControl
        {
            get
            {
                return visibilityForCalendarControl;
            }

            set
            {
                visibilityForCalendarControl = value;
            }
        }

        public Visibility VisibilityForFoundTrainsDataGrid
        {
            get
            {
                return visibilityForFoundTrainsDataGrid;
            }

            set
            {
                visibilityForFoundTrainsDataGrid = value;
            }
        }

        public void TestEvent(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "TrainFullName")
            {
                e.Column.Header = RussianHeadersForDataGrid.Train;
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

        public ViewModel()
        {
            LogisOfTransportSystem = Model.Instance;

            VisibilityForSearchTrainsButton = Visibility.Collapsed;
            VisibilityForFoundTrainsDataGrid = Visibility.Visible;
            VisibilityForCalendarControl = Visibility.Visible;
        }
    }
}
