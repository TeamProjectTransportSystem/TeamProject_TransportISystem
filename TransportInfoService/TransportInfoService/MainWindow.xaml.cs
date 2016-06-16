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

            this.DataContext = new ViewModel();

            List<TrainWithDaysOfCruising> TestListOfTrains = new List<TrainWithDaysOfCruising>();
            TestListOfTrains.Add(new TrainWithDaysOfCruising("Blablabla"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("Hahahaha"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("Gygygygy"));
            FoundTrainsDataGrid.ItemsSource = TestListOfTrains;
            ThreadPool.QueueUserWorkItem(o => Button_Click());
        }

        private void Button_Click()
        {
            Thread.Sleep(3000);
            List<TrainWithDaysOfCruising> TestListOfTrains = new List<TrainWithDaysOfCruising>();
            TestListOfTrains.Add(new TrainWithDaysOfCruising("Blabla"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("Hahha"));
            TestListOfTrains.Add(new TrainWithDaysOfCruising("Ggygy"));
            Application.Current.Dispatcher.Invoke(new Action(() => FoundTrainsDataGrid.ItemsSource = TestListOfTrains));
        }

        /*public List<string> ReturnTrain()
        {

            List<string> listOfTrains = new List<string>();
            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion))

            this.DataContext = new ViewModel();
            List<string> StationTypes = new List<string>();

            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion) )

            {

                foreach(Station s in CurrentDBContext.ListOfStations)
                {
                    listOfTrains.Add(s.Name);
                }
                //var trains = CurrentDBContext.ListOfTrains.Join(CurrentDBContext.ListOfRoutes,
                //                                                  s => s.TrainIDAsString,
                //                                                  c => c.Name,
                //                                                  (s, c) => new
                //                                                  {
                //                                                      NameTrain = s.TrainIDAsString,
                //                                                      StartStation = c.ListOfStations.First(),
                //                                                      FinishStation = c.ListOfStations.Last()
                //                                                  });
                //listOfTrains = CurrentDBContext.ListOfStations.Select(s => s.Name).ToList();
                //listOfTrains = trains;
            }


            return listOfTrains;

            //TestListBox.ItemsSource = StationTypes;

        }*/


    }
}
