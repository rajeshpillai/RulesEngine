using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine.Rules
{
    public class BrokenRule
    {
        public string Name { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsValid { get; set; }

        public BrokenRule()
        {
            IsValid = true;
        }
    }
}
