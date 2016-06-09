using System.Windows;
using System.Windows.Input;

namespace VehiclesServiceView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewServiceLabelClick(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

            Window newServiceWindow = new NewServiceWindow();
            newServiceWindow.Visibility = Visibility.Visible;

        }

        private void HistoryLabelClick(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

            HistoryWindow historyWindow = new HistoryWindow();
            historyWindow.Visibility = Visibility.Visible;
        }

        private void ReservationLabelClick(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

            NewServiceWindow newServiceWindow = new NewServiceWindow();
            newServiceWindow.Visibility = Visibility.Visible;
        }

        private void CalendarLabelClick(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Hidden;

            NewServiceWindow newServiceWindow = new NewServiceWindow();
            newServiceWindow.Visibility = Visibility.Visible;
        }
    }
}
