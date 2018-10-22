using System;
using TollCalculator.Vehicles;

namespace TollCalculator.HourlyFee
{
    public interface IHourlyFee
    {
        int GetHourlyFee(DateTime dateTime, Vehicle vehicle);
    }
}