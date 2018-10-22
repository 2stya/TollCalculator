using FluentAssertions;
using NUnit.Framework;
using TollCalculator.HourlyFee.TollFree;
using TollCalculator.Vehicles;

namespace TollCalculator.Tests
{
    [TestFixture]
    public class SwedenTollFreeVehicleTests
    {
        [Test]
        public void IsTollFree_WhenPrivate_ShouldReturnTrue()
        {
            // Arrange
            ITollFreeVehicleProvider freeVehicleProvider = CreateSwedenTollFreeVehicle();
            Vehicle vehicle = new Vehicle(VehicleType.Private);

            // Act & Assert
            freeVehicleProvider.IsTollFree(vehicle.VehicleType).Should().BeFalse();
        }

        [Test]
        [TestCase(VehicleType.Motorbike)]
        [TestCase(VehicleType.Diplomat)]
        [TestCase(VehicleType.Emergency)]
        [TestCase(VehicleType.Foreign)]
        [TestCase(VehicleType.Military)]
        [TestCase(VehicleType.Tractor)]
        public void IsTollFree_WhenTollFree_ShouldReturnTrue(VehicleType vehicleType)
        {
            // Arrange
            // Arrange
            ITollFreeVehicleProvider freeVehicleProvider = CreateSwedenTollFreeVehicle();
            Vehicle vehicle = new Vehicle(vehicleType);

            // Act & Assert
            freeVehicleProvider.IsTollFree(vehicle.VehicleType).Should().BeTrue();
        }

        [Test]
        public void IsTollFree_WhenPrivate_ShouldReturnFalse()
        {
            // Arrange
            ITollFreeVehicleProvider freeVehicleProvider = CreateSwedenTollFreeVehicle();
            Vehicle vehicle = new Vehicle(VehicleType.Private);

            // Act & Assert
            freeVehicleProvider.IsTollFree(vehicle.VehicleType).Should().BeFalse();
        }

        private static ITollFreeVehicleProvider CreateSwedenTollFreeVehicle()
        {
            return new SwedenTollFreeVehicleProvider();
        }
    }
}
