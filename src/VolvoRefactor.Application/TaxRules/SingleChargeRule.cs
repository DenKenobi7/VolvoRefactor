using System;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public class SingleChargeRule : BaseTaxRule
    {
        public override void GetTax(DateTime date, Vehicle vehicle, TaxInterval interval, ref int totalFee)
        {
            var minutes = (date - interval.StartTime).TotalMinutes;

            int totalSumBeforeCharging = totalFee;
            NextRule.GetTax(date, vehicle, interval, ref totalFee);
            int fee = totalFee - totalSumBeforeCharging;

            if (minutes >= 60)
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

            return;
        }
    }
}
