using System;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using VehiclesController;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace VehiclesServiceView
{
    /// <summary>
    /// Interaction logic for NewServiceWindow.xaml
    /// </summary>
    public partial class NewServiceWindow : Window
    {
        public class CheckBoxActionClass
        {
            public string CheckBoxText { get; set; }
            public bool IsSelected { get; set; }
        }

        public ObservableCollection<CheckBoxActionClass> CheckBoxesList { get; set; }

        public NewServiceWindow()
        {
            InitializeComponent();
            this.FillYearComboBox();
            this.FillServicesCheckBoxes();
        }

        private void FillYearComboBox()
        {
            int currentYear = DateTime.Now.Year;
            for (int i = 0; i < 25; i++)
            {
                this.YearCombobox.Items.Add((currentYear - i).ToString());
                this.YearCombobox.SelectedIndex = 0;
            }
        }
 
        private void FillServicesCheckBoxes()
        {
            CheckBoxesList = new ObservableCollection<CheckBoxActionClass>();

            foreach(var item in Enum.GetNames(typeof(Enums.ServiceActions)))
            {
                CheckBoxesList.Add(new CheckBoxActionClass { IsSelected = false, CheckBoxText = item });
            }

            this.DataContext = this;
        }

        private void BackFromRegistrationClick(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void StartServiceClick(object sender, RoutedEventArgs e)
        {
            if(!this.VerifyVehicleDataInput())
            {
                return;
            }
            this.PrepareDataAndCreateServiceInstance(); 
        }

        private bool VerifyVehicleDataInput()
        {
            if(string.IsNullOrEmpty(this.ModelTextBox.Text)
                || string.IsNullOrEmpty(this.MakeTextBox.Text)
                || string.IsNullOrEmpty(this.RegNoTextBox.Text))
            {
                MessageBox.Show("Incorrect input. At least one of the vehicle's data is empty.");
                return false;
            }

            var selectedCheckBoxes = this.CheckBoxesList.Where(x => x.IsSelected).ToList();

            if(selectedCheckBoxes.Count < 1)
            {
                MessageBox.Show("None of the services was selected");
                return false;
            }

            return true;
        }

        private void PrepareDataAndCreateServiceInstance()
        {
            var radioButtonChecked = this.VehicleTypePanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.Value);

            Enums.VehicleType vehicleType;
            Enums.VehicleType.TryParse(radioButtonChecked.Content.ToString(), out vehicleType);

            VehiclesData vehicleData = new VehiclesData();
            vehicleData.Make = this.MakeTextBox.Text;
            vehicleData.Model = this.ModelTextBox.Text;
            vehicleData.RegistrationNumber = this.RegNoTextBox.Text.ToUpper().Replace(" ", "");
            vehicleData.Year = this.YearCombobox.SelectedValue.ToString();

            Enums.FuelType fuel;
            Enums.FuelType.TryParse(this.FuelComboBox.Text, out fuel);
            vehicleData.Fuel = fuel;

            var selectedCheckBoxes = this.CheckBoxesList.Where(x => x.IsSelected).ToList();

            List<Enums.ServiceActions> actions = new List<Enums.ServiceActions>();
            selectedCheckBoxes.ForEach(
                x =>
                {
                    Enums.ServiceActions actionItem;
                    Enums.ServiceActions.TryParse(x.CheckBoxText, out actionItem);
                    actions.Add(actionItem);
                });

            Window serviceExecutionWindow = new ServiceExecutionWindow(vehicleType, vehicleData, actions);
            serviceExecutionWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
