using System;
using System.Collections.Generic;
using System.Linq;
using TollCalculator.HourlyFeeHelper;
using TollCalculator.Vehicles;

namespace TollCalculator
{
    public class TollCalculator
    {
        /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

        private readonly IHourlyFee _hourlyFeeProvider;

        const int maxTollFee = 60;

        public TollCalculator(IHourlyFee hourlyFeeProvider)
        {
            _hourlyFeeProvider = hourlyFeeProvider ?? throw new ArgumentNullException(nameof(hourlyFeeProvider));
        }


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
    }
}