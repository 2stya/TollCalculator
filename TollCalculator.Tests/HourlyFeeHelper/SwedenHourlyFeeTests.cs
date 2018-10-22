using System;
using FluentAssertions;
using NUnit.Framework;
using TollCalculator.HourlyFeeHelper;

namespace TollCalculator.Tests.HourlyFeeHelper
{
    [TestFixture]
    public class SwedenHourlyFeeTests
    {
        [Test]
        public void Ctor_WhenIsNull_Throws()
        {
            // Arrange
            Action hourlyFeeWithNullTollFreeDaysProvider = () => new SwedenHourlyFee(null);

            // Act & Assert
            hourlyFeeWithNullTollFreeDaysProvider.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null.\nParameter name: freeDaysProvider");
        }
    }
}