using FastRules.Engine.ReteNetwork;
using FastRules.Engine.ReteNetwork.Builders;
using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Data;

namespace FastRules.Engine
{
    public class Engine
    {
        private readonly List<IRule> _rules;
        private readonly INetworkBuilder _networkBuilder;
        private INetwork network;

        private bool isBuilt;

        public IEnumerable<IRule> Rules => _rules;

        public Engine(INetworkBuilder networkBuilder)
        {
            _rules = new List<IRule>();
            _networkBuilder = networkBuilder;
        }

        public void AddRule(IRule rule)
        {
            _rules.Add(rule);
            isBuilt = false;
        }

        public void Build()
        {
            network = _networkBuilder.Build();
            isBuilt = true;
        }

        public IEnumerable<RuleAction> Run(Fact fact)
        {
            if(!isBuilt)
            {
                throw new InvalidOperationException("Rules should be build before run.");
            }

            var session = new Session();
            return network.Run(session, fact);
        }
    }
}
