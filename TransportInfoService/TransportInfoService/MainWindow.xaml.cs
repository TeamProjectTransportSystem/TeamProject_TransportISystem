using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TransportInfoService.DatabaseClasses;
using TransportInfoService.Resources;
using TransportInfoService.TransportSystemLogicClasses;

namespace TransportInfoService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //TestListBox.ItemsSource = TransportDBWorker.GetListOfTrainsInfoWithOutDate("Тракторный", "Городище");

            //Не удалять 3 строки ниже при слиянии проекта
            int AmountOfLogicalCores = Environment.ProcessorCount;
            ThreadPool.SetMinThreads(AmountOfLogicalCores, AmountOfLogicalCores);
            ThreadPool.QueueUserWorkItem(o => ShowTestData());

            this.DataContext = new ViewModel();
            
            //*****************************************************************************************************
            //Creating DB test code
            /*List<Station> TestList = new List<Station>();
            using (TransportDBContext TestDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))
            {
                foreach (Station CurStation in TestDBContext.ListOfStations)
                {
                    TestList.Add(CurStation);
                }
            }*/
            //*****************************************************************************************************
        }

        private void ShowTestData()
        {
            Thread.Sleep(3000);
            List<Object> TestListOfTrains = new List<Object>();
            TestListOfTrains.Add(new TrainWithDaysOfCruising("123D Эконом Минск - Москва", "19:30","20:30", "1:00", "ежедневно"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("432А Бизнес Минск - Киев", "5:45","12:45", "6:00", "понедельник,\n четверг"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("123Б Скоростной Минск - Витебск", "4:09","8:09", "4:00", "суббота,\n воскресенье"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("123D Эконом Минск - Москва", "19:30", "20:30", "1:00", "ежедневно"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("432А Бизнес Минск - Киев", "5:45", "12:45", "6:00", "понедельник,\n четверг"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("123Б Скоростной Минск - Витебск", "4:09", "8:09", "4:00", "суббота,\n воскресенье"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("123D Эконом Минск - Москва", "19:30", "20:30", "1:00", "ежедневно"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("432А Бизнес Минск - Киев", "5:45", "12:45", "6:00", "понедельник,\n четверг"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("123Б Скоростной Минск - Витебск", "4:09", "8:09", "4:00", "суббота,\n воскресенье"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("123D Эконом Минск - Москва", "19:30", "20:30", "1:00", "ежедневно"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("432А Бизнес Минск - Киев", "5:45", "12:45", "6:00", "понедельник,\n четверг"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("123Б Скоростной Минск - Витебск", "4:09", "8:09", "4:00", "суббота,\n воскресенье"));
            Application.Current.Dispatcher.Invoke(new Action(() => FoundTrainsDataGrid.ItemsSource = TestListOfTrains));
        }

        private void TextChangedEventHandlerForComboBoxesWithStations(Object sender, EventArgs e)
        {
            if ((this.DataContext as ViewModel).NoNeedForComboBoxTextChangedEvent)
            {
                (this.DataContext as ViewModel).NoNeedForComboBoxTextChangedEvent = false;
            }
            else if ((sender as ComboBox).Text == string.Empty)
            {
                (sender as ComboBox).Text = Texts.ComboBoxChooseStation;
                (sender as ComboBox).Foreground = Brushes.Gray;
            }
            else if ((sender as ComboBox).Text != Texts.ComboBoxChooseStation)
            {
                (sender as ComboBox).Foreground = Brushes.Black;
            }
        }
    }
}
