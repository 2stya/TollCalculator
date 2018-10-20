using System;
using FluentAssertions;
using NUnit.Framework;
using TollCalculator.Extensions;

namespace TollCalculator.Tests.Extensions
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        [TestCase(2018, 10, 15)]
        [TestCase(2018, 10, 16)]
        [TestCase(2018, 10, 17)]
        [TestCase(2018, 10, 18)]
        [TestCase(2018, 10, 19)]
        public void IsWeekend_WhenWorkday_ReturnsFalse(int year, int month, int day)
        {
            // Arrange
            DateTime dateTime = new DateTime(year, month, day);

            // Act & Assert
            dateTime.IsWeekend().Should().BeFalse();
        }

        [Test]
        [TestCase(2018, 10, 20)]
        [TestCase(2018, 10, 21)]
        public void IsWeekend_WhenWeekend_ReturnsTrue(int year, int month, int day)
        {
            // Arrange
            DateTime dateTime = new DateTime(year, month, day);

            // Act & Assert
            dateTime.IsWeekend().Should().BeTrue();
        }
    }
}
