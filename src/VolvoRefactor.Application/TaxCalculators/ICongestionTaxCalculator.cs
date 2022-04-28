using System;
using System.Collections.Generic;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxCalculators
{
    public interface ICongestionTaxCalculator
    {
        string Name { get; set; }
        CongestionConfiguration CongestionConfiguration { get; init; }
        int GetTax(Vehicle vehicle, DateTime[] dates);
    }
}
