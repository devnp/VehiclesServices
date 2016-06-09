namespace VehiclesClassification
{
    public class SelfServiceFacilities : IWashService
    {
        public void Wash(out string logs)
        {
            logs = @"Self-service wash facilities has been chosen. 
This service is assigned to a car by default.
The customer does the washing, including pressurized <jet washing>.";
        }
    }
}
