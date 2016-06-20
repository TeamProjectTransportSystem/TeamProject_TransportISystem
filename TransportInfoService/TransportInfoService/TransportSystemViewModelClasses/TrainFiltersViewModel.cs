using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TransportInfoService.Resources;
using TransportInfoService.TransportSystemLogicClasses;

namespace TransportInfoService.TransportSystemViewModelClasses
{
    public class TrainFiltersViewModel : INotifyPropertyChanged
    {
        private List<ITrainInfo> listOfFoundTrainsForDataGridWhichContainsFoundTrains;
        private bool applyingFiltersEllipseMustBeAnimated;

        private Visibility visibilityForAnimatedEclipseForApplyingFilters;
        private Visibility visibilityForTrainFilters;

        private bool departureTimeCheckBoxMorningIsChecked;
        private bool departureTimeCheckBoxDayIsChecked;
        private bool departureTimeCheckBoxEveningIsChecked;
        private bool departureTimeCheckBoxNightIsChecked;

        private bool arrivalTimeCheckBoxMorningIsChecked;
        private bool arrivalTimeCheckBoxDayIsChecked;
        private bool arrivalTimeCheckBoxEveningIsChecked;
        private bool arrivalTimeCheckBoxNightIsChecked;

        private bool economTrainTypeCheckBoxIsChecked;
        private bool businessTrainTypeCheckBoxIsChecked;

        public Visibility VisibilityForTrainFilters
        {
            get
            {
                return visibilityForTrainFilters;
            }

            set
            {
                visibilityForTrainFilters = value;
                NotifyPropertyChanged();
            }
        }

        public bool DepartureTimeCheckBoxMorningIsChecked
        {
            get
            {
                return departureTimeCheckBoxMorningIsChecked;
            }

            set
            {
                departureTimeCheckBoxMorningIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool DepartureTimeCheckBoxDayIsChecked
        {
            get
            {
                return departureTimeCheckBoxDayIsChecked;
            }

            set
            {
                departureTimeCheckBoxDayIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool DepartureTimeCheckBoxEveningIsChecked
        {
            get
            {
                return departureTimeCheckBoxEveningIsChecked;
            }

            set
            {
                departureTimeCheckBoxEveningIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool DepartureTimeCheckBoxNightIsChecked
        {
            get
            {
                return departureTimeCheckBoxNightIsChecked;
            }

            set
            {
                departureTimeCheckBoxNightIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool ArrivalTimeCheckBoxMorningIsChecked
        {
            get
            {
                return arrivalTimeCheckBoxMorningIsChecked;
            }

            set
            {
                arrivalTimeCheckBoxMorningIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool ArrivalTimeCheckBoxDayIsChecked
        {
            get
            {
                return arrivalTimeCheckBoxDayIsChecked;
            }

            set
            {
                arrivalTimeCheckBoxDayIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool ArrivalTimeCheckBoxEveningIsChecked
        {
            get
            {
                return arrivalTimeCheckBoxEveningIsChecked;
            }

            set
            {
                arrivalTimeCheckBoxEveningIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool ArrivalTimeCheckBoxNightIsChecked
        {
            get
            {
                return arrivalTimeCheckBoxNightIsChecked;
            }

            set
            {
                arrivalTimeCheckBoxNightIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool EconomTrainTypeCheckBoxIsChecked
        {
            get
            {
                return economTrainTypeCheckBoxIsChecked;
            }

            set
            {
                economTrainTypeCheckBoxIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public bool BusinessTrainTypeCheckBoxIsChecked
        {
            get
            {
                return businessTrainTypeCheckBoxIsChecked;
            }

            set
            {
                businessTrainTypeCheckBoxIsChecked = value;
                NotifyPropertyChanged();
            }
        }

        public Visibility VisibilityForAnimatedEclipseForApplyingFilters
        {
            get 
            { 
                return visibilityForAnimatedEclipseForApplyingFilters; 
            }
            set
            {
                visibilityForAnimatedEclipseForApplyingFilters = value;
                NotifyPropertyChanged();
            }
        }

        public List<ITrainInfo> ListOfFoundTrainsForDataGridWhichContainsFoundTrains
        {
            get
            {
                return listOfFoundTrainsForDataGridWhichContainsFoundTrains;
            }

            set
            {
                listOfFoundTrainsForDataGridWhichContainsFoundTrains = value;
                NotifyPropertyChanged();
            }
        }

        public bool ApplyingFiltersEllipseMustBeAnimated
        {
            get 
            { 
                return applyingFiltersEllipseMustBeAnimated; 
            }
            set 
            { 
                applyingFiltersEllipseMustBeAnimated = value;
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

        public TrainFiltersViewModel()
        {
            VisibilityForTrainFilters = Visibility.Visible;
            VisibilityForAnimatedEclipseForApplyingFilters = Visibility.Collapsed;

            DepartureTimeCheckBoxMorningIsChecked = false;
            DepartureTimeCheckBoxDayIsChecked = false;
            DepartureTimeCheckBoxEveningIsChecked = false;
            DepartureTimeCheckBoxNightIsChecked = false;

            ArrivalTimeCheckBoxMorningIsChecked = false;
            ArrivalTimeCheckBoxDayIsChecked = false;
            ArrivalTimeCheckBoxEveningIsChecked = false;
            ArrivalTimeCheckBoxNightIsChecked = false;

            EconomTrainTypeCheckBoxIsChecked = false;
            BusinessTrainTypeCheckBoxIsChecked = false;

            ListOfFoundTrainsForDataGridWhichContainsFoundTrains = new List<ITrainInfo>();

            ApplyingFiltersEllipseMustBeAnimated = false;
        }
    }
}
