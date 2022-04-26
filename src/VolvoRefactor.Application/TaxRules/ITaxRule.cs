using System;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public interface ITaxRule
    {
        void GetTax(DateTime date, Vehicle vehicle, TaxInterval interval, ref int totalFee);
        void SetNext(ITaxRule taxRule);
    }
}
