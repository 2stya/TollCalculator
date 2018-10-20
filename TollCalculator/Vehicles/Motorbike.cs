using System.Runtime.Remoting.Messaging;

namespace TollCalculator.Vehicles
{
    public class Motorbike : IVehicle
    {
        public bool IsTollFree => true;

        public string GetVehicleType()
        {
            return "Motorbike";
        }
    }
}