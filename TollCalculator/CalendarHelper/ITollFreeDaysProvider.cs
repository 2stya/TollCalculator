using System;

namespace TollCalculator.CalendarHelper
{
    public abstract class ITollFreeDaysProvider
    {
        protected DateTime _dateTime;

        protected ITollFreeDaysProvider(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public abstract bool IsTollFree();
    }
}