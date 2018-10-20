using System;

namespace TollCalculator.CalendarHelper
{
    public abstract class TollFreeDaysProvider
    {
        protected DateTime DateTime;

        protected TollFreeDaysProvider(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public abstract bool IsTollFree();
    }
}