using System;
using FluentAssertions;
using NUnit.Framework;
using TollCalculator.CalendarHelper;

namespace TollCalculator.Tests.CalendarHelper
{
    [TestFixture]
    public class SwedenTollFreeDaysProviderTests
    {
        [Test]
        public void IsTollFree_WhenNewYear_ReturnsTrue()
        {
            // Arrange
            DateTime newYear = new DateTime(2010, 1, 1);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(newYear).Should().BeTrue();
        }

        [Test]
        public void IsTollFree_WhenEpiphany_ReturnsTrue()
        {
            // Arrange
            DateTime epiphany = new DateTime(2012, 1, 6);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(epiphany).Should().BeTrue();
        }

        [Test]
        [TestCase(2019, 04, 19)]
        [TestCase(2018, 03, 30)]
        public void IsTollFree_WhenGoodFriday_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime goodFriday = new DateTime(year, month, day);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(goodFriday).Should().BeTrue();
        }

        [Test]
        [TestCase(2010, 04, 05)]
        [TestCase(2018, 04, 02)]
        public void IsTollFree_WhenEasternMonday_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime easterMonday = new DateTime(year, month, day);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(easterMonday).Should().BeTrue();
        }

        [Test]
        [TestCase(2020, 05, 21)]
        [TestCase(2011, 06, 02)]
        public void IsTollFree_WhenAscensionDay_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime ascensionDay = new DateTime(year, month, day);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(ascensionDay).Should().BeTrue();
        }

        [Test]
        [TestCase(2020, 05, 01)]
        [TestCase(2012, 05, 01)]
        public void IsTollFree_WhenInternationalWorkersDay_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime internationalWorkersDay = new DateTime(year, month, day);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(internationalWorkersDay).Should().BeTrue();
        }

        [Test]
        [TestCase(2023, 06, 06)]
        [TestCase(2024, 06, 06)]
        public void IsTollFree_WhenNationalDayOfSweden_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime nationalDayOfSweden = new DateTime(year, month, day);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(nationalDayOfSweden).Should().BeTrue();
        }

        [Test]
        [TestCase(2018, 12, 24)]
        [TestCase(2019, 12, 24)]
        public void IsTollFree_WhenChristmasEve_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime christmasEve = new DateTime(year, month, day);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(christmasEve).Should().BeTrue();
        }

        [Test]
        [TestCase(2018, 12, 25)]
        [TestCase(2019, 12, 25)]
        public void IsTollFree_WhenChristmasDay_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime christmasDay = new DateTime(year, month, day);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(christmasDay).Should().BeTrue();
        }

        [Test]
        [TestCase(2018, 12, 26)]
        [TestCase(2019, 12, 26)]
        public void IsTollFree_WhenSecondDayOfChristmas_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime secondDayOfChristmas = new DateTime(year, month, day);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(secondDayOfChristmas).Should().BeTrue();
        }

        [Test]
        [TestCase(2018, 5, 26)]
        [TestCase(2019, 9, 15)]
        public void IsTollFree_WhenSaturday_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime secondDayOfChristmas = new DateTime(year, month, day);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(secondDayOfChristmas).Should().BeTrue();
        }

        [Test]
        [TestCase(2025, 7, 13)]
        [TestCase(2026, 1, 4)]
        public void IsTollFree_WhenSunday_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime secondDayOfChristmas = new DateTime(year, month, day);
            SwedenTollFreeDays tollFreeDays = new SwedenTollFreeDays();

            // Act & Assert
            tollFreeDays.IsTollFree(secondDayOfChristmas).Should().BeTrue();
        }
    }
}