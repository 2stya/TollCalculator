using System;

namespace TollCalculator.HourlyFee.TollFree
{
    public class SwedenTollFreeDaysProvider : ITollFreeDays
    {
        public bool IsTollFree(DateTime date)
        {
            return IsWeekend(date) || IsPublicHoliday(date);
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        private bool IsPublicHoliday(DateTime date)
        {
            return date.Month == 1 && date.Day == 1 ||   // Nyårsdagen
                   date.Month == 1 && date.Day == 6 ||   // Trettondedag jul
                   date.Month == 5 && date.Day == 1 ||   // Första Maj
                   date.Month == 6 && date.Day == 6 ||   // Sveriges nationaldag	
                   date.Month == 12 && date.Day == 24 || // Julafton
                   date.Month == 12 && date.Day == 25 || // Juldagen
                   date.Month == 12 && date.Day == 26 || // Annandag jul	
                   IsEasterHolidays(date);
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