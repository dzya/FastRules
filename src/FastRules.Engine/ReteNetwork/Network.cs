using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace FastRules.Engine.ReteNetwork
{
    public class Network : INetwork
    {
        private readonly List<IRule<object>> _rules = new List<IRule<object>>();

        public void AddRule(IRule<object> rule)
        {
            _rules.Add(rule);
        }

        public IEnumerable<RuleAction> Run(ISession session, Object fact)
        {
            var result = new List<RuleAction>();

            foreach (var rule in _rules)
            {
                var action = rule.Fire(fact);

                if (action != null)
                {
                    result.Add(action);
                }
            }

            return result;
        }
    }
}
