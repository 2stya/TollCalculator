namespace TollCalculator.Vehicles
{
    public class Car : IVehicle
    {
        private readonly string _vehicleType;

        public Car(string vehicleType)
        {
            _vehicleType = vehicleType;
        }

        public string GetVehicleType()
        {
            return _vehicleType;
        }

        public bool IsTollFree { get; }
    }
}