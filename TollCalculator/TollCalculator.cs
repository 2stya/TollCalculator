using System;
using TollCalculator.CalendarHelper;
using TollCalculator.Vehicles;

namespace TollCalculator
{
    public class TollCalculator
    {
        private readonly TollFreeDaysProvider _freeDaysProvider;

        public TollCalculator(TollFreeDaysProvider freeDaysProvider)
        {
            _freeDaysProvider = freeDaysProvider ?? new SwedenTollFreeDaysProvider();
        }
        /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

        public int GetTollFee(Vehicle vehicle, DateTime[] dates)
        {
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);
                int tempFee = GetTollFee(intervalStart, vehicle);

                long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                long minutes = diffInMillies / 1000 / 60;

                if (minutes <= 60)
                {
                    if (totalFee > 0)
                    {
                        totalFee -= tempFee;
                    }

                    if (nextFee >= tempFee)
                    {
                        tempFee = nextFee;
                    }

                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }
            if (totalFee > 60)
            {
                totalFee = 60;
            }

            return totalFee;
        }

        private int GetTollFee(DateTime date, Vehicle vehicle)
        {
            if (_freeDaysProvider.IsTollFree(date) || vehicle.IsTollFree)
            {
                return 0;
            }

            return GetHourlyTollFee(date.Hour, date.Minute);
        }

        private static int GetHourlyTollFee(int hour, int minute)
        {
            switch (hour)
            {
                case 6 when minute <= 29:
                case 8 when minute >= 30:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 18 when minute <= 29:
                    return 9;

                case 6 when minute >= 30:
                case 8 when minute <= 29:
                case 15 when minute <= 29:
                case 17 when minute <= 59:
                    return 16;

                case 7:
                case 15 when minute >= 30:
                case 16 when minute <= 59:
                    return 22;

                default:
                    return 0;
            }
        }

        private bool IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 21) ||
                    month == 7 ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }
            return false;
        }
    }
}