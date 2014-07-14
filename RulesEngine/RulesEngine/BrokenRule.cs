using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine
{
    public class BrokenRule
    {
        public string Name { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsBroken { get; set; }

        public BrokenRule()
        {
            IsBroken = false;
        }
    }
}
