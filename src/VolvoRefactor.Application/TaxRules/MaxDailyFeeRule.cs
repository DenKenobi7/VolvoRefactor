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

        public override void GetTax(DateTime date, Vehicle vehicle, TaxInterval interval, ref int totalFee)
        {
            NextRule.GetTax(date, vehicle, interval, ref totalFee);
            if (totalFee > _maxDailyFee)
            {
                totalFee = _maxDailyFee;
            }
        }
    }
}
