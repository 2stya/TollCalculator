using System;

namespace TollCalculator.HourlyFee.TollFree
{
    public abstract class TollFreeDays
    {
        public abstract bool IsTollFree(DateTime date);
    }
}