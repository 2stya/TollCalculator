using System;
using FluentAssertions;
using NUnit.Framework;
using TollCalculator.HourlyFee;
using TollCalculator.HourlyFee.TollFree;

namespace TollCalculator.Tests.HourlyFeeHelper
{
    [TestFixture]
    public class SwedenHourlyFeeTests
    {
        [Test]
        public void Ctor_WhenTollFreeDaysIsNull_Throws()
        {
            // Arrange
            Action hourlyFeeWithNullTollFreeDaysProvider = () => new SwedenHourlyFee(null, new SwedenTollFreeVehicleProvider());

            // Act & Assert
            hourlyFeeWithNullTollFreeDaysProvider.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null.\nParameter name: freeDaysProvider");
        }

        [Test]
        public void Ctor_WhenTollFreeVehicleIsNull_Throws()
        {
            // Arrange
            Action hourlyFeeWithNullTollFreeDaysProvider = () => new SwedenHourlyFee(new SwedenTollFreeDaysProvider(), null);

            // Act & Assert
            hourlyFeeWithNullTollFreeDaysProvider.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null.\nParameter name: freeVehicleProvider");
        }
    }
}