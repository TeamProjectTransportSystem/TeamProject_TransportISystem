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

namespace TransportInfoService.TransportSystemViewModelClasses
{
    public class TrainFiltersViewModel : INotifyPropertyChanged
    {
        private Visibility visibilityForTrainFilters;

        private bool departureTimeCheckBoxMorningIsChecked;
        private bool departureTimeCheckBoxDayIsChecked;
        private bool departureTimeCheckBoxEveningIsChecked;
        private bool departureTimeCheckBoxNightIsChecked;

        private bool arrivalTimeCheckBoxMorningIsChecked;
        private bool arrivalTimeCheckBoxDayIsChecked;
        private bool arrivalTimeCheckBoxEveningIsChecked;
        private bool arrivalTimeCheckBoxNightIsChecked;

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

        public void CheckedEventHandlerForDepartureTimeCheckBoxes(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Name == NamesOfVariables.CheckBoxDepartureTimeMorningName)
            {
                DepartureTimeCheckBoxDayIsChecked = false;
                DepartureTimeCheckBoxEveningIsChecked = false;
                DepartureTimeCheckBoxNightIsChecked = false;
            }
            else if ((sender as CheckBox).Name == NamesOfVariables.CheckBoxDepartureTimeDayName)
            {

                DepartureTimeCheckBoxMorningIsChecked = false;
                DepartureTimeCheckBoxEveningIsChecked = false;
                DepartureTimeCheckBoxNightIsChecked = false;
            }
            else if ((sender as CheckBox).Name == NamesOfVariables.CheckBoxDepartureTimeEveningName)
            {
                DepartureTimeCheckBoxDayIsChecked = false;
                DepartureTimeCheckBoxMorningIsChecked = false;
                DepartureTimeCheckBoxNightIsChecked = false;
            }
            else if ((sender as CheckBox).Name == NamesOfVariables.CheckBoxDepartureTimeNightName)
            {
                DepartureTimeCheckBoxDayIsChecked = false;
                DepartureTimeCheckBoxEveningIsChecked = false;
                DepartureTimeCheckBoxMorningIsChecked = false;
            }
        }

        public void CheckedEventHandlerForArrivalTimeCheckBoxes(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Name == NamesOfVariables.CheckBoxArrivalTimeMorningName)
            {
                ArrivalTimeCheckBoxDayIsChecked = false;
                ArrivalTimeCheckBoxEveningIsChecked = false;
                ArrivalTimeCheckBoxNightIsChecked = false;
            }
            else if ((sender as CheckBox).Name == NamesOfVariables.CheckBoxArrivalTimeDayName)
            {

                ArrivalTimeCheckBoxMorningIsChecked = false;
                ArrivalTimeCheckBoxEveningIsChecked = false;
                ArrivalTimeCheckBoxNightIsChecked = false;
            }
            else if ((sender as CheckBox).Name == NamesOfVariables.CheckBoxArrivalTimeEveningName)
            {
                ArrivalTimeCheckBoxDayIsChecked = false;
                ArrivalTimeCheckBoxMorningIsChecked = false;
                ArrivalTimeCheckBoxNightIsChecked = false;
            }
            else if ((sender as CheckBox).Name == NamesOfVariables.CheckBoxArrivalTimeNightName)
            {
                ArrivalTimeCheckBoxDayIsChecked = false;
                ArrivalTimeCheckBoxEveningIsChecked = false;
                ArrivalTimeCheckBoxMorningIsChecked = false;
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

            DepartureTimeCheckBoxMorningIsChecked = false;
            DepartureTimeCheckBoxDayIsChecked = false;
            DepartureTimeCheckBoxEveningIsChecked = false;
            DepartureTimeCheckBoxNightIsChecked = false;

            ArrivalTimeCheckBoxMorningIsChecked = false;
            ArrivalTimeCheckBoxDayIsChecked = false;
            ArrivalTimeCheckBoxEveningIsChecked = false;
            ArrivalTimeCheckBoxNightIsChecked = false;
        }
    }
}
