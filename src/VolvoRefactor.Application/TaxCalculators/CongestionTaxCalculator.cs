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
            var totalTax = 0;
            foreach (var dayChecpoints in SplitIntoDays(dates))
            {
                var dayFee = 0;

                var interval = new TaxInterval(dayChecpoints.First(), dayChecpoints.Last(), 0);

                foreach (var checkpoint in dayChecpoints)
                {
                    dayFee += TaxRuleChain.GetTax(checkpoint, vehicle, interval, dayFee);
                }
                totalTax += dayFee;
            }
            
            return totalTax;
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
        protected IEnumerable<List<DateTime>> SplitIntoDays(DateTime[] dates)
        {
            return dates.OrderBy(x => x)
                        .GroupBy(x => x.Date)
                        .Select(g => g.ToList());
        }
    }
}
