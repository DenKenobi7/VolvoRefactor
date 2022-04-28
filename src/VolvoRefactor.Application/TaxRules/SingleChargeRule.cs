using System;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public class SingleChargeRule : BaseTaxRule
    {
        private int _singleChargeTime;
        public SingleChargeRule(int singleChargeTime)
        {
            _singleChargeTime = singleChargeTime;
        }
        public override int GetTax(DateTime date, Vehicle vehicle, TaxInterval interval, int totalFee)
        {
            var minutes = (date - interval.StartTime).TotalMinutes;

            var fee = NextRule.GetTax(date, vehicle, interval, totalFee);

            if (minutes >= _singleChargeTime)
            {
                totalFee += interval.MaxFee;
                interval.MaxFee = 0;
                interval.StartTime = date;
            }

            interval.MaxFee = Math.Max(fee, interval.MaxFee);

            if (interval.EndTime == date)
            {
                totalFee += interval.MaxFee;
            }

            return totalFee;
        }
    }
}
