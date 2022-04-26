using System;

namespace VolvoRefactor.Application.TaxRules
{
    public interface ITaxRule
    {
        void GetTax(DateTime date, ref int totalFee);
        void SetNext(ITaxRule taxRule);
    }
}
