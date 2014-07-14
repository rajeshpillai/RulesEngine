using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Rules
{
    public class MaxLenFieldAttribute : ValidationAttribute
    {
        public int Max { get; set; }

        public MaxLenFieldAttribute() : base()
        {

        }
        public MaxLenFieldAttribute(string name, string message, int max)
            : base(name, message)
        {
            this.Max = max;
        }

        public override BrokenRule Validate(object value)
        {
            BrokenRule rule = new BrokenRule();
            rule.IsValid = true;

            if (null != value || !string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (value.ToString().Length >= Max)
                {
                    rule.IsValid = false;
                    rule.Name = this.Name;
                    rule.ErrorMessage = this.Message;
                }
            }

            return rule;
        }
    }
}
