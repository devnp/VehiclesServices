using System.Collections.ObjectModel;
using System.Reflection;
namespace VehiclesClassification
{
    public struct VehiclesData
    {
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public Enums.FuelType Fuel { get; set; }
    }

    public abstract class Vehicle
    {
        public VehiclesData vehiclesData;

        protected ObservableCollection<string> ServicesLogs { get; set; }

        protected IWashService WashService { get; set; }

        public Vehicle(VehiclesData vehicleDataInput)
        {
            this.vehiclesData = vehicleDataInput;
        }

        #region Public Methods
        public void StartServiceMethod(Enums.ServiceActions action, ObservableCollection<string> logs)
        {
            this.ServicesLogs = logs;
            logs.Add(string.Format("Service <{0}>started\n", action.ToString()));

            var methodInfo = this.GetType().GetMethod(action.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(this, null);

            logs.Add(string.Format("\nService <{0}>finished\n", action.ToString()));
        }

        public void SetWashMethod(IWashService newWashMethod)
        {
            this.WashService = newWashMethod;
        }

        #endregion

        #region Methods
        protected abstract void CheckTiresPressure();

        protected virtual void Refuel()
        {
            this.ServicesLogs.Add(string.Format("Refueling {0}.. \nFuel type: {1}", this.GetType().Name, this.vehiclesData.Fuel));
        }

        protected virtual void CheckLights()
        {
            this.ServicesLogs.Add("Checking vehicle's lights...");
        }

        protected virtual void CheckBrakes()
        {
            this.ServicesLogs.Add("Checking vehicle's brakes...");
        }

        protected virtual void ChangeEngineOil()
        {
            this.ServicesLogs.Add("Changing vehicle's engine oil...");
        }

        protected virtual void Wash()
        {
            string logs;
            this.WashService.Wash(out logs);
            this.ServicesLogs.Add(logs);
        }

        #endregion
    }
}
