using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RulesEngine.Rules;

namespace RulesEngine
{
    public interface IRuleEngine<T>
    {
        List<BrokenRule> Validate(T value);
    }
}
