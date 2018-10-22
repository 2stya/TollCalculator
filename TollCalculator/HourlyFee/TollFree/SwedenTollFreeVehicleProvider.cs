using System;
using TollCalculator.Vehicles;

namespace TollCalculator.HourlyFee.TollFree
{
    public class SwedenTollFreeVehicleProvider : ITollFreeVehicleProvider
    {
        private enum TollFreeVehicles
        {
            Motorbike = 0,
            Tractor = 1,
            Emergency = 2,
            Diplomat = 3,
            Foreign = 4,
            Military = 5
        }

        public bool IsTollFree(VehicleType vehicleType)
        {
            return Enum.IsDefined(typeof(TollFreeVehicles), vehicleType.ToString());
        }
    }
}