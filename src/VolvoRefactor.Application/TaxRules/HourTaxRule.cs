using System;
using System.Collections.Generic;
using System.Linq;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public class HourTaxRule : BaseTaxRule
    {
        private readonly IList<CongestionIntervalCost> _congestionIntervalCosts;

        public HourTaxRule(IList<CongestionIntervalCost> congestionIntervalCosts)
        {
            _congestionIntervalCosts = congestionIntervalCosts;
        }
        public override void GetTax(DateTime date, Vehicle vehicle, TaxInterval interval, ref int totalFee)
        {
            var taxAmount = _congestionIntervalCosts
                .FirstOrDefault(x => x.StartTime.TimeOfDay <= date.TimeOfDay && date.TimeOfDay <= x.EndTime.TimeOfDay);

            totalFee += taxAmount?.Fee ?? 0;

            return;
        }
    }
}
