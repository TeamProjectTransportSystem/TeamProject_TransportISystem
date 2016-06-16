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
using System.Windows.Media;
using TransportInfoService.Commands;
using TransportInfoService.Resources;

namespace TransportInfoService
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Model LogisOfTransportSystem;

        private string departureStationComboBoxText;
        private string destinationStationComboBoxText;
        private Brush foregroundDepartureStationComboBox;
        private Brush foregroundDestinationStationComboBox;

        private Visibility visibilityForFoundTrainsDataGrid;
        private Visibility visibilityForSearchTrainsButton;
        private Visibility visibilityForCalendarControl;

        private Command commandClickButtonSearchTrains = new Command(new Action(() => MessageBox.Show("Action method")));

        public Command CommandClickButtonSearchTrains
        {
            get { return commandClickButtonSearchTrains; }
            set {
                    commandClickButtonSearchTrains = value;
                    NotifyPropertyChanged();
                }
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
            }
        }

        public string DepartureStationComboBoxText
        {
            get
            {
                return departureStationComboBoxText;
            }

            set
            {
                departureStationComboBoxText = value;
                NotifyPropertyChanged();
            }
        }

        public string DestinationStationComboBoxText
        {
            get
            {
                return destinationStationComboBoxText;
            }

            set
            {
                destinationStationComboBoxText = value;
                NotifyPropertyChanged();
            }
        }

        public Brush ForegroundDepartureStationComboBox
        {
            get
            {
                return foregroundDepartureStationComboBox;
            }

            set
            {
                foregroundDepartureStationComboBox = value;
                NotifyPropertyChanged();
            }
        }

        public Brush ForegroundDestinationStationComboBox
        {
            get
            {
                return foregroundDestinationStationComboBox;
            }

            set
            {
                foregroundDestinationStationComboBox = value;
                NotifyPropertyChanged();
            }
        }

        public void AutoGeneratingColumnEventHandlerForFoundTrainsDataGrid(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "TrainFullName")
            {
                e.Column.Header = RussianHeadersForDataGrid.Train;
            }
            else if (e.Column.Header.ToString() == "DepartureTime")
            {
                e.Column.Header = RussianHeadersForDataGrid.DepartureTime;
            }
            else if (e.Column.Header.ToString() == "ArrivalTime")
            {
                e.Column.Header = RussianHeadersForDataGrid.ArrivalTime;
            }
            else if (e.Column.Header.ToString() == "TravelTime")
            {
                e.Column.Header = RussianHeadersForDataGrid.TravelTime;
            }
            else if (e.Column.Header.ToString() == "DaysOfCruising")
            {
                e.Column.Header = RussianHeadersForDataGrid.DaysOfCruising;
            }
            else if (e.Column.Header.ToString() == "Stations")
            {
                e.Column.Header = RussianHeadersForDataGrid.Stations;
            }
        }

        public void PreviewTextInputForComboBoxesWithStations(object sender, TextCompositionEventArgs e)
        {
            if ((sender as ComboBox).Name == "")
            {

            }
            else
            {

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

            DepartureStationComboBoxText = Texts.ComboBoxChooseStation;
            DestinationStationComboBoxText = Texts.ComboBoxChooseStation;
            ForegroundDepartureStationComboBox = Brushes.Gray;
            ForegroundDestinationStationComboBox = Brushes.Gray;
        }
    }
}
