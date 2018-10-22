using FluentAssertions;
using NUnit.Framework;
using TollCalculator.Vehicles;

namespace TollCalculator.Tests
{
    [TestFixture]
    public class VehicleTests
    {
        [Test]
        [TestCase(VehicleType.Motorbike)]
        [TestCase(VehicleType.Diplomat)]
        [TestCase(VehicleType.Emergency)]
        [TestCase(VehicleType.Foreign)]
        [TestCase(VehicleType.Military)]
        [TestCase(VehicleType.Private)]
        [TestCase(VehicleType.Tractor)]
        public void Ctor_WithCorrectVehicleType_ShouldReturnNewVehicle(VehicleType vehicleType)
        {
            // Arrange
            Vehicle vehicle = new Vehicle(vehicleType);

            // Act & Assert
            vehicle.VehicleType.Should().Be(vehicleType);
        }
    }
}