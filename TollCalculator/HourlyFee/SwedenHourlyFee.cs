using System;
using TollCalculator.HourlyFee.TollFree;
using TollCalculator.Vehicles;

namespace TollCalculator.HourlyFee
{
    public class SwedenHourlyFee : IHourlyFee 
        
        //TODO Use data structure to store TimeSpans and hourly price
    {
        private readonly TollFreeDays _freeDays;
        private readonly ITollFreeVehicleProvider _freeVehicleProvider;

        public SwedenHourlyFee(TollFreeDays freeDaysProvider, ITollFreeVehicleProvider freeVehicleProvider)
        {
            _freeDays = freeDaysProvider ?? throw new ArgumentNullException(nameof(freeDaysProvider));
            _freeVehicleProvider = freeVehicleProvider ?? throw new ArgumentNullException(nameof(freeVehicleProvider));
        }

        public int GetHourlyFee(DateTime dateTime, Vehicle vehicle)
        {
            if (_freeDays.IsTollFree(dateTime) || _freeVehicleProvider.IsTollFree(vehicle.VehicleType))
            {
                return 0;
            }

            switch (dateTime.Hour)
            {
                case 6 when dateTime.Minute <= 29:
                case 8 when dateTime.Minute >= 30:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 18 when dateTime.Minute <= 29:
                    return 9;

                case 6 when dateTime.Minute >= 30:
                case 8 when dateTime.Minute <= 29:
                case 15 when dateTime.Minute <= 29:
                case 17 when dateTime.Minute <= 59:
                    return 16;

                case 7:
                case 15 when dateTime.Minute >= 30:
                case 16 when dateTime.Minute <= 59:
                    return 22;

                default:
                    return 0;
            }
        }
    }
}