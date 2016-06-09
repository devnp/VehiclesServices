using System;

namespace VehiclesController
{
    public class Auto : Vehicle
    {
        public Auto(VehiclesData vehicleDataInput)
            : base(vehicleDataInput)
        { }

        protected override void CheckTiresPressure()
        {
            Console.WriteLine("We have more axles here.");
        }
    }
}
