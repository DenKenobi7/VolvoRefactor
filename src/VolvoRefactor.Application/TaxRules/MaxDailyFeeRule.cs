using System;

namespace VolvoRefactor.Application.TaxRules
{
    public class MaxDailyFeeRule : BaseTaxRule
    {
        private int _maxDailyFee;
        public MaxDailyFeeRule(int maxDailyFee)
        {
            _maxDailyFee = maxDailyFee;
        }

        public override void GetTax(DateTime date, ref int totalFee)
        {
            NextRule.GetTax(date, ref totalFee);
            if (totalFee > _maxDailyFee)
            {
                totalFee = _maxDailyFee;
            }
        }
    }
}
