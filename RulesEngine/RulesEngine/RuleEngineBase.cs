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
        public abstract void BuildRuleSet();

        public RuleEngineBase()
        {
            Rules = new Dictionary<string, List<ValidationAttribute>>();
            BuildRuleSet();
        }
    }
}
