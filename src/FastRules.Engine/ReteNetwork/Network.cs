using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.ReteNetwork
{
    public class Network : INetwork
    {
        public IEnumerable<RuleAction> Run(ISession session, Fact fact)
        {
            return new List<RuleAction>();
        }
    }
}
