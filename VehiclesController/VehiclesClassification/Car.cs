using System;

namespace VehiclesController
{
    public class Car : Auto
    {
        public Car(VehiclesData vehicleDataInput)
            : base(vehicleDataInput)
        {
            this.WashService = new SelfServiceFacilities();
        }

        protected override void CheckTiresPressure()
        {
            base.CheckTiresPressure();
            this.ServicesLogs.Add("Checking preassure in 4 tires");
        }
    }
}
