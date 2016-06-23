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
    public class BookingViewModel : INotifyPropertyChanged
    {
        private Visibility visibilityForBookingStackPanel;
        private Visibility visibilityForLoginAndRegistrationControls;
        private Visibility visibilityForLabelRegistrationFailedBecauseOfLogin;
        private Visibility visibilityForLabelRegistrationFailedDuringEmailValidation;
        private Visibility visibilityForFirstLabelRegistrationFailedDuringPasswordValidation;
        private Visibility visibilityForSecondLabelRegistrationFailedDuringPasswordValidation;
        private Visibility visibilityForStackPanelWithWaitAnimationForLoginAndRegistration;

        private string loginOfUserAlreadyLoggedIn;
        private string loginInLoginTextBox;
        private string loginInRegistrationTextBox;
        private string passwordInLoginPasswordBox;
        private string emailInRegistrationTextBox;
        private string passwordInFirstRegistrationPasswordBox;
        private string passwordInSecondRegistrationPasswordBox;
        private string contentOfLabelRegistrationFailedBecauseOfLogin;
        private string contentOfLabelRegistrationFailedDuringEmailValidation;
        private string contentOfFirstLabelRegistrationFailedDuringPasswordValidation;
        private string contentOfSecondLabelRegistrationFailedDuringPasswordValidation;

        private bool ellipseForLoginAndRegistrationMustBeAnimated;

        public string LoginInRegistrationTextBox
        {
            get 
            { 
                return loginInRegistrationTextBox; 
            }

            set 
            {
                loginInRegistrationTextBox = value;
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
        public string LoginInLoginTextBox
        {
            get 
            {
                return loginInLoginTextBox; 
            }

            set 
            {
                loginInLoginTextBox = value;
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

        public string PasswordInLoginPasswordBox
        {
            get
            {
                return passwordInLoginPasswordBox;
            }

            set
            {
                passwordInLoginPasswordBox = value;
                NotifyPropertyChanged();
            }
        }

        public string PasswordInFirstRegistrationPasswordBox
        {
            get
            {
                return passwordInFirstRegistrationPasswordBox;
            }

            set
            {
                passwordInFirstRegistrationPasswordBox = value;
                NotifyPropertyChanged();
            }
        }

        public string PasswordInSecondRegistrationPasswordBox
        {
            get
            {
                return passwordInSecondRegistrationPasswordBox;
            }

            set
            {
                passwordInSecondRegistrationPasswordBox = value;
                NotifyPropertyChanged();
            }
        }

        public string EmailInRegistrationTextBox
        {
            get
            {
                return emailInRegistrationTextBox;
            }

            set
            {
                emailInRegistrationTextBox = value;
                NotifyPropertyChanged();
            }
        }

        public Visibility VisibilityForLabelRegistrationFailedBecauseOfLogin
        {
            get
            {
                return visibilityForLabelRegistrationFailedBecauseOfLogin;
            }

            set
            {
                visibilityForLabelRegistrationFailedBecauseOfLogin = value;
                NotifyPropertyChanged();
            }
        }

        public string ContentOfLabelRegistrationFailedBecauseOfLogin
        {
            get
            {
                return contentOfLabelRegistrationFailedBecauseOfLogin;
            }

            set
            {
                contentOfLabelRegistrationFailedBecauseOfLogin = value;
                NotifyPropertyChanged();
            }
        }

        public Visibility VisibilityForLabelRegistrationFailedDuringEmailValidation
        {
            get
            {
                return visibilityForLabelRegistrationFailedDuringEmailValidation;
            }

            set
            {
                visibilityForLabelRegistrationFailedDuringEmailValidation = value;
                NotifyPropertyChanged();
            }
        }

        public string ContentOfLabelRegistrationFailedDuringEmailValidation
        {
            get
            {
                return contentOfLabelRegistrationFailedDuringEmailValidation;
            }

            set
            {
                contentOfLabelRegistrationFailedDuringEmailValidation = value;
                NotifyPropertyChanged();
            }
        }

        public Visibility VisibilityForFirstLabelRegistrationFailedDuringPasswordValidation
        {
            get
            {
                return visibilityForFirstLabelRegistrationFailedDuringPasswordValidation;
            }

            set
            {
                visibilityForFirstLabelRegistrationFailedDuringPasswordValidation = value;
                NotifyPropertyChanged();
            }
        }

        public string ContentOfFirstLabelRegistrationFailedDuringPasswordValidation
        {
            get
            {
                return contentOfFirstLabelRegistrationFailedDuringPasswordValidation;
            }

            set
            {
                contentOfFirstLabelRegistrationFailedDuringPasswordValidation = value;
                NotifyPropertyChanged();
            }
        }

        public Visibility VisibilityForSecondLabelRegistrationFailedDuringPasswordValidation
        {
            get
            {
                return visibilityForSecondLabelRegistrationFailedDuringPasswordValidation;
            }

            set
            {
                visibilityForSecondLabelRegistrationFailedDuringPasswordValidation = value;
                NotifyPropertyChanged();
            }
        }

        public string ContentOfSecondLabelRegistrationFailedDuringPasswordValidation
        {
            get
            {
                return contentOfSecondLabelRegistrationFailedDuringPasswordValidation;
            }

            set
            {
                contentOfSecondLabelRegistrationFailedDuringPasswordValidation = value;
                NotifyPropertyChanged();
            }
        }

        public Visibility VisibilityForStackPanelWithWaitAnimationForLoginAndRegistration
        {
            get
            {
                return visibilityForStackPanelWithWaitAnimationForLoginAndRegistration;
            }

            set
            {
                visibilityForStackPanelWithWaitAnimationForLoginAndRegistration = value;
                NotifyPropertyChanged();
            }
        }

        public bool EllipseForLoginAndRegistrationMustBeAnimated
        {
            get
            {
                return ellipseForLoginAndRegistrationMustBeAnimated;
            }

            set
            {
                ellipseForLoginAndRegistrationMustBeAnimated = value;
                NotifyPropertyChanged();
            }
        }

        public void PasswordChangedEventHandlerForAllPasswordBoxes(object sender, EventArgs e)
        {
            PasswordBox SenderPasswordBox = sender as PasswordBox;
            if (SenderPasswordBox.Name == NamesOfVariables.PasswordBoxForLoginName)
            {
                PasswordInLoginPasswordBox = SenderPasswordBox.Password;
            }
            else if (SenderPasswordBox.Name == NamesOfVariables.PasswordBoxForRegistrationFirstName)
            {
                PasswordInFirstRegistrationPasswordBox = SenderPasswordBox.Password;
            }
            else if (SenderPasswordBox.Name == NamesOfVariables.PasswordBoxForRegistrationSecondName)
            {
                PasswordInSecondRegistrationPasswordBox = SenderPasswordBox.Password;
            }
        }

        public bool CheckRegistrationData()
        {
            return true;
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
            LoginInLoginTextBox = string.Empty;
            LoginInRegistrationTextBox = string.Empty;
            PasswordInLoginPasswordBox = string.Empty;
            PasswordInFirstRegistrationPasswordBox = string.Empty;
            PasswordInSecondRegistrationPasswordBox = string.Empty;
            EmailInRegistrationTextBox = string.Empty;
            ContentOfLabelRegistrationFailedBecauseOfLogin = string.Empty;
            ContentOfLabelRegistrationFailedDuringEmailValidation = string.Empty;
            ContentOfFirstLabelRegistrationFailedDuringPasswordValidation = string.Empty;
            ContentOfSecondLabelRegistrationFailedDuringPasswordValidation = string.Empty;

            VisibilityForLabelRegistrationFailedDuringEmailValidation = Visibility.Collapsed;
            VisibilityForLabelRegistrationFailedBecauseOfLogin = Visibility.Collapsed;
            VisibilityForFirstLabelRegistrationFailedDuringPasswordValidation = Visibility.Collapsed;
            VisibilityForSecondLabelRegistrationFailedDuringPasswordValidation = Visibility.Collapsed;
            VisibilityForStackPanelWithWaitAnimationForLoginAndRegistration = Visibility.Collapsed;

            EllipseForLoginAndRegistrationMustBeAnimated = false;
        }

    }
}
