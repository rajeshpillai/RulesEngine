using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Rules
{
    public class RequiredFieldAttribute : ValidationAttribute
    {
        public RequiredFieldAttribute() : base()
        {

        }
        public RequiredFieldAttribute(string name, string message) : base(name, message)
        {
        }

        public override BrokenRule Validate(object value)
        {
            BrokenRule rule = new BrokenRule();

            if (null == value || string.IsNullOrWhiteSpace(value.ToString()))
            {
                rule.IsValid = false;
                rule.ErrorMessage = this.Message;
                rule.Name = this.Name;
            }

            return rule;
        }
    }
}
