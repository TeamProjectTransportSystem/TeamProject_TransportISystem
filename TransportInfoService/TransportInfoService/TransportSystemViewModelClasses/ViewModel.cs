using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TransportInfoService.Commands;
using TransportInfoService.DatabaseClasses;
using TransportInfoService.Resources;
using TransportInfoService.TransportSystemLogicClasses;
using TransportInfoService.TransportSystemViewModelClasses;

namespace TransportInfoService
{
    public class ViewModel : INotifyPropertyChanged
    {
        private TrainFiltersViewModel viewModelForTrainFilters;
        private BookingViewModel viewModelForBookingStackPanel;

        private DateTime? selectedDateInCalendarControl;

        private Model LogicOfTransportSystem;

        private List<string> listOfStations;
        private List<ITrainInfo> BufferForFoundTrains;

        public bool StationsLoaded = false;
        private bool checkBoxAllDaysIsChecked;
        private bool searchDataAnimatedEllipseMustBeAnimated;
        public bool NoNeedForComboBoxTextChangedEvent = false;

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

        /*private Command commandClickButtonSearchTrains = new Command(new Action(() => MessageBox.Show("Action method")));

        public Command CommandClickButtonSearchTrains
        {
            get { return commandClickButtonSearchTrains; }
            set {
                    commandClickButtonSearchTrains = value;
                    NotifyPropertyChanged();
                }
        }*/

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

        public List<string> ListOfStations
        {
            get
            {
                return listOfStations;
            }

            set
            {
                listOfStations = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? SelectedDateInCalendarControl
        {
            get 
            { 
                return selectedDateInCalendarControl; 
            }

            set 
            { 
                selectedDateInCalendarControl = value;
                NotifyPropertyChanged();
            }
        }

        public BookingViewModel ViewModelForBookingStackPanel
        {
            get 
            { 
                return viewModelForBookingStackPanel; 
            }

            set
            { 
                viewModelForBookingStackPanel = value;
                NotifyPropertyChanged();
            }
        }
        private void LoadNamesOfStationsFromTransportDB()
        {
            List<string> BufferForStations = TransportDBWorker.ReturnListOfStationNames();
            ListOfStations = BufferForStations;
            StationsLoaded = true;
        }

        public void SelectionChangedEventHandlerForComboBoxesWithStations(object sender, EventArgs e)
        {
            if (!StationsLoaded && (sender as ComboBox).SelectedIndex >= 0)
            {
                (sender as ComboBox).SelectedIndex = -1;
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

        public void ClickEventHandlerForApplyFiltersButton(object sender, EventArgs e)
        {
            VisibilityForFoundTrainsDataGrid = Visibility.Collapsed;
            ViewModelForTrainFilters.VisibilityForAnimatedEclipseForApplyingFilters = Visibility.Visible;
            ViewModelForTrainFilters.ApplyingFiltersEllipseMustBeAnimated = true;
            ThreadPool.QueueUserWorkItem(o => ApplyFiltersOnListOfTrains());
        }

        private void ApplyFiltersOnListOfTrains()
        {
            bool AtLeastOneCheckBoxIsChecked = false;
            if (viewModelForTrainFilters.DepartureTimeCheckBoxMorningIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
            }
            if (viewModelForTrainFilters.DepartureTimeCheckBoxDayIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
            }
            if (viewModelForTrainFilters.DepartureTimeCheckBoxEveningIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
            }
            if (viewModelForTrainFilters.DepartureTimeCheckBoxNightIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
            }
            if (viewModelForTrainFilters.ArrivalTimeCheckBoxMorningIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
            }
            if (viewModelForTrainFilters.ArrivalTimeCheckBoxDayIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
            }
            if (viewModelForTrainFilters.ArrivalTimeCheckBoxEveningIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
            }
            if (viewModelForTrainFilters.ArrivalTimeCheckBoxNightIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
            }
            if (!AtLeastOneCheckBoxIsChecked)
            {

            }
            if (!(viewModelForTrainFilters.BusinessTrainTypeCheckBoxIsChecked && viewModelForTrainFilters.EconomTrainTypeCheckBoxIsChecked) &&
                !(!viewModelForTrainFilters.BusinessTrainTypeCheckBoxIsChecked && !viewModelForTrainFilters.EconomTrainTypeCheckBoxIsChecked))
            {
                if (viewModelForTrainFilters.BusinessTrainTypeCheckBoxIsChecked)
                {

                }
                if (viewModelForTrainFilters.EconomTrainTypeCheckBoxIsChecked)
                {

                }
            }
            ViewModelForTrainFilters.ApplyingFiltersEllipseMustBeAnimated = false;
            ViewModelForTrainFilters.VisibilityForAnimatedEclipseForApplyingFilters = Visibility.Collapsed;
            VisibilityForFoundTrainsDataGrid = Visibility.Visible;
        }

        private bool CheckingTheExistenceOfStations()
        {
            bool BothStationsAreExists = true;
            if (listOfStations.Where((res) => res == DepartureStationComboBoxText).FirstOrDefault() == null)
            {
                BothStationsAreExists = false;
                VisibilityForLabelDepartureStationNotFound = Visibility.Visible;
            }
            if (listOfStations.Where((res) => res == DestinationStationComboBoxText).FirstOrDefault() == null)
            {
                BothStationsAreExists = false;
                VisibilityForLabelDestinationStationNotFound = Visibility.Visible;
            }
            return BothStationsAreExists;
        }

        private void SearchOfTrainsWithoutDate()
        {
            if (!CheckingTheExistenceOfStations())
            {
                SearchOfTrainsEnded(null);
            }
            else
            {

            }
        }

        private void SearchOfTrainsWithDate()
        {
            if (!CheckingTheExistenceOfStations())
            {
                SearchOfTrainsEnded(null);
            }
            else
            {

            }
            ViewModelForBookingStackPanel.VisibilityForBookingStackPanel = Visibility.Visible;
        }

        private void SearchOfTrainsEnded(List<ITrainInfo> FoundTrains)
        {
            if (FoundTrains != null && FoundTrains.Count > 0)
            {
                VisibilityForFoundTrainsDataGrid = Visibility.Visible;
                viewModelForTrainFilters.VisibilityForTrainFilters = Visibility.Visible;
                ForegroundProgramStateLabel = Brushes.Green;
                ProgramStateLabelContent = Texts.LabelProgramStateReady;
                viewModelForTrainFilters.ListOfFoundTrainsForDataGridWhichContainsFoundTrains = FoundTrains;
            }
            else
            {
                ForegroundProgramStateLabel = Brushes.Red;
                ProgramStateLabelContent = Texts.LabelProgramStateFail;
            }
            VisibilityForSearchTrainsButton = Visibility.Visible;
            SearchDataAnimatedEllipseMustBeAnimated = false;
            VisibilityForSearchDataAnimatedEllipse = Visibility.Collapsed;
        }


        public void ClickEventHandlerForSearchTrainsButton(object sender, EventArgs e)
        {
            ViewModelForBookingStackPanel.VisibilityForBookingStackPanel = Visibility.Collapsed;
            VisibilityForLabelDepartureStationNotFound = Visibility.Collapsed;
            VisibilityForLabelDestinationStationNotFound = Visibility.Collapsed;
            VisibilityForSearchTrainsButton = Visibility.Collapsed;
            VisibilityForFoundTrainsDataGrid = Visibility.Collapsed;
            viewModelForTrainFilters.VisibilityForTrainFilters = Visibility.Collapsed;
            ForegroundProgramStateLabel = Brushes.Orange;
            ProgramStateLabelContent = Texts.LabelProgramStateWait;
            VisibilityForSearchDataAnimatedEllipse = Visibility.Visible;
            SearchDataAnimatedEllipseMustBeAnimated = true;

            if (CheckBoxAllDaysIsChecked)
            {
                ThreadPool.QueueUserWorkItem(o => SearchOfTrainsWithoutDate());
            }
            else
            {
                ThreadPool.QueueUserWorkItem(o => SearchOfTrainsWithDate());
            }
        }

        public void DropDownOpenedEventHandlerForComboBoxesWithStations(object sender, EventArgs e)
        {
            NoNeedForComboBoxTextChangedEvent = true;
            if ((sender as ComboBox).Text == Texts.ComboBoxChooseStation)
            {
                (sender as ComboBox).Foreground = Brushes.Black;
                (sender as ComboBox).Text = string.Empty;
            }
        }

        public void DropDownClosedEventHandlerForComboBoxesWithStations(object sender, EventArgs e)
        {
            NoNeedForComboBoxTextChangedEvent = true;
            if ((sender as ComboBox).Text == string.Empty)
            {
                (sender as ComboBox).Foreground = Brushes.Gray;
                (sender as ComboBox).Text = Texts.ComboBoxChooseStation;
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
            LogicOfTransportSystem = Model.Instance;
            ViewModelForTrainFilters = new TrainFiltersViewModel();
            ViewModelForBookingStackPanel = new BookingViewModel();

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

            BufferForFoundTrains = new List<ITrainInfo>();
            ListOfStations = new List<string>();
            ListOfStations.Add(Texts.TextStationStillLoading);

            //ThreadPool.QueueUserWorkItem(o => LoadNamesOfStationsFromTransportDB());
        }
    }
}
