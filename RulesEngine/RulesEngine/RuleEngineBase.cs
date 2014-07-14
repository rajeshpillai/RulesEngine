using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RulesEngine.Rules;

namespace RulesEngine
{
    public abstract class RuleEngineBase<T>
    {
        public Dictionary<string, List<ValidationAttribute>> Rules { get; set; }

        public RuleEngineBase()
        {
            Rules = new Dictionary<string, List<ValidationAttribute>>();
            BuildRuleset();
        }

        public void BuildRuleset()
        {
            var value = typeof(T);

            var props = value.GetProperties();

            foreach (var prop in props)
            {
                var rulesAttrs = prop.GetCustomAttributes(typeof(ValidationAttribute), true);

                var ruleItems = new List<ValidationAttribute>();

                foreach (var rule in rulesAttrs)
                {
                    var ruleAttribute = rule as ValidationAttribute;
                    ruleItems.Add(ruleAttribute);
                }
                Rules[prop.Name] = ruleItems;
            }
        }

    }
}
