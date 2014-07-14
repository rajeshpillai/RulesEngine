using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Rules
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false)]
    public class RuleEngineTypeAttribute : Attribute
    {
        public Type RuleType { get; set; }

        public RuleEngineTypeAttribute() : base()
        {

        }
        public RuleEngineTypeAttribute(string ruleType)
        {
        }

    }
}
