using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RulesEngine.Rules;

namespace RulesEngine
{
    public static class RuleEngineFactory<T> where T: class
    {
        public static IRuleEngine<T> GetEngine()
        {
            var t = typeof(T);
            var ruleEngineTypeAttr = t.GetCustomAttributes(typeof(RuleEngineTypeAttribute), true);

            if (ruleEngineTypeAttr != null)
            {
                var ruleType = Activator.CreateInstance((ruleEngineTypeAttr[0] as RuleEngineTypeAttribute).RuleType);
                return ruleType as IRuleEngine<T>;
            }

            return new DefaultRuleEngine<T>();
        }
    }
}
