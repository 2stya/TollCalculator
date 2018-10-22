using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;
using TollCalculator.HourlyFee;
using TollCalculator.HourlyFee.TollFree;
using TollCalculator.Vehicles;

//TODO Change parse to year, month, day, hour, minute, second

namespace TollCalculator.Tests
{
    [TestFixture]
    public class TollCalculatorTests
    {
        [Test]
        public void Ctor_WhenHourlyFeeProviderIsNull_Throws()
        {
            // Arrange
            Action calcWithNullTollFreeProvider = () => new TollCalculator(null);

            // Act & Assert
            calcWithNullTollFreeProvider.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null.\nParameter name: hourlyFeeProvider");
        }

        [Test]
        [TestCase(2018, 07, 10, 06, 00, 00)]
        [TestCase(2018, 07, 10, 06, 05, 00)]
        [TestCase(2018, 07, 10, 06, 29, 59)]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom600To629AM_Returns9(int year, int month, int day, int hour, int minute, int second)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { new DateTime(year, month, day, hour, minute, second) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(9);
        }

        [Test]
        [TestCase(2018, 07, 10, 06, 30, 00)]
        [TestCase(2018, 07, 10, 06, 44, 00)]
        [TestCase(2018, 07, 10, 06, 59, 59)]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom630To659AM_Returns16(int year, int month, int day, int hour, int minute, int second)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { new DateTime(year, month, day, hour, minute, second) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(16);
        }

        [Test]
        [TestCase(2018, 07, 10, 07, 00, 00)]
        [TestCase(2018, 07, 10, 07, 54, 00)]
        [TestCase(2018, 07, 10, 07, 59, 59)]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom700To759AM_Returns22(int year, int month, int day, int hour, int minute, int second)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { new DateTime(year, month, day, hour, minute, second) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(22);
        }

        [Test]
        [TestCase(2018, 07, 10, 08, 00, 00)]
        [TestCase(2018, 07, 10, 08, 25, 00)]
        [TestCase(2018, 07, 10, 08, 29, 59)]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom800To829AM_Returns16(int year, int month, int day, int hour, int minute, int second)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { new DateTime(year, month, day, hour, minute, second) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(16);
        }

        [Test]
        [TestCase(2018, 07, 10, 08, 30, 00)]
        [TestCase(2018, 07, 10, 12, 00, 00)]
        [TestCase(2018, 07, 10, 14, 59, 59)]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom830To1459AM_Returns9(int year, int month, int day, int hour, int minute, int second)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { new DateTime(year, month, day, hour, minute, second) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(9);
        }

        [Test]
        [TestCase(2018, 07, 10, 15, 00, 00)]
        [TestCase(2018, 07, 10, 15, 10, 00)]
        [TestCase(2018, 07, 10, 15, 29, 59)]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom1500To1529_Returns16(int year, int month, int day, int hour, int minute, int second)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { new DateTime(year, month, day, hour, minute, second) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(16);
        }

        [Test]
        [TestCase(2018, 07, 10, 15, 30, 00)]
        [TestCase(2018, 07, 10, 15, 59, 00)]
        [TestCase(2018, 07, 10, 16, 59, 59)]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom1530To1659_Returns22(int year, int month, int day, int hour, int minute, int second)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { new DateTime(year, month, day, hour, minute, second) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(22);
        }

        [Test]
        [TestCase(2018, 07, 10, 17, 00, 00)]
        [TestCase(2018, 07, 10, 17, 09, 00)]
        [TestCase(2018, 07, 10, 17, 59, 59)]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom1700To1759_Returns16(int year, int month, int day, int hour, int minute, int second)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { new DateTime(year, month, day, hour, minute, second) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(16);
        }

        [Test]
        [TestCase(2018, 07, 10, 18, 00, 00)]
        [TestCase(2018, 07, 10, 18, 13, 00)]
        [TestCase(2018, 07, 10, 18, 29, 59)]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom1800To1829_Returns9(int year, int month, int day, int hour, int minute, int second)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { new DateTime(year, month, day, hour, minute, second) };
            int tollFee = calc.GetTollFee(new Vehicle(VehicleType.Private), oncePassingDateTime);

            // Assert
            tollFee.Should().Be(9);
        }

        [Test]
        [TestCase(2018, 07, 10, 18, 30, 00)]
        [TestCase(2018, 07, 10, 00, 00, 00)]
        [TestCase(2018, 07, 10, 05, 59, 59)]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom1830To0559_Returns0(int year, int month, int day, int hour, int minute, int second)
        {
            // Arrange
            TollCalculator calc = CreateSwedenTollCalculator();

            // Act
            DateTime[] oncePassingDateTime = { new DateTime(year, month, day, hour, minute, second) };
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
                new DateTime(2018,07,10,06,30,00), 
                new DateTime(2018,07,10,07,31,00), 
                new DateTime(2018,07,10,08,32,00), 
                new DateTime(2018,07,10,09,33,00), 
                new DateTime(2018,07,10,10,34,00), 
                new DateTime(2018,07,10,11,35,00), 
                new DateTime(2018,07,10,12,36,00)
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
                new DateTime(2018,07,10,09,00,00),
                new DateTime(2018,07,10,09,54,00),
                new DateTime(2018,07,10,10,01,00),
                new DateTime(2018,07,10,10,06,00),
                new DateTime(2018,07,10,11,06,00)
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
                new DateTime(2018,07,10,18,00,00),
                new DateTime(2018,08,10,17,54,00)
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
                new DateTime(2018,07,10,18,00,00),
                new DateTime(2018,08,10,17,54,00)
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
            DateTime[] emptyDateTime = { };
            Action getTollFee = () => calc.GetTollFee(new Vehicle(VehicleType.Private), emptyDateTime);

            // Assert
            getTollFee.Should().Throw<ArgumentException>()
                .WithMessage("No datetimes detected for vehicle");
        }

        [Test]
        public void GetTollFee_WhenDatesIsEmpty_Throws()
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
            return new TollCalculator(new SwedenHourlyFee(new SwedenTollFreeDaysProvider(), new SwedenTollFreeVehicleProvider()));
        }
    }
}