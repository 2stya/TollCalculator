using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;
using TollCalculator.CalendarHelper;
using TollCalculator.Vehicles;

namespace TollCalculator.Tests
{
    [TestFixture]
    public class TollCalculatorTests
    {
        [Test]
        public void Ctor_WhenTollFreeProviderIsNull_Throws()
        {
            // Arrange
            Action calcWithNullTollFreeProvider = () => new TollCalculator(null);

            // Act & Assert
            calcWithNullTollFreeProvider.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null.\nParameter name: freeDaysProvider");
        }

        [Test]
        [TestCase("07/10/2018 06:00")]
        [TestCase("07/10/2018 06:05")]
        [TestCase("07/10/2018 06:29")]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom600To629AM_Returns9(string passingDateTime)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse(passingDateTime, CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(9);
        }

        [Test]
        [TestCase("07/10/2018 06:30")]
        [TestCase("07/10/2018 06:44")]
        [TestCase("07/10/2018 06:59")]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom630To659AM_Returns16(string passingDateTime)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse(passingDateTime, CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(16);
        }

        [Test]
        [TestCase("07/10/2018 07:00")]
        [TestCase("07/10/2018 07:54")]
        [TestCase("07/10/2018 07:59")]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom700To759AM_Returns22(string passingDateTime)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse(passingDateTime, CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(22);
        }

        [Test]
        [TestCase("07/10/2018 08:00")]
        [TestCase("07/10/2018 08:25")]
        [TestCase("07/10/2018 08:29")]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom800To829AM_Returns16(string passingDateTime)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse(passingDateTime, CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(16);
        }

        [Test]
        [TestCase("07/10/2018 08:30")]
        [TestCase("07/10/2018 12:00")]
        [TestCase("07/10/2018 14:59")]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom830To1459AM_Returns9(string passingDateTime)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse(passingDateTime, CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(9);
        }

        [Test]
        [TestCase("07/10/2018 15:00")]
        [TestCase("07/10/2018 15:10")]
        [TestCase("07/10/2018 15:29")]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom1500To1529_Returns16(string passingDateTime)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse(passingDateTime, CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(16);
        }

        [Test]
        [TestCase("07/10/2018 15:30")]
        [TestCase("07/10/2018 15:59")]
        [TestCase("07/10/2018 16:59")]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom1530To1659_Returns22(string passingDateTime)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse(passingDateTime, CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(22);
        }

        [Test]
        [TestCase("07/10/2018 17:00")]
        [TestCase("07/10/2018 17:09")]
        [TestCase("07/10/2018 17:59")]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom1700To1759_Returns16(string passingDateTime)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse(passingDateTime, CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(16);
        }

        [Test]
        [TestCase("07/10/2018 18:00")]
        [TestCase("07/10/2018 18:13")]
        [TestCase("07/10/2018 18:29")]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom1800To1829_Returns9(string passingDateTime)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse(passingDateTime, CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(9);
        }

        [Test]
        [TestCase("07/10/2018 18:30")]
        [TestCase("07/10/2018 00:00")]
        [TestCase("07/10/2018 05:59")]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom1830To0559_Returns0(string passingDateTime)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse(passingDateTime, CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(0);
        }

        [Test]
        public void GetTollFee_WhenPrivateCarOnSaturday_Returns0()
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse("07/14/2018 18:30", CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(0);
        }

        [Test]
        public void GetTollFee_WhenPrivateCarOnSunday_Returns0()
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { DateTime.Parse("07/15/2018 18:30", CultureInfo.InvariantCulture) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(0);
        }

        [Test]
        public void GetTollFee_WhenPrivateCarNotHolidayALotOfPasses_Returns60()
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = 
            {
                DateTime.Parse("07/10/2018 00:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 01:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 02:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 03:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 04:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 05:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 06:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 07:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 08:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 09:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 10:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 11:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 12:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 13:30", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 14:30", CultureInfo.InvariantCulture)
            };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(60);
        }

        [Test]
        public void GetTollFee_WhenPrivateCarNotHolidayPassesTwiceWithinAnHour_ReturnsFeeOnce()
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] twicePassingDateTime = {
                DateTime.Parse("07/10/2018 09:00", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 09:54", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 10:01", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 10:06", CultureInfo.InvariantCulture),
                DateTime.Parse("07/10/2018 11:06", CultureInfo.InvariantCulture),
            };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), twicePassingDateTime);

            // Assert
            tollFee.Should().Be(27);
        }

        [Test]
        public void GetTollFee_WhenDifferentDatesOccurs_Throws()
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] differentDaysPassingDateTime = {
                DateTime.Parse("07/10/2018 18:00", CultureInfo.InvariantCulture),
                DateTime.Parse("09/10/2018 17:54", CultureInfo.InvariantCulture),
            };
            Action getTollFee = () => calc.GetTollFee(new Vehicle(VehicleType.Private), differentDaysPassingDateTime);

            // Assert
            getTollFee.Should().Throw<ArgumentException>()
                .WithMessage("Only one date should be presented to calculate toll fee.");
        }

        [Test]
        public void GetTollFee_WhenVehicleIsNull_Throws()
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = {
                DateTime.Parse("07/10/2018 18:00", CultureInfo.InvariantCulture),
                DateTime.Parse("09/10/2018 17:54", CultureInfo.InvariantCulture)
            };
            Action getTollFee = () => calc.GetTollFee(null, oncePassingDateTime);

            // Assert
            getTollFee.Should().Throw<ArgumentException>()
                .WithMessage("Value cannot be null.\nParameter name: vehicle");
        }

        [Test]
        public void GetTollFee_WhenDatesIsNull_Throws()
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            Action getTollFee = () => calc.GetTollFee(new Vehicle(VehicleType.Private), null);

            // Assert
            getTollFee.Should().Throw<ArgumentException>()
                .WithMessage("No datetimes detected for vehicle");
        }

        private static TollCalculator CreateSwedenTollCalculator()
        {
            return new TollCalculator(new SwedenTollFreeDaysProvider());
        }
    }
}