using System;
using VolvoRefactor.Application.TaxCalculators;
using Xunit;

namespace VolvoRefactor.UnitTests.Calculators
{
    public class GothenburgTaxCalculatorTests
    {
        private readonly GothenburgCongestionTaxCalculator _calculator;



        [Theory]
        [InlineData()]
        public void GetTax_TollFreeVehicle_ReturnsZero()
        {
            
        }
    }
}
