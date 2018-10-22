using TollCalculator.Vehicles;

namespace TollCalculator.HourlyFee.TollFree
{
    public interface ITollFreeVehicleProvider
    {
        bool IsTollFree(VehicleType vehicleType);
    }
}