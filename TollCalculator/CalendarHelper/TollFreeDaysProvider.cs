using System;

namespace TollCalculator.CalendarHelper
{
    public abstract class TollFreeDaysProvider
    {
        public abstract bool IsTollFree(DateTime date);
    }
}