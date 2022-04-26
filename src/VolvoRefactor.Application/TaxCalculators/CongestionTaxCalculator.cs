using System;
using System.Collections.Generic;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxCalculators
{
    public abstract class CongestionTaxCalculator : ICongestionTaxCalculator
    {
        public string City { get; init; }
        public CongestionParameters CongestionParameters { get; init; }

        public int GetTax(Vehicle vehicle, List<DateTime> dates)
        {
            throw new NotImplementedException();
        }
    }
}
