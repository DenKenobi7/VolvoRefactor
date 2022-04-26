using System;

namespace VolvoRefactor.Application.TaxRules
{
    public abstract class BaseTaxRule : ITaxRule
    {
        protected ITaxRule NextRule;
        public abstract void GetTax(DateTime date, ref int totalFee);
        public void SetNext(ITaxRule taxRule)
        {
            NextRule = taxRule;
        }
    }
}
