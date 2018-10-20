using System;
using TollCalculator.Extensions;

namespace TollCalculator.CalendarHelper
{
    public class SwedenTollFreeDaysProvider : ITollFreeDaysProvider
    {
        public SwedenTollFreeDaysProvider(DateTime dateTime) : base(dateTime)
        {
        }

        public override bool IsTollFree()
        {
            return IsWeekend() || IsPublicHoliday();
        }

        private bool IsWeekend()
        {
            return _dateTime.DayOfWeek == DayOfWeek.Saturday || _dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        private bool IsPublicHoliday()
        {
            if (_dateTime.Month == 1 && _dateTime.Day == 1 ||   // Nyårsdagen
                _dateTime.Month == 1 && _dateTime.Day == 6 ||   // Trettondedag jul
                _dateTime.Month == 5 && _dateTime.Day == 1 ||   // Första Maj
                _dateTime.Month == 6 && _dateTime.Day == 6 ||   // Sveriges nationaldag	
                _dateTime.Month == 12 && _dateTime.Day == 24 || // Julafton
                _dateTime.Month == 12 && _dateTime.Day == 25 || // Juldagen
                _dateTime.Month == 12 && _dateTime.Day == 26 || // Annandag jul	
                IsEasterHolidays(_dateTime)                     // Långfredagen, Annandag påsk, Kristi himmelsfärds dag	
            )
            {
                return true;
            }

            return false;
        }

        private bool IsEasterHolidays(DateTime dateTime)
        {
            DateTime easter = GetEasterDate(dateTime.Year);
            DateTime goodFriday = easter.AddDays(-2);
            DateTime easterMonday = easter.AddDays(1);
            DateTime ascensionDay = easter.AddDays(39);
            return dateTime.Month == goodFriday.Month && dateTime.Day == goodFriday.Day ||
                    dateTime.Month == easterMonday.Month && dateTime.Day == easterMonday.Day ||
                    dateTime.Month == ascensionDay.Month && dateTime.Day == ascensionDay.Day;
        }

        private static DateTime GetEasterDate(int year)
        {
            int g = year % 19;
            int c = year / 100;
            int h = h = (c - c / 4 - (8 * c + 13) / 25
                         + 19 * g + 15) % 30;
            int i = h - h / 28 * (1 - h / 28 *
                                           (29 / (h + 1)) * ((21 - g) / 11));

            int easterDay = i - ((year + year / 4 +
                                  i + 2 - c + c / 4) % 7) + 28;
            int easterMonth = 3;

            if (easterDay > 31)
            {
                easterMonth++;
                easterDay -= 31;
            }

            return new DateTime(year, easterMonth, easterDay);
        }
    }
}