using System;

namespace TollCalculator
{
    public interface IHourlyFee
    {
        int GetHourlyFee(DateTime dateTime);
    }
}