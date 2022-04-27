using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxCalculators
{
    public class CustomCongestionTaxCalculator : CongestionTaxCalculator
    {
        public CustomCongestionTaxCalculator(CongestionConfiguration config)
        {
            Name = "Custom";
            CongestionConfiguration = config;
            SetTaxRuleChain();
        }
    }
}
