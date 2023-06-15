using System;
using System.Collections.Generic;

namespace FastRules.Engine
{
    public class Engine
    {
        private bool isBuilt = true;

        public void AddRule(IRule rule)
        {
            isBuilt = false;
        }

        public void Build()
        {

            isBuilt = true;
        }

        public IEnumerable<RuleAction> Run(Fact fact)
        {
            if(!isBuilt)
            {
                throw new InvalidOperationException("Rules should be build before run.");
            }

            return new RuleAction[0];
        }
    }
}
