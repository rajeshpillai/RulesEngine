using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Rules
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CompareFieldAttribute : ValidationAttribute
    {
        public CompareFieldAttribute() : base()
        {

        }
        public CompareFieldAttribute(string name, string message)
            : base(name, message)
        {
        }

        public override BrokenRule Validate(object value, ValidationContext context)
        {
            BrokenRule rule = new BrokenRule();

            var targetField = context.SourceObject.GetType().GetProperty(this.Name);

            if (value != targetField.GetValue(context.SourceObject))
            {
                rule.IsBroken = true;
                rule.ErrorMessage = this.Message;
                rule.Name = this.Name;
            }

            return rule;
        }
    }
}
