using System;
using System.Collections.Generic;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace FastRules.Engine.ReteNetwork
{
    public interface INetwork
    {
        public IEnumerable<RuleAction> Run(ISession session, Object fact);
    }
}
