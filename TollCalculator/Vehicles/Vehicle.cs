using System;

namespace TollCalculator.Vehicles
{
    public class Vehicle
    {
        public VehicleType VehicleType { get; }

        public bool IsTollFree => Enum.IsDefined(typeof(VehiclesTollFree), VehicleType.ToString());

        public Vehicle(VehicleType vehicleType)
        {
            VehicleType = vehicleType;
        }
    }

    public enum VehiclesTollFree
    {
        Motorbike = 0,
        Tractor = 1,
        Emergency = 2,
        Diplomat = 3,
        Foreign = 4,
        Military = 5
    }

    public enum VehicleType
    {
        Motorbike,
        Tractor,
        Emergency,
        Diplomat,
        Foreign,
        Military,
        Private
    }
}