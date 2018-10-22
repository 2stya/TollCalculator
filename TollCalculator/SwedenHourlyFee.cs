using System;

namespace TollCalculator
{
    public class SwedenHourlyFee : IHourlyFee
    {
        public int GetHourlyFee(DateTime dateTime)
        {
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