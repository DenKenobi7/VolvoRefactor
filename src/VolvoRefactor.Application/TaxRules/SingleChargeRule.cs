using System;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public class SingleChargeRule : BaseTaxRule
    {
        private TaxInterval _taxInterval;
        public SingleChargeRule(TaxInterval taxInterval)
        {
            _taxInterval = taxInterval;
        }
        public override void GetTax(DateTime date, ref int totalFee)
        {
            var minutes = (date - _taxInterval.StartTime).TotalMinutes;

            int totalSumBeforeCharging = totalFee;
            NextRule.GetTax(date, ref totalFee);
            int fee = totalFee - totalSumBeforeCharging;

            if (minutes >= 60)
            {
                totalFee += _taxInterval.MaxFee;
                _taxInterval.MaxFee = 0;
                _taxInterval.StartTime = date;
            }

            _taxInterval.MaxFee = Math.Max(fee, _taxInterval.MaxFee);

            if (_taxInterval.EndTime == date)
            {
                totalFee += _taxInterval.MaxFee;
            }

            return;
        }
    }
}
