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
using TransportInfoService.TransportSystemViewModelClasses;

namespace TransportInfoService
{
    public class ViewModel : INotifyPropertyChanged
    {
        private TrainFiltersViewModel viewModelForTrainFilters;
        private Model LogicOfTransportSystem;

        private bool checkBoxAllDaysIsChecked;
        private bool searchDataAnimatedEllipseMustBeAnimated;

        private string departureStationComboBoxText;
        private string destinationStationComboBoxText;
        private Brush foregroundDepartureStationComboBox;
        private Brush foregroundDestinationStationComboBox;

        private Brush foregroundProgramStateLabel;
        private string programStateLabelContent;

        private Visibility visibilityForFoundTrainsDataGrid;
        private Visibility visibilityForSearchTrainsButton;
        private Visibility visibilityForCalendarControl;
        private Visibility visibilityForSearchDataAnimatedEllipse;
        private Visibility visibilityForLabelDepartureStationNotFound;
        private Visibility visibilityForLabelDestinationStationNotFound;

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

        public bool CheckBoxAllDaysIsChecked
        {
            get 
            { 
                return checkBoxAllDaysIsChecked; 
            }
            set 
            { 
                checkBoxAllDaysIsChecked = value; 
                NotifyPropertyChanged();
            }
        }

        public Visibility VisibilityForSearchDataAnimatedEllipse
        {
            get
            {
                return visibilityForSearchDataAnimatedEllipse;
            }

            set
            {
                visibilityForSearchDataAnimatedEllipse = value;
                NotifyPropertyChanged();
            }
        }

        public bool SearchDataAnimatedEllipseMustBeAnimated
        {
            get
            {
                return searchDataAnimatedEllipseMustBeAnimated;
            }

            set
            {
                searchDataAnimatedEllipseMustBeAnimated = value;
                NotifyPropertyChanged();
            }
        }

        public Brush ForegroundProgramStateLabel
        {
            get
            {
                return foregroundProgramStateLabel;
            }

            set
            {
                foregroundProgramStateLabel = value;
                NotifyPropertyChanged();
            }
        }

        public string ProgramStateLabelContent
        {
            get
            {
                return programStateLabelContent;
            }

            set
            {
                programStateLabelContent = value;
                NotifyPropertyChanged();
            }
        }

        public Visibility VisibilityForLabelDepartureStationNotFound
        {
            get
            {
                return visibilityForLabelDepartureStationNotFound;
            }

            set
            {
                visibilityForLabelDepartureStationNotFound = value;
                NotifyPropertyChanged();
            }
        }

        public Visibility VisibilityForLabelDestinationStationNotFound
        {
            get
            {
                return visibilityForLabelDestinationStationNotFound;
            }

            set
            {
                visibilityForLabelDestinationStationNotFound = value;
                NotifyPropertyChanged();
            }
        }

        public TrainFiltersViewModel ViewModelForTrainFilters
        {
            get
            {
                return viewModelForTrainFilters;
            }

            set
            {
                viewModelForTrainFilters = value;
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
            else if (e.Column.Header.ToString() == "InfoAboutSeats")
            {
                e.Column.Header = RussianHeadersForDataGrid.InfoAboutSeats;
            }
        }

        public void PreviewTextInputForComboBoxesWithStations(object sender, TextCompositionEventArgs e)
        {
            if ((sender as ComboBox).Name == NamesOfVariables.ComboBoxDepartureStationName && DepartureStationComboBoxText == Texts.ComboBoxChooseStation)
            {
                DepartureStationComboBoxText = string.Empty;
                ForegroundDepartureStationComboBox = Brushes.Black;
            }
            else if ((sender as ComboBox).Name == NamesOfVariables.ComboBoxDestinationStationName && DestinationStationComboBoxText == Texts.ComboBoxChooseStation)
            {
                DestinationStationComboBoxText = string.Empty;
                ForegroundDestinationStationComboBox = Brushes.Black;
            }
        }

        public void EventHandlerForCheckedEventOfCheckBoxAllDays(object sender, EventArgs e)
        {
                CheckBoxAllDaysIsChecked = true;
                VisibilityForCalendarControl = Visibility.Collapsed;
        }

        public void EventHandlerForUncheckedEventOfCheckBoxAllDays(object sender, EventArgs e)
        {

                CheckBoxAllDaysIsChecked = false;
                VisibilityForCalendarControl = Visibility.Visible;
            
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
            LogicOfTransportSystem = Model.Instance;
            ViewModelForTrainFilters = new TrainFiltersViewModel();

            VisibilityForSearchTrainsButton = Visibility.Visible;
            VisibilityForFoundTrainsDataGrid = Visibility.Visible;
            VisibilityForCalendarControl = Visibility.Visible;
            VisibilityForSearchDataAnimatedEllipse = Visibility.Collapsed;
            VisibilityForLabelDepartureStationNotFound = Visibility.Collapsed;
            VisibilityForLabelDestinationStationNotFound = Visibility.Collapsed;

            DepartureStationComboBoxText = Texts.ComboBoxChooseStation;
            DestinationStationComboBoxText = Texts.ComboBoxChooseStation;
            ForegroundDepartureStationComboBox = Brushes.Gray;
            ForegroundDestinationStationComboBox = Brushes.Gray;

            ForegroundProgramStateLabel = Brushes.Orange;
            ProgramStateLabelContent = string.Empty;

            SearchDataAnimatedEllipseMustBeAnimated = false;

            CheckBoxAllDaysIsChecked = false;
        }
    }
}
