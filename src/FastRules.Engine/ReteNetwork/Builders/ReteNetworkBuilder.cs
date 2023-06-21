using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.ReteNetwork.Builders
{
    public class ReteNetworkBuilder : BaseNetworkBuilder
    {
        private readonly INodesBuilder _nodesBuilder;

        public ReteNetworkBuilder(INodesBuilder nodesBuilder) {
            _nodesBuilder = nodesBuilder;
        }

        public override INetwork Build(IEnumerable<IRule<object>> rules)
        {
            var network = new Network(_nodesBuilder);

            foreach (var rule in rules)
            {
                network.AddRule(rule);
            }
            network.Build();

            return network;
        }
    }
}
