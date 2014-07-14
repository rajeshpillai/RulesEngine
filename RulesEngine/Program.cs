using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RulesEngine.Model;
using RulesEngine.Rules;

namespace RulesEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Registration register = new Registration();
            IRuleEngine<Registration> ruleEngine = new DefaultRuleEngine<Registration>();

            register.UserName = "rajeshrajeshrajeeshrajeshrajesh";
            register.Password = "test123";
            register.Email = "";

            var results = ruleEngine.Validate(register);

            foreach (var r in results)
            {
                if (r.IsBroken)
                {
                    Console.WriteLine("{0} rule is broken and the error is {1}", r.Name, r.ErrorMessage);
                }
            }

            Console.Read();
        }
    }
}
