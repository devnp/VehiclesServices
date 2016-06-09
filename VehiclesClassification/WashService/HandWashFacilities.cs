using System.Collections.ObjectModel;

namespace VehiclesClassification
{
    public class HandWashFacilities : IWashService
    {
        public void Wash(out string logs)
        {
            logs = @"Hand wash facilities has been chosen. 
This service is assigned to a motorcycle by default.
The vehicle is washed by employees.";
        }
    }
}
