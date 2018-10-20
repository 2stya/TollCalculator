using System;

namespace TollCalculator.CalendarHelper
{
    public class SwedenTollFreeDaysProvider : TollFreeDaysProvider
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
            return DateTime.DayOfWeek == DayOfWeek.Saturday || DateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        private bool IsPublicHoliday()
        {
            if (DateTime.Month == 1 && DateTime.Day == 1 ||   // Nyårsdagen
                DateTime.Month == 1 && DateTime.Day == 6 ||   // Trettondedag jul
                DateTime.Month == 5 && DateTime.Day == 1 ||   // Första Maj
                DateTime.Month == 6 && DateTime.Day == 6 ||   // Sveriges nationaldag	
                DateTime.Month == 12 && DateTime.Day == 24 || // Julafton
                DateTime.Month == 12 && DateTime.Day == 25 || // Juldagen
                DateTime.Month == 12 && DateTime.Day == 26 || // Annandag jul	
                IsEasterHolidays(DateTime)                    // Långfredagen, Annandag påsk, Kristi himmelsfärds dag	
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