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

        [Test]
        public void IsTollFree_WhenPrivate_ShouldReturnTrue()
        {
            // Arrange
            Vehicle vehicle = new Vehicle(VehicleType.Private);

            // Act & Assert
            vehicle.IsTollFree.Should().BeFalse();
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
            Vehicle vehicle = new Vehicle(vehicleType);

            // Act & Assert
            vehicle.IsTollFree.Should().BeTrue();
        }

        [Test]
        public void IsTollFree_WhenPrivate_ShouldReturnFalse()
        {
            // Arrange
            Vehicle vehicle = new Vehicle(VehicleType.Private);

            // Act & Assert
            vehicle.IsTollFree.Should().BeFalse();
        }
    }
}