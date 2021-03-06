using System;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public abstract class BaseTaxRule : ITaxRule
    {
        protected ITaxRule NextRule;
        public abstract int GetTax(DateTime date, Vehicle vehicle, TaxInterval interval, int totalFee);
        public void SetNext(ITaxRule taxRule)
        {
            NextRule = taxRule;
        }
    }
}
