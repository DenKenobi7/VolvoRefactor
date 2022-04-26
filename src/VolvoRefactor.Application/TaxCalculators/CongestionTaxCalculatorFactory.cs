using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxCalculators
{
    public class CongestionTaxCalculatorFactory
    {
        private readonly IReadOnlyDictionary<string, ICongestionTaxCalculator> _congestionTaxCalculators;

        public CongestionTaxCalculatorFactory(CongestionConfiguration congestionConfiguration)
        {
            var congestionTaxCalculatorType = typeof(ICongestionTaxCalculator);
            _congestionTaxCalculators = congestionTaxCalculatorType.Assembly.ExportedTypes
                .Where(x => congestionTaxCalculatorType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x =>
                {
                    var parameterlessCtor = x.GetConstructors().SingleOrDefault(c => c.GetParameters().Length == 0);
                    return parameterlessCtor is not null ? Activator.CreateInstance(x) : Activator.CreateInstance(x, congestionConfiguration);
                })
                .Cast<ICongestionTaxCalculator>()
                .ToImmutableDictionary(x => x.Name, x => x);
        }

        public ICongestionTaxCalculator GetCalculatorByName(string calculatorName)
        {
            calculatorName = calculatorName ?? string.Empty;
            var calculator = _congestionTaxCalculators.GetValueOrDefault(calculatorName);
            return calculator ?? _congestionTaxCalculators["Custom"];
        }
    }
}
