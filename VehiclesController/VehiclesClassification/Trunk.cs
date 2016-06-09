using System;

namespace VehiclesController
{
    public class Trunk : Auto
    {
        public Trunk(VehiclesData vehicleDataInput) 
            : base(vehicleDataInput)
        {
            this.WashService = new InBayAutomatics();
        }

        protected override void CheckTiresPressure()
        {
            base.CheckTiresPressure();
            this.ServicesLogs.Add("Checking preassure in many tires");
        }

        protected override void ChangeEngineOil()
        {
            base.ChangeEngineOil();
            this.ServicesLogs.Add("It will last longer than in cars and motorcycles.");
        }
    }
}
