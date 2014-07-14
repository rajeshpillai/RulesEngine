using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Rules
{
    public abstract class ValidationAttribute: Attribute
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public ValidationAttribute()
        {

        }

        public ValidationAttribute(string name, string message)
        {
            this.Name = name;
            this.Message = message;
        }

        public abstract BrokenRule Validate(object value, ValidationContext context);
    }
}
