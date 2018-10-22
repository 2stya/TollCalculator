using System;

namespace TollCalculator.HourlyFee.TollFree
{
    public interface ITollFreeDays
    {
        bool IsTollFree(DateTime date);
    }
}