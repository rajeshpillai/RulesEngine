using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RulesEngine.Rules;

namespace RulesEngine.Model
{
    [RuleEngineType(RuleType = typeof(XmlRuleEngine<Registration>))]
    public class Task
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DueWhen { get; set; }
        public bool IsComplete { get; set; }
    }
}
