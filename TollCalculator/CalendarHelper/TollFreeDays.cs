using System;

namespace TollCalculator.CalendarHelper
{
    public abstract class TollFreeDays
    {
        public abstract bool IsTollFree(DateTime date);
    }
}