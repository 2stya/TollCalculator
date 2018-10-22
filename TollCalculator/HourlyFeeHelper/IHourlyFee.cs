using System;

namespace TollCalculator.HourlyFeeHelper
{
    public interface IHourlyFee
    {
        int GetHourlyFee(DateTime dateTime);
    }
}