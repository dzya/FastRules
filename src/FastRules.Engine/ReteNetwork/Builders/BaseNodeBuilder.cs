using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.ReteNetwork.Builders
{
    public abstract class BaseNodeBuilder : INodesBuilder
    {
        public abstract IReteNode Build(IEnumerable<IRule<object>> rules);
    }
}
