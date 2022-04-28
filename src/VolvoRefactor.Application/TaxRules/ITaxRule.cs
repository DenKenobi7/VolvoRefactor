using System;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public interface ITaxRule
    {
        int GetTax(DateTime date, Vehicle vehicle, TaxInterval interval, int totalFee);
        void SetNext(ITaxRule taxRule);
    }
}
