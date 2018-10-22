namespace TollCalculator.Vehicles
{
    public class Vehicle
    {
        public VehicleType VehicleType { get; }

        public Vehicle(VehicleType vehicleType)
        {
            VehicleType = vehicleType;
        }
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