using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesClassification
{
    public static class Enums
    {
        public enum ServiceActions
        {
            CheckLights,
            CheckBrakes,
            CheckTiresPressure,
            ChangeEngineOil,
            Refuel,
            Wash
        }

        public enum FuelType
        {
            Diesel,
            Petrol,
            Gas
        }

        public enum VehicleType
        {
            Car,
            Trunk,
            Motorcycle
        }
    }
}
