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
        private List<TrainWithoutDaysOfCruising> BufferForFoundTrainsWithoutDaysOfCruising;
        private List<TrainWithDaysOfCruising> BufferForFoundTrainsWithDaysOfCruising;

        private bool AtLeastOneCheckBoxIsChecked = false;
        private bool AtLeastOneCheckBoxForArrivalTimeIsChecked = false;
        private bool AtLeastOneCheckBoxForTrainTypeIsChecked = false;
        private bool loadedTrainsWithDaysOfCruising;
        private bool controlsMustBeEnabled;
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

        //Являются ли доступными для использования верхние элементы меню (Календарь, выбор станций и т.д.)
        public bool ControlsMustBeEnabled
        {
            get 
            { 
                return controlsMustBeEnabled; 
            }

            set 
            {
                controlsMustBeEnabled = value;
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

        public bool LoadedTrainsWithDaysOfCruising
        {
            get
            {
                return loadedTrainsWithDaysOfCruising;
            }

            set
            {
                loadedTrainsWithDaysOfCruising = value;
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
                e.Column.Header = RussianHeadersForDataGrid.DepartureTime + "\n(" + DepartureStationComboBoxText + ")";
            }
            else if (e.Column.Header.ToString() == "ArrivalTime")
            {
                e.Column.Header = RussianHeadersForDataGrid.ArrivalTime + "\n(" + DestinationStationComboBoxText + ")";
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
            ViewModelForTrainFilters.FiltersMustBeEnabled = false;
            VisibilityForFoundTrainsDataGrid = Visibility.Collapsed;
            ViewModelForTrainFilters.VisibilityForAnimatedEclipseForApplyingFilters = Visibility.Visible;
            ViewModelForTrainFilters.ApplyingFiltersEllipseMustBeAnimated = true;
            ThreadPool.QueueUserWorkItem(o => ApplyFiltersOnListOfTrains());
        }

        private bool ArrivalTimeOfTrainWithDaysOfCruisingSuitsUs(TrainWithDaysOfCruising CurrentTrainInfo)
        {
            if (viewModelForTrainFilters.ArrivalTimeCheckBoxMorningIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
                AtLeastOneCheckBoxForArrivalTimeIsChecked = true;
                DateTime TestDate = DateTime.Parse(CurrentTrainInfo.ArrivalTime);
                if (TestDate.Hour >= 6 && TestDate.Hour <= 11)
                {
                    return true;
                }
            }
            if (viewModelForTrainFilters.ArrivalTimeCheckBoxDayIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
                AtLeastOneCheckBoxForArrivalTimeIsChecked = true;
                DateTime TestDate = DateTime.Parse(CurrentTrainInfo.ArrivalTime);
                if (TestDate.Hour >= 12 && TestDate.Hour <= 17)
                {
                    return true;
                }
            }
            if (viewModelForTrainFilters.ArrivalTimeCheckBoxEveningIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
                AtLeastOneCheckBoxForArrivalTimeIsChecked = true;
                DateTime TestDate = DateTime.Parse(CurrentTrainInfo.ArrivalTime);
                if (TestDate.Hour >= 18 && TestDate.Hour <= 23)
                {
                    return true;
                }
            }
            if (viewModelForTrainFilters.ArrivalTimeCheckBoxNightIsChecked)
            {
                AtLeastOneCheckBoxIsChecked = true;
                AtLeastOneCheckBoxForArrivalTimeIsChecked = true;
                DateTime TestDate = DateTime.Parse(CurrentTrainInfo.ArrivalTime);
                if (TestDate.Hour >= 0 && TestDate.Hour <= 5)
                {
                    return true;
                }
            }
            if (!AtLeastOneCheckBoxForArrivalTimeIsChecked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool TrainTypeSuitUs(TrainWithDaysOfCruising CurrentTrainInfo)
        {
            if ((viewModelForTrainFilters.BusinessTrainTypeCheckBoxIsChecked && viewModelForTrainFilters.EconomTrainTypeCheckBoxIsChecked) ||
                (!viewModelForTrainFilters.BusinessTrainTypeCheckBoxIsChecked && !viewModelForTrainFilters.EconomTrainTypeCheckBoxIsChecked))
            {
                return true;
            }
            if (viewModelForTrainFilters.BusinessTrainTypeCheckBoxIsChecked)
            {
                AtLeastOneCheckBoxForTrainTypeIsChecked = true;
                AtLeastOneCheckBoxIsChecked = true;
                if (CurrentTrainInfo.TrainFullName.Split(' ')[1] == Texts.TrainTypeBusiness)
                {
                    return true;
                }
            }
            if (viewModelForTrainFilters.EconomTrainTypeCheckBoxIsChecked)
            {
                AtLeastOneCheckBoxForTrainTypeIsChecked = true;
                AtLeastOneCheckBoxIsChecked = true;
                if (CurrentTrainInfo.TrainFullName.Split(' ')[1] == Texts.TrainTypeEconom)
                {
                    return true;
                }
            }
            return false;
        }

        private void ApplyFiltersOnListOfTrains()
        {
            AtLeastOneCheckBoxIsChecked = false;
            AtLeastOneCheckBoxForArrivalTimeIsChecked = false;
            AtLeastOneCheckBoxForTrainTypeIsChecked = false;
            if (LoadedTrainsWithDaysOfCruising)
            {
                ViewModelForTrainFilters.ListOfFoundTrainsForDataGridWhichContainsFoundTrainsWithDaysOfCruising = null;
                List<TrainWithDaysOfCruising> BufferForFilteredTrains = new List<TrainWithDaysOfCruising>();
                if (viewModelForTrainFilters.DepartureTimeCheckBoxMorningIsChecked)
                {
                    AtLeastOneCheckBoxIsChecked = true;
                    foreach (TrainWithDaysOfCruising TrainInfo in BufferForFoundTrainsWithDaysOfCruising)
                    {
                        DateTime TestDate = DateTime.Parse(TrainInfo.DepartureTime);
                        if (TestDate.Hour >= 6 && TestDate.Hour <= 11 && ArrivalTimeOfTrainWithDaysOfCruisingSuitsUs(TrainInfo) && TrainTypeSuitUs(TrainInfo))
                        {
                            BufferForFilteredTrains.Add(TrainInfo);
                        }
                    }
                }
                if (viewModelForTrainFilters.DepartureTimeCheckBoxDayIsChecked)
                {
                    AtLeastOneCheckBoxIsChecked = true;
                    foreach (TrainWithDaysOfCruising TrainInfo in BufferForFoundTrainsWithDaysOfCruising)
                    {
                        DateTime TestDate = DateTime.Parse(TrainInfo.DepartureTime);
                        if (TestDate.Hour >= 12 && TestDate.Hour <= 17 && ArrivalTimeOfTrainWithDaysOfCruisingSuitsUs(TrainInfo) && TrainTypeSuitUs(TrainInfo))
                        {
                            BufferForFilteredTrains.Add(TrainInfo);
                        }
                    }
                }
                if (viewModelForTrainFilters.DepartureTimeCheckBoxEveningIsChecked)
                {
                    AtLeastOneCheckBoxIsChecked = true;
                    foreach (TrainWithDaysOfCruising TrainInfo in BufferForFoundTrainsWithDaysOfCruising)
                    {
                        DateTime TestDate = DateTime.Parse(TrainInfo.DepartureTime);
                        if (TestDate.Hour >= 18 && TestDate.Hour <= 23 && ArrivalTimeOfTrainWithDaysOfCruisingSuitsUs(TrainInfo) && TrainTypeSuitUs(TrainInfo))
                        {
                            BufferForFilteredTrains.Add(TrainInfo);
                        }
                    }
                }
                if (viewModelForTrainFilters.DepartureTimeCheckBoxNightIsChecked)
                {
                    AtLeastOneCheckBoxIsChecked = true;
                    foreach (TrainWithDaysOfCruising TrainInfo in BufferForFoundTrainsWithDaysOfCruising)
                    {
                        DateTime TestDate = DateTime.Parse(TrainInfo.DepartureTime);
                        if (TestDate.Hour >= 0 && TestDate.Hour <= 5 && ArrivalTimeOfTrainWithDaysOfCruisingSuitsUs(TrainInfo) && TrainTypeSuitUs(TrainInfo))
                        {
                            BufferForFilteredTrains.Add(TrainInfo);
                        }
                    }
                }
                if (!AtLeastOneCheckBoxIsChecked)
                {
                    foreach (TrainWithDaysOfCruising TrainInfo in BufferForFoundTrainsWithDaysOfCruising)
                    {
                        DateTime TestDate = DateTime.Parse(TrainInfo.ArrivalTime);
                        if (ArrivalTimeOfTrainWithDaysOfCruisingSuitsUs(TrainInfo) && TrainTypeSuitUs(TrainInfo))
                        {
                            BufferForFilteredTrains.Add(TrainInfo);
                        }
                    }
                }
                if (!AtLeastOneCheckBoxIsChecked)
                {
                    ViewModelForTrainFilters.ListOfFoundTrainsForDataGridWhichContainsFoundTrainsWithDaysOfCruising = BufferForFoundTrainsWithDaysOfCruising;
                }
                if (AtLeastOneCheckBoxIsChecked)
                {
                    ViewModelForTrainFilters.ListOfFoundTrainsForDataGridWhichContainsFoundTrainsWithDaysOfCruising = BufferForFilteredTrains;
                }
                LoadedTrainsWithDaysOfCruising = true;
            }
            else
            {

            }
            ViewModelForTrainFilters.ApplyingFiltersEllipseMustBeAnimated = false;
            ViewModelForTrainFilters.VisibilityForAnimatedEclipseForApplyingFilters = Visibility.Collapsed;
            VisibilityForFoundTrainsDataGrid = Visibility.Visible;
            ViewModelForTrainFilters.FiltersMustBeEnabled = true;
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
                SearchOfTrainsWithDaysOfCruisingEnded(null);
            }
            else
            {
                foreach (TrainWithDaysOfCruising CurrentTrainInfo in TransportDBWorker.GetListOfTrainsInfoWithOutDate(DepartureStationComboBoxText, DestinationStationComboBoxText))
                {
                    BufferForFoundTrainsWithDaysOfCruising.Add(CurrentTrainInfo);
                }
                SearchOfTrainsWithDaysOfCruisingEnded(BufferForFoundTrainsWithDaysOfCruising);
            }
        }

        private void SearchOfTrainsWithDate()
        {
            if (!CheckingTheExistenceOfStations())
            {
                SearchOfTrainsWithoutDaysOfCruisingEnded(null);
            }
            else
            {
                foreach (TrainWithoutDaysOfCruising CurrentTrainInfo in TransportDBWorker.GetListOfTrainsInfoWithDate(SelectedDateInCalendarControl, DepartureStationComboBoxText, DestinationStationComboBoxText))
                {
                    BufferForFoundTrainsWithoutDaysOfCruising.Add(CurrentTrainInfo);
                }
                SearchOfTrainsWithoutDaysOfCruisingEnded(BufferForFoundTrainsWithoutDaysOfCruising);
            }
        }

        private void SearchOfTrainsWithDaysOfCruisingEnded(List<TrainWithDaysOfCruising> FoundTrains)
        {
            if (FoundTrains != null && FoundTrains.Count > 0)
            {
                VisibilityForFoundTrainsDataGrid = Visibility.Visible;
                viewModelForTrainFilters.VisibilityForTrainFilters = Visibility.Visible;
                ForegroundProgramStateLabel = Brushes.Green;
                ProgramStateLabelContent = Texts.LabelProgramStateReady;
                viewModelForTrainFilters.ListOfFoundTrainsForDataGridWhichContainsFoundTrainsWithDaysOfCruising = FoundTrains;
                LoadedTrainsWithDaysOfCruising = true;
            }
            else
            {
                ForegroundProgramStateLabel = Brushes.Red;
                ProgramStateLabelContent = Texts.LabelProgramStateFail;
            }
            VisibilityForSearchTrainsButton = Visibility.Visible;
            SearchDataAnimatedEllipseMustBeAnimated = false;
            VisibilityForSearchDataAnimatedEllipse = Visibility.Collapsed;
            ControlsMustBeEnabled = true;
        }

        private void SearchOfTrainsWithoutDaysOfCruisingEnded(List<TrainWithoutDaysOfCruising> FoundTrains)
        {
            if (FoundTrains != null && FoundTrains.Count > 0)
            {
                VisibilityForFoundTrainsDataGrid = Visibility.Visible;
                viewModelForTrainFilters.VisibilityForTrainFilters = Visibility.Visible;
                ForegroundProgramStateLabel = Brushes.Green;
                ProgramStateLabelContent = Texts.LabelProgramStateReady;
                viewModelForTrainFilters.ListOfFoundTrainsForDataGridWhichContainsFoundTrainsWithoutDaysOfCruising = FoundTrains;
                LoadedTrainsWithDaysOfCruising = false;
                ViewModelForBookingStackPanel.VisibilityForBookingStackPanel = Visibility.Visible;
            }
            else
            {
                ForegroundProgramStateLabel = Brushes.Red;
                ProgramStateLabelContent = Texts.LabelProgramStateFail;
            }
            VisibilityForSearchTrainsButton = Visibility.Visible;
            SearchDataAnimatedEllipseMustBeAnimated = false;
            VisibilityForSearchDataAnimatedEllipse = Visibility.Collapsed;
            ControlsMustBeEnabled = true;
        }

        public void ClickEventHandlerForSearchTrainsButton(object sender, EventArgs e)
        {
            BufferForFoundTrainsWithDaysOfCruising.Clear();
            BufferForFoundTrainsWithoutDaysOfCruising.Clear();
            ViewModelForTrainFilters.ListOfFoundTrainsForDataGridWhichContainsFoundTrainsWithDaysOfCruising = null;
            ViewModelForTrainFilters.ListOfFoundTrainsForDataGridWhichContainsFoundTrainsWithoutDaysOfCruising = null;
            ControlsMustBeEnabled = false;
            ViewModelForBookingStackPanel.VisibilityForBookingStackPanel = Visibility.Collapsed;
            VisibilityForLabelDepartureStationNotFound = Visibility.Collapsed;
            VisibilityForLabelDestinationStationNotFound = Visibility.Collapsed;
            VisibilityForSearchTrainsButton = Visibility.Collapsed;
            VisibilityForFoundTrainsDataGrid = Visibility.Collapsed;
            ViewModelForTrainFilters.VisibilityForTrainFilters = Visibility.Collapsed;
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
            VisibilityForCalendarControl = Visibility.Visible;
            VisibilityForSearchDataAnimatedEllipse = Visibility.Collapsed;
            VisibilityForLabelDepartureStationNotFound = Visibility.Collapsed;
            VisibilityForLabelDestinationStationNotFound = Visibility.Collapsed;
            VisibilityForFoundTrainsDataGrid = Visibility.Collapsed;

            DepartureStationComboBoxText = Texts.ComboBoxChooseStation;
            DestinationStationComboBoxText = Texts.ComboBoxChooseStation;
            ForegroundDepartureStationComboBox = Brushes.Gray;
            ForegroundDestinationStationComboBox = Brushes.Gray;

            ForegroundProgramStateLabel = Brushes.Orange;
            ProgramStateLabelContent = string.Empty;

            SearchDataAnimatedEllipseMustBeAnimated = false;
            ControlsMustBeEnabled = true;

            CheckBoxAllDaysIsChecked = false;
            LoadedTrainsWithDaysOfCruising = true;

            BufferForFoundTrainsWithoutDaysOfCruising = new List<TrainWithoutDaysOfCruising>();
            BufferForFoundTrainsWithDaysOfCruising = new List<TrainWithDaysOfCruising>();

            ListOfStations = new List<string>();
            ListOfStations.Add(Texts.TextStationStillLoading);

            SelectedDateInCalendarControl = DateTime.Now;

            ThreadPool.QueueUserWorkItem(o => LoadNamesOfStationsFromTransportDB());
        }
    }
}
