using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using VehiclesController;

namespace VehiclesServiceView
{
    /// <summary>
    /// Interaction logic for ServiceExecutionWindow.xaml
    /// </summary>
    public partial class ServiceExecutionWindow : Window
    {
        Service newService;

        public ObservableCollection<string> LogEntries { get; set; }

        public ServiceExecutionWindow(Enums.VehicleType type, VehiclesData vehicleDataInput, List<Enums.ServiceActions> actions)
        {
            InitializeComponent();

            this.LogEntries = new ObservableCollection<string>();

            this.newService = new Service(type, vehicleDataInput, actions);
            
            StringBuilder builder = new StringBuilder(string.Format("Your vehicle info: \nType: {0}"
                + "\nMake: {1} \nModel: {2} \nRegNo: {3} \nYear: {4} \nFuel: {5}"
                + "\n\nYou chose services:", 
                type, vehicleDataInput.Make, vehicleDataInput.Model, vehicleDataInput.RegistrationNumber,vehicleDataInput.Year,vehicleDataInput.Fuel));

            actions.ForEach(x => builder.Append(string.Format("\n{0}", x)));

            this.ServiceInfoLabel.Content = builder.ToString();

            DataContext = this;
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            this.StartButton.IsEnabled = false;
            this.newService.ExecuteServices(this.LogEntries);
            this.FinishButton.IsEnabled = true;
         }

        private void FinishButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
