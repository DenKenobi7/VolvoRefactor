using System;
using System.Collections.Generic;
using System.Linq;
using VolvoRefactor.Application.Helpers;
using VolvoRefactor.Application.Models;
using VolvoRefactor.Application.TaxRules;

namespace VolvoRefactor.Application.TaxCalculators
{
    public abstract class CongestionTaxCalculator : ICongestionTaxCalculator
    {
        public string Name { get; set; }
        public CongestionConfiguration CongestionConfiguration { get; init; }
        public ITaxRule TaxRuleChain { get; set; }
        public virtual int GetTax(Vehicle vehicle, DateTime[] dates)
        {
            var totalFee = 0;

            var interval = new TaxInterval(dates.First(), dates.Last(), 0);

            foreach (var date in dates)
            {
                TaxRuleChain.GetTax(date, vehicle, interval, ref totalFee);
            }
            return totalFee;
        }

        protected virtual void SetTaxRuleChain()
        {
            var taxRules = new List<ITaxRule>()
            {
                new TollFreeVehicleRule(CongestionConfiguration.TollFreeVehicles),
                new HolidayRule(CongestionConfiguration.HolidaysSet),
                new MaxDailyFeeRule(CongestionConfiguration.MaxDailyFee),
                new SingleChargeRule(CongestionConfiguration.SingleChargeTime),
                new HourTaxRule(CongestionConfiguration.CongestionIntervalCosts)
            };
            TaxRuleChain = taxRules.ChainRules();
        }
    }
}
