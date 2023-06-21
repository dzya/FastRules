using FastRules.Engine.ReteNetwork.Builders;
using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace FastRules.Engine.ReteNetwork
{
    public class Network : INetwork
    {
        private readonly List<IRule<object>> _rules;
        private readonly INodesBuilder _nodesBuilder;
        private bool isReady;
        private RootNode root;

        public Network(INodesBuilder nodesBuilder)
        {
            _rules = new List<IRule<object>>();
            _nodesBuilder = nodesBuilder;
        }

        public void AddRule(IRule<object> rule)
        {
            if(isReady)
            {
                throw new InvalidOperationException("Network already built.");
            }

            _rules.Add(rule);
        }

        public void Build()
        {
            root = (RootNode)_nodesBuilder.Build(_rules);

            isReady = true;
        }

        public IEnumerable<RuleAction> Run(ISession session, Object fact)
        {
            if(!isReady)
            {
                throw new InvalidOperationException("Network should be Build first.");
            }

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
