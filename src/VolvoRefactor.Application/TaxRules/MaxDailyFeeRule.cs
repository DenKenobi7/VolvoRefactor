using System;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public class MaxDailyFeeRule : BaseTaxRule
    {
        private int _maxDailyFee;
        public MaxDailyFeeRule(int maxDailyFee)
        {
            _maxDailyFee = maxDailyFee;
        }

        public override int GetTax(DateTime date, Vehicle vehicle, TaxInterval interval, int totalFee)
        {
            totalFee = NextRule.GetTax(date, vehicle, interval, totalFee);
            if (totalFee > _maxDailyFee)
            {
                totalFee = _maxDailyFee;
            }
            return totalFee;
        }
    }
}
