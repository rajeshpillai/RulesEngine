using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Rules
{
    public class DefaultRuleEngine<T> : IRuleEngine<T>
    {
        public List<BrokenRule> Validate(T value)
        {
            var results = new List<BrokenRule>();

            var props = value.GetType().GetProperties();

            foreach(var prop in props)
            {
                var rules = prop.GetCustomAttributes(typeof(ValidationAttribute), true);
                foreach (var rule in rules)
                {
                    var ruleAttribute = rule as ValidationAttribute;
                    var ruleResult = ruleAttribute.Validate(prop.GetValue(value));
                    if (!ruleResult.IsValid)
                    {
                        results.Add(ruleResult);
                    }
                }
            }
            return results;

        }
    }
}
