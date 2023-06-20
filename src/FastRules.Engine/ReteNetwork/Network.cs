using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.ReteNetwork
{
    public class Network : INetwork
    {
        public IEnumerable<RuleAction> Run(ISession session, Object fact)
        {
            return new List<RuleAction>();
        }
    }
}
