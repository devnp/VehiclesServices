using System;

namespace VehiclesController
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(VehiclesData vehicleDataInput)
            : base(vehicleDataInput)
        {
            this.WashService = new HandWashFacilities();
        }

        protected override void CheckTiresPressure()
        {
            this.ServicesLogs.Add("We have only 2 tires to check");
        }

        protected override void ChangeEngineOil()
        {
            base.ChangeEngineOil();
            this.ServicesLogs.Add("It will be quick action.");
        }
    }
}
