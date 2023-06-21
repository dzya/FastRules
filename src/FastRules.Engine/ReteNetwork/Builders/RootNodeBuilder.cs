using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.ReteNetwork.Builders
{
    public class RootNodeBuilder : BaseNodeBuilder
    {
        public override IReteNode Build(IEnumerable<IRule<object>> rules)
        {
            var result = new RootNode();

            return result;
        }
    }
}
