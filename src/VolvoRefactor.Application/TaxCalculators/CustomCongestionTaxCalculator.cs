using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxCalculators
{
    public class CustomCongestionTaxCalculator : CongestionTaxCalculator
    {
        public CustomCongestionTaxCalculator(CongestionConfiguration config)
        {
            Name = "Custom";
            CongestionParameters = config;
        }
    }
}
