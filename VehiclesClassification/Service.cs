using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesClassification;

namespace VehiclesClassification
{
    public class Service
    {
        Vehicle vehicle;

        IEnumerable<Enums.ServiceActions> servicesList;

        public Service(Enums.VehicleType vehicleType, VehiclesData vehicleDataInput, IEnumerable<Enums.ServiceActions> actions)
        {
            this.servicesList = actions;
            this.CreateVehicleInstance(vehicleType, vehicleDataInput); 
        }

        public void ExecuteServices(ObservableCollection<string> logs)
        {
            foreach (var action in servicesList)
            {
                this.vehicle.StartServiceMethod(action, logs);
            }

            this.AddServiceToHistory();
        }

        public void AddServiceToHistory()
        {
            string path = Path.GetFullPath("history.txt");

            using (StreamWriter sw = File.AppendText(path))
            {
                StringBuilder log = new StringBuilder();
                log.Append(string.Format("|{0}| ", DateTime.Now));
                log.Append(string.Format("RegNo: {0} |", vehicle.vehiclesData.RegistrationNumber));
                log.Append(string.Format("Make: {0} |", vehicle.vehiclesData.Make));
                log.Append(string.Format("Model: {0} |", vehicle.vehiclesData.Model));
                log.Append(string.Format("Year: {0} |", vehicle.vehiclesData.Year));
                log.Append(string.Format("Fuel: {0} |", vehicle.vehiclesData.Fuel));
                log.Append("Services: ");
                servicesList.ToList().ForEach(x => log.Append(string.Format("{0}; ", x.ToString())));
                sw.WriteLine(log.ToString());
            }
        }

        private void CreateVehicleInstance(Enums.VehicleType vehicleType, VehiclesData vehicleDataInput)
        {
            switch (vehicleType)
            {
                case Enums.VehicleType.Car:
                    this.vehicle = new Car(vehicleDataInput);
                    break;
                case Enums.VehicleType.Trunk:
                    this.vehicle = new Trunk(vehicleDataInput);
                    break;
                case Enums.VehicleType.Motorcycle:
                    this.vehicle = new Motorcycle(vehicleDataInput);
                    break;
                default:
                    throw new Exception(string.Format("Unexpected vehicle type: {0}", vehicleType.ToString()));
            }
        }
    }
}
