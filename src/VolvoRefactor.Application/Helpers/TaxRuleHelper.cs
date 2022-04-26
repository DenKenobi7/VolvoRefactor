using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvoRefactor.Application.TaxRules;

namespace VolvoRefactor.Application.Helpers
{
    public static class TaxRuleHelper
    {
        public static ITaxRule ChainRules(this IList<ITaxRule> rules)
        {
            ITaxRule first  = rules.FirstOrDefault();
            ITaxRule currentRule = first;

            foreach (var rule in rules.Skip(1))
            {
                currentRule.SetNext(rule);
                currentRule = rule;
            }
            return first;
        }
    }
}
