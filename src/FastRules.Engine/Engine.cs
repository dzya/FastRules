using System;
using System.Collections.Generic;
using System.Data;

namespace FastRules.Engine
{
    public class Engine
    {
        private readonly List<IRule> _rules;

        private bool isBuilt = true;

        public IEnumerable<IRule> Rules => _rules;

        public Engine()
        {
            _rules = new List<IRule>();
        }

        public void AddRule(IRule rule)
        {
            _rules.Add(rule);
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
