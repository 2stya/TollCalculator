using FluentAssertions;
using NUnit.Framework;
using TollCalculator.Vehicles;

namespace TollCalculator.Tests
{
    public class MotorbikeTests
    {
        [Test]
        public void GetVehicleType_ShouldReturnMotorbike()
        {
            // Arrange
            IVehicle motorbike = new Motorbike();

            // Act & Assert
            motorbike.GetVehicleType().Should().Be("Motorbike");
        }

        [Test]
        public void IsTollFree_ShouldReturnTrue()
        {
            // Arrange
            IVehicle motorbike = new Motorbike();

            // Act & Assert
            motorbike.IsTollFree.Should().BeTrue();
        }
    }
}