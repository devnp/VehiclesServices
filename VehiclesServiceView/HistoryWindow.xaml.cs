using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using VehiclesController;

namespace VehiclesServiceView
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        ObservableCollection<string> logs = new ObservableCollection<string> { "Choose parameters" };

        public HistoryWindow()
        {
            InitializeComponent();

            this.logs = new ObservableCollection<string>();

            DataContext = this;
        }

        private void SelectRegNoChecked(object sender, RoutedEventArgs e)
        {
            this.RegNoHistoryTextBox.Visibility = Visibility.Visible;
        }

        private void SelectRegNoUnChecked(object sender, RoutedEventArgs e)
        {
            this.RegNoHistoryTextBox.Visibility = Visibility.Collapsed;
        }

        private void ViewHistoryButtonClick(object sender, RoutedEventArgs e)
        {
            this.logs.Clear();
            this.LogsScrollViewer.Content = "";
            var radioButtonChecked = this.HistoryTypePanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.Value);

            this.logs = new ObservableCollection<string>(this.SelectHistoryLogs(radioButtonChecked.Name));

            StringBuilder builder = new StringBuilder();

            logs.ToList().ForEach(x => builder.Append(string.Format("{0}\n", x)));
           
            this.LogsScrollViewer.Content = builder.ToString();
        }

        private IEnumerable<string> SelectHistoryLogs(string radioButtonName)
        {
            HistoryOperations history = new HistoryOperations();
            IEnumerable<string> logsEntry;

            switch (radioButtonName)
            {
                case "AllRadioButton":
                    logsEntry = history.ReadAllHistoryLog();
                    break;
                case "RegNoRadioButton":
                    if(string.IsNullOrEmpty(this.RegNoHistoryTextBox.Text))
                    {
                        return new List<string> { "Enter register number!" };
                    }

                    logsEntry = history.SelectLogsEntry(this.RegNoHistoryTextBox.Text);
                    break;
                default:
                    return new List<string> { "Problem with history selection" };
            }

            return logsEntry;
        }

        private void BackFromHistory(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }
    }
}
