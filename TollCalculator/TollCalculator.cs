using System;
using System.Collections.Generic;
using System.Linq;
using TollCalculator.CalendarHelper;
using TollCalculator.Vehicles;

namespace TollCalculator
{
    public class TollCalculator
    {
        private readonly TollFreeDaysProvider _freeDaysProvider;
        private readonly IHourlyFee _hourlyFeeProvider;
        const int maxTollFee = 60;

        public TollCalculator(TollFreeDaysProvider freeDaysProvider, IHourlyFee hourlyFeeProvider)
        {
            _freeDaysProvider = freeDaysProvider ?? throw new ArgumentNullException(nameof(freeDaysProvider));
            _hourlyFeeProvider = hourlyFeeProvider ?? throw new ArgumentNullException(nameof(hourlyFeeProvider));
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
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            if (dates == null || dates.Length == 0)
            {
                throw new ArgumentException("No datetimes detected for vehicle");
            }

            SortDateTimeAscending(dates);

            if (!IsSameDate(dates))
            {
                throw new ArgumentException("Only one date should be presented to calculate toll fee.");
            }

            //RemoveLessThanHourDatetimes();

            DateTime tempInterval = dates[0];
            int totalFee = GetTollFee(tempInterval, vehicle);
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);

                long minutes = (date.Hour - tempInterval.Hour) * 60 + date.Minute - tempInterval.Minute;

                if (minutes <= 60)
                {
                    continue;
                }
                else
                {
                    totalFee += nextFee;
                    tempInterval = date;
                }

                if (totalFee >= maxTollFee)
                {
                    return maxTollFee;
                }
            }
            
            return totalFee;
        }

        private IEnumerable<DateTime> SortDateTimeAscending(IEnumerable<DateTime> dates)
        {
            return dates.OrderBy(date => date);
        }

        private bool IsSameDate(IReadOnlyList<DateTime> dates)
        {
            DateTime firstDate = dates[0];
            return dates.All(date => date.Year == firstDate.Year &&
                                     date.Month == firstDate.Month &&
                                     date.Day == firstDate.Day);
        }

        private int GetTollFee(DateTime date, Vehicle vehicle)
        {
            if (_freeDaysProvider.IsTollFree(date) || vehicle.IsTollFree)
            {
                return 0;
            }

            return _hourlyFeeProvider.GetHourlyFee(date);
        }

        //TODO: Use TimeSpans to store time intervals
        //private static int GetHourlyFee(int hour, int minute)
        //{
        //    switch (hour)
        //    {
        //        case 6 when minute <= 29:
        //        case 8 when minute >= 30:
        //        case 9:
        //        case 10:
        //        case 11:
        //        case 12:
        //        case 13:
        //        case 14:
        //        case 18 when minute <= 29:
        //            return 9;

        //        case 6 when minute >= 30:
        //        case 8 when minute <= 29:
        //        case 15 when minute <= 29:
        //        case 17 when minute <= 59:
        //            return 16;

        //        case 7:
        //        case 15 when minute >= 30:
        //        case 16 when minute <= 59:
        //            return 22;

        //        default:
        //            return 0;
        //    }
        //}
    }
}