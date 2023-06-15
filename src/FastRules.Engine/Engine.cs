using System;
using System.Collections.Generic;

namespace FastRules.Engine
{
    public class Engine
    {
        public void Build()
        {
        }

        public IEnumerable<RuleAction> Run(Fact fact)
        {
            return new RuleAction[0];
        }
    }
}
