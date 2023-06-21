using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace FastRules.Engine.ReteNetwork
{
    public interface INetwork
    {
        public void AddRule(IRule<object> rule);

        public void Build();

        public IEnumerable<RuleAction> Run(ISession session, Object fact);
    }
}
