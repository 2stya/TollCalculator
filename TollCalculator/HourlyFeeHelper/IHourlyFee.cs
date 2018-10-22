using System;
using TollCalculator.Vehicles;

namespace TollCalculator.HourlyFeeHelper
{
    public interface IHourlyFee
    {
        int GetHourlyFee(DateTime dateTime, Vehicle vehicle);
    }
}