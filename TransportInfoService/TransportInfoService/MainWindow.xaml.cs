using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            List<string> StationTypes = new List<string>();

            using (TransportDBContext CurrentDBContext = new TransportDBContext(NamesOfVariables.ConnectionStringOldVersion) )
            {
                foreach (StationType CurrentStationType in CurrentDBContext.ListOfStationTypes)
                {
                    StationTypes.Add(CurrentStationType.Name);
                }
            }

            //TestListBox.ItemsSource = StationTypes;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
