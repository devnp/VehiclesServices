namespace VehiclesClassification
{
    public class InBayAutomatics : IWashService
    {
        public void Wash(out string logs)
        {
            logs = @"In-Bay Automatics wash facilities has been chosen. 
This service is assigned to a trunk by default. 
Automatic machine will rolls back and forth over a stationary vehicle.";
        }
    }
}
